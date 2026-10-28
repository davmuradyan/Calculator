namespace Calculator;

public static class Calculator
{
    private static readonly char[] Numbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    public static int Evaluate(string input)
    {
        char[] chars = input.ToCharArray();
        while (chars.Contains('('))
        {
            int index = chars.IndexOf('(');
            int indexToFind = index + 1;

            while (chars[indexToFind] != ')')
            {
                if (chars[indexToFind] == '(')
                {
                    index = indexToFind;
                }

                indexToFind++;
            }

            int bracketEvaluated = EvaluateWithoutBrackets(chars[(index + 1)..indexToFind]);
            chars = (new string(chars[..index])
                     + bracketEvaluated
                     + new string(chars[(indexToFind + 1)..]))
                .ToCharArray();
        }

        int result = EvaluateWithoutBrackets(chars);
        return result;
    }

    private static int ProcessNumber(char[] chars, ref int ptr, bool fwd = true)
    {
        int start = ptr;
        int end = ptr + 1;

        if (fwd)
        {
            while (end < chars.Length && char.IsDigit(chars[end]))
                end++;

            ptr = end;
        }
        else
        {
            while (start >= 0 && Numbers.Contains(chars[start]))
                start--;

            start++;
            ptr = start;
        }

        return int.Parse(new string(chars[start..end]));
    }

    private static int EvaluateWithoutBrackets(char[] chars)
    {
        while (chars.Contains('*') || chars.Contains('/'))
        {
            EvaluateMulDiv(ref chars);
        }

        if (chars.Contains('+') || chars.Contains('-'))
        {
            EvaluateSumSub(ref chars);
        }

        int t = 0;
        int result = ProcessNumber(chars, ref t);
        return result;
    }

    private static void EvaluateMulDiv(ref char[] chars)
    {
        int indexOfMul = chars.IndexOf('*') == -1 ? int.MaxValue : chars.IndexOf('*');

        int indexOfDiv = chars.IndexOf('/') == -1 ? int.MaxValue : chars.IndexOf('/');

        if (indexOfMul < indexOfDiv)
        {
            int indexBwd = indexOfMul - 1;
            int numA = ProcessNumber(chars, ref indexBwd, fwd: false);

            int indexFwd = indexOfMul + 1;
            int numB = ProcessNumber(chars, ref indexFwd);

            int res = numA * numB;

            chars = (new string(chars[..indexBwd])
                     + res
                     + new string(chars[indexFwd..]))
                .ToCharArray();
        }

        else
        {
            int indexBwd = indexOfDiv - 1;
            int numA = ProcessNumber(chars, ref indexBwd, fwd: false);

            int indexFwd = indexOfDiv + 1;
            int numB = ProcessNumber(chars, ref indexFwd);

            int res = numA / numB;

            chars = (new string(chars[..indexBwd])
                     + res
                     + new string(chars[indexFwd..]))
                .ToCharArray();
        }
    }

    private static void EvaluateSumSub(ref char[] chars)
    {
        int res = 0;
        int sign = 1;

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '-')
            {
                sign = -sign;
            }
            else if (chars[i] != '+')
            {
                int num = ProcessNumber(chars, ref i);
                i--;
                res += sign * num;
                sign = 1;
            }
        }

        chars = res.ToString().ToCharArray();
    }

    private static char[] str;

    private static int ptr;
    // private static Queue<int> Nums = new();
    // private static Queue<char> Ops = new();

    private static int ParseNumber()
    {
        int start = ptr;
        int end = ptr + 1;
        while (end < str.Length && char.IsDigit(str[end]))
            end++;

        ptr = end;
        return int.Parse(new string(str[start..end]));
    }

    public static int EvaluateBetter(string input)
    {
        str = new string("(" + input.Replace(" ", "") + ")").ToCharArray();
        ptr = 0;

        try
        {
            return Eval();
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("[ERROR] Division by zero detected");
            return 0;
        }
        catch (Exception e)
        {
            Console.WriteLine("[ERROR] Invalid input.");
            return 0;
        }
    }

    private static int Eval()
    {
        Queue<int> Nums = new Queue<int>();
        Queue<char> Ops = new Queue<char>();
        int result = 0;
        while (ptr < str.Length)
        {
            switch (str[ptr])
            {
                case ')':
                    if (Nums.Count != 0)
                    {
                        result += EvaluateQueues(Nums, Ops);
                    }

                    ptr++;
                    return result;
                case '(':
                    ptr++;
                    int recResult = Eval();
                    if (ptr >= str.Length - 1)
                    {
                        if (Nums.Count != 0)
                        {
                            Nums.Enqueue(recResult);
                            result += EvaluateQueues(Nums, Ops);
                            return result;
                        }
                        else
                        {
                            return result + recResult;
                        }
                    }

                    if (str[ptr] is '*' or '/')
                    {
                        Nums.Enqueue(recResult);
                        Ops.Enqueue(str[ptr]);
                        ptr++;
                    }
                    else if (Nums.Count != 0)
                    {
                        Nums.Enqueue(recResult);
                        if (str[ptr] is '-' or '+')
                        {
                            result += EvaluateQueues(Nums, Ops);
                        }
                    }
                    else
                    {
                        result += recResult;
                    }

                    break;
                default:
                    int num;
                    if (str[ptr + 1] == '(')
                    {
                        ptr += 2;
                        num = str[ptr - 2] == '-' ? -1 * Eval() : Eval();
                    }
                    else
                    {
                        num = ParseNumber();
                    }

                    if (ptr > str.Length - 1)
                    {
                        result += num;
                        return result;
                    }

                    switch (str[ptr])
                    {
                        case '+' or '-' or ')':
                            if (Nums.Count != 0)
                            {
                                Nums.Enqueue(num);
                                result += EvaluateQueues(Nums, Ops);
                            }
                            else
                            {
                                result += num;
                            }

                            break;
                        case '*' or '/':
                            Nums.Enqueue(num);
                            Ops.Enqueue(str[ptr]);
                            ptr++;
                            break;
                        default:
                            Nums.Enqueue(num);
                            break;
                    }

                    break;
            }
        }

        return result;
    }

    static int EvaluateQueues(Queue<int> Nums, Queue<char> Ops)
    {
        int result = Nums.Dequeue();

        while (Nums.Count != 0)
        {
            result = Ops.Dequeue() == '*' ? result * Nums.Dequeue() : result / Nums.Dequeue();
        }

        return result;
    }
}