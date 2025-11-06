ComplexValue part1A = new(149,55);
ComplexValue part1Value = new(0,0);

part1(part1Value, part1A);

void part1(ComplexValue result, ComplexValue A)
{
    for(int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Iteration {i + 1}");
        Console.WriteLine($"Result before multiplication: {result}");
        result = multiplyValues(result, result);
        Console.WriteLine($"Result before division: {result}");
        result = divideValues(result, new ComplexValue(10, 10));
        Console.WriteLine($"Result before addition: {result}");
        result = addValues(result, A);
        Console.WriteLine($"Result after addition: {result}");
    }
    Console.WriteLine($"Part 1 Result: {result}");
}



ComplexValue addValues(ComplexValue value1, ComplexValue value2)
{

    int X1 = value1.X;
    int Y1 = value1.Y;
    int X2 = value2.X;
    int Y2 = value2.Y;
    var result = new ComplexValue(X1 + X2, Y1 + Y2);
    return result;
}


ComplexValue multiplyValues(ComplexValue value1, ComplexValue value2)
{

    int X1 = value1.X;
    int Y1 = value1.Y;
    int X2 = value2.X;
    int Y2 = value2.Y;
    var result = new ComplexValue(X1 * X2 - Y1 * Y2, X1 * Y2 + Y1 * X2);
    return result;
}

ComplexValue divideValues(ComplexValue value1, ComplexValue value2)
{

    int X1 = value1.X;
    int Y1 = value1.Y;
    int X2 = value2.X;
    int Y2 = value2.Y;
    var result = new ComplexValue(X1 / X2, Y1 / Y2);
    return result;
}

class ComplexValue
{
    public int X { get; set; }
    public int Y { get; set; }
    public ComplexValue(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"[{X},{Y}]";
    }
}