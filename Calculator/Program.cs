string input;

// 1. Basic precedence
Console.WriteLine("1. Basic precedence");
input = "5+3*4";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(5+3*4);

// 2. Negative number at the beginning
Console.WriteLine("\n2. Negative number at the beginning");
input = "-15+7";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(-15+7);

// 3. Negative number after multiplication
Console.WriteLine("\n3. Negative number after multiplication");
input = "8*(-3)";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(8*(-3));

// 4. Negative number after division
Console.WriteLine("\n4. Negative number after division");
input = "(-24)/6";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine((-24)/6);

// 5. Nested parentheses
Console.WriteLine("\n5. Nested parentheses");
input = "((2+3)*(4-1))";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(((2+3)*(4-1)));

// 6. Subtraction of a parenthesized expression
Console.WriteLine("\n6. Subtraction of a parenthesized expression");
input = "20-(5+3*2)";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(20-(5+3*2));

// 7. Negative expression in parentheses
Console.WriteLine("\n7. Negative expression in parentheses");
input = "5+(-3*4)";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(5+(-3*4));

// 8. Multiple operations with precedence
Console.WriteLine("\n8. Multiple operations with precedence");
input = "100-20/5+3*7-8";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(100-20/5+3*7-8);

// 9. Unary minus before parentheses
Console.WriteLine("\n9. Unary minus before parentheses");
input = "-(5+3)*2";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(-(5+3)*2);

// 10. Nested negative expressions
Console.WriteLine("\n10. Nested negative expressions");
input = "-((-5+2)*(3-1))";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(-((-5+2)*(3-1)));

// 11. Whitespace
Console.WriteLine("\n11. Whitespace");
input = "12 + 3 * (8 - 5)";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(12+3*(8-5));

// 12. Integer division
Console.WriteLine("\n12. Integer division");
input = "7/2";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(7/2);

// 13. Negative result from parentheses
Console.WriteLine("\n13. Negative result from parentheses");
input = "4*(3-8)";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(4*(3-8));

// 14. Several levels of nesting
Console.WriteLine("\n14. Several levels of nesting");
input = "2*((3+4)*(5-(2+1)))";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(2*((3+4)*(5-(2+1))));

// 15. Complex mixed expression
Console.WriteLine("\n15. Complex mixed expression");
input = "-12+4*(3+5)-30/5+2*6";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(-12+4*(3+5)-30/5+2*6);

// 16. Negative operands in different positions
Console.WriteLine("\n16. Negative operands in different positions");
input = "(-8)*(-3)+(-12)/4";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine((-8)*(-3)+(-12)/4);

// 17. Consecutive multiplication and division
Console.WriteLine("\n17. Consecutive multiplication and division");
input = "120/5/3*2";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(120/5/3*2);

// 18. Zero in the expression
Console.WriteLine("\n18. Zero in the expression");
input = "0-5*(3-3)+8";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(0-5*(3-3)+8);

// 19. Parentheses with mixed operators
Console.WriteLine("\n19. Parentheses with mixed operators");
input = "18/(2+1)*(7-4)";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(18/(2+1)*(7-4));

// 20. Long expression
Console.WriteLine("\n20. Long expression");
input = "-12+4*(-3+8)-30/(-5)+2*6";
Console.WriteLine(Calculator.Calculator.EvaluateBetter(input));
Console.WriteLine(-12+4*(-3+8)-30/(-5)+2*6);