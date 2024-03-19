// The Adapter Design Pattern is a structural design pattern that allows objects with incompatible interfaces to work together. It wraps itself around an object and exposes a standard interface for these objects to communicate. Here are the key terminologies related to the Adapter Design Pattern:

// In Adapter Design Pattern, we have:
//  Target: The interface that the client interacts with.
//  Adaptee: The existing object that needs adapting.
//  Adapter: The class that wraps the adaptee and exposes the target interface.
//  Client: The class that interacts with the adapter.

// In this example, we will create a Pizza using the Adapter Pattern.
// Target - ISquare
// Adaptee - ICircle
// Adapter - CircleAdapter
// Client - Program

// Existing interface for square calculation
interface ISquare
{
    double CalculateArea(double side);
}

// Existing SquareCalculator class
class SquareCalculator : ISquare
{
    public double CalculateArea(double side)
    {
        return side * side;
    }
}

// Interface for circle calculation
interface ICircle
{
    double CalculateArea(double radius);
}

// CircleAdapter class to adapt ICircle interface to ISquare interface
class CircleAdapter : ISquare
{
    private readonly ICircle _circle;

    public CircleAdapter(ICircle circle)
    {
        _circle = circle;
    }

    public double CalculateArea(double side)
    {
        // Since the Circle's area calculation uses radius, we adapt side to radius here.
        double radius = side / 2;
        return _circle.CalculateArea(radius);
    }
}

// CircleCalculator class implementing ICircle interface
class CircleCalculator : ICircle
{
    public double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Existing SquareCalculator instance
        ISquare squareCalculator = new SquareCalculator();

        // Create an adapter instance to adapt CircleCalculator to ISquare
        ISquare circleAdapter = new CircleAdapter(new CircleCalculator());

        // Calculate area of square
        double squareArea = squareCalculator.CalculateArea(5);
        Console.WriteLine($"Area of square: {squareArea}");

        // Calculate area of circle using the adapter
        double circleArea = circleAdapter.CalculateArea(5);
        Console.WriteLine($"Area of circle: {circleArea}");
    }
}

