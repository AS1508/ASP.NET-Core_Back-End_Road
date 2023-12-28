//Theory
/*
Random dice = new Random();
int roll = dice.Next();
int roll2 = dice.Next(101);
int roll3 = dice.Next(50, 101);

Console.WriteLine($"First: {roll}");
Console.WriteLine($"Second: {roll2}");
Console.WriteLine($"Third: {roll3}");
*/

//Exercise = Show the most larger number between "fistValue" and "secondValue" in "largueValue"
int firstValue = 500;
int secondValue = 600;
int largeValue;

largeValue = Math.Max(firstValue, secondValue);
Console.WriteLine(largeValue);
