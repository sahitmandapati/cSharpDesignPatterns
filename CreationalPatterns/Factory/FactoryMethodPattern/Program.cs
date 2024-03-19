// The Factory Method Pattern is a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. Here are the key terminologies:

// Product: This is the common interface for the objects the factory method creates. In your code, Pizza is the product.

// Concrete Product: These are various implementations of the product interface. In your code, the concrete products would be specific types of pizzas like Cheese Pizza, Pepperoni Pizza, etc.

// Creator: This is a class that declares the factory method, which returns new product objects. In your code, DominoStore and PizzaHutStore would be considered creators.

// Concrete Creator: This class overrides the factory method to return an instance of a ConcreteProduct. In your code, the CreateOrder method in DominoStore and PizzaHutStore would be the concrete creators.

// Factory Method: This is a method in the Creator class that returns a product. Subclasses of the Creator can override this method to change the type of product that will be created. In your code, CreateOrder is the factory method.

// Client: This is the class that uses the factory to create objects. In your code, Program is the client.

// Here the Poduct is Pizza and the Concrete Products are CheesePizza and PepperoniPizza. The Creator is PizzaStore and the Concrete Creator is CreateOrder method. The Client is Program class.

public enum PizzaType
{
    Cheese,

    Pepperoni
}

class Program
{
    static void Main(string[] args)
    {
        DominoStore dominoStore = new DominoStore();
        dominoStore.CreateOrder(PizzaType.Cheese);
        PizzaHutStore pizzaHutStore = new PizzaHutStore();
        pizzaHutStore.CreateOrder(PizzaType.Pepperoni);
    }
}


public abstract class Pizza
{
    public abstract void Prepare();

    public void Bake()
    {
        Console.WriteLine("Bake for 25 minutes at 350");
    }

    public void Cut()
    {
        Console.WriteLine("Cutting the pizza into diagonal slices");
    }

    public void Box()
    {
        Console.WriteLine("Place pizza in official PizzaStore box");
    }
}

public class DominoPepperoniPizza : Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Preparing Domino Pepperoni Pizza");
    }
}

public class DominoCheesePizza : Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Preparing Domino Cheese Pizza");
    }
}

public class PizzaHutPepperoniPizza : Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Preparing PizzaHut Pepperoni Pizza");
    }
}

public class PizzaHutCheesePizza : Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Preparing PizzaHut Cheese Pizza");
    }
}


public abstract class PizzaStore
{
    public Pizza CreateOrder(PizzaType type)
    {
        Pizza pizza = CreatePizza(type);
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;

    }

    protected abstract Pizza CreatePizza(PizzaType type);
}



public class DominoStore : PizzaStore
{
    protected override Pizza CreatePizza(PizzaType type)
    {
        switch (type)
        {
            case PizzaType.Cheese:
                return new DominoCheesePizza();
            case PizzaType.Pepperoni:
                return new DominoPepperoniPizza();
            default:
                return null;
        }
    }
}



public class PizzaHutStore : PizzaStore
{
    protected override Pizza CreatePizza(PizzaType type)
    {
        switch (type)
        {
            case PizzaType.Cheese:
                return new PizzaHutCheesePizza();
            case PizzaType.Pepperoni:
                return new PizzaHutPepperoniPizza();
            default:
                return null;
        }
    }
}

