// The Decorator Pattern is a structural design pattern that allows behavior to be added to individual objects, either statically or dynamically, without affecting the behavior of other objects from the same class. The Decorator Pattern is often used to extend the functionality of an object, without changing the original code. 

// In Decorator Design Pattern, we have:
// Component: The interface for the objects that can have responsibilities added to them dynamically.
// ConcreteComponent: The class that implements the Component interface.
// Decorator: The class that wraps the ConcreteComponent and adds responsibilities to it.
// ConcreteDecorator: The class that adds responsibilities to the ConcreteComponent.

//In this example, we will create a Pizza using the Decorator Pattern. 
// Component - IPizza
// ConcreteComponent - BasicPizza
// Decorator - PizzaDecorator
// ConcreteDecorator - CheeseDecorator, PepperoniDecorator


// Interface for the pizza
interface IPizza
{
    string GetDescription();
    double GetCost();
}

// Concrete implementation of a basic pizza
class BasicPizza : IPizza
{
    public string GetDescription()
    {
        return "Pizza";
    }

    public double GetCost()
    {
        return 5.00;
    }
}

// Decorator base class
abstract class PizzaDecorator : IPizza
{
    protected IPizza pizza;

    public PizzaDecorator(IPizza pizza)
    {
        this.pizza = pizza;
    }

    public virtual string GetDescription()
    {
        return pizza.GetDescription();
    }

    public virtual double GetCost()
    {
        return pizza.GetCost();
    }
}

// Concrete decorator adding cheese topping
class CheeseDecorator : PizzaDecorator
{
    // Constructor to pass the pizza to the decorator
    public CheeseDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Cheese";
    }

    public override double GetCost()
    {
        return base.GetCost() + 1.50;
    }
}

// Concrete decorator adding pepperoni topping
class PepperoniDecorator : PizzaDecorator
{
    public PepperoniDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Pepperoni";
    }

    public override double GetCost()
    {
        return base.GetCost() + 2.00;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ordering a basic pizza
        IPizza basicPizza = new BasicPizza();
        Console.WriteLine("Basic Pizza:");
        Console.WriteLine(basicPizza.GetDescription());
        Console.WriteLine($"Cost: ${basicPizza.GetCost()}");

        // Adding cheese topping
        IPizza cheesePizza = new CheeseDecorator(basicPizza);
        Console.WriteLine("\nPizza with Cheese:");
        Console.WriteLine(cheesePizza.GetDescription());
        Console.WriteLine($"Cost: ${cheesePizza.GetCost()}");

        // Adding pepperoni topping
        IPizza deluxePizza = new PepperoniDecorator(cheesePizza);
        Console.WriteLine("\nDeluxe Pizza:");
        Console.WriteLine(deluxePizza.GetDescription());
        Console.WriteLine($"Cost: ${deluxePizza.GetCost()}");
    }
}
