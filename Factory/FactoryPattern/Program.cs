// The Factory Pattern is a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. Here are the key terminologies:

// Product: This is the common interface for the objects the factory method creates. In your code, Pizza is the product.

// Concrete Product: These are various implementations of the product interface. In your code, CheesePizza and PepperoniPizza are concrete products.

// Creator: This is a class that contains the factory method. In your code, SimplePizzaFactory is the creator.

// Concrete Creator: This class implements the factory method to return an instance of a ConcreteProduct. In your code, the CreatePizza method in SimplePizzaFactory is the concrete creator.

// Factory Method: This is a method in the Creator class that returns a product. Subclasses of the Creator can override this method to change the type of product that will be created. In your code, CreatePizza is the factory method.

// Client: This is the class that uses the factory to create objects. In your code, Program is the client.

// Here the Poduct is Pizza and the Concrete Products are CheesePizza and PepperoniPizza. The Creator is SimplePizzaFactory and the Concrete Creator is CreatePizza method. The Client is Program class.

public enum PizzaType
{
    Cheese,
    Pepperoni
}

public class Pizza
{    
    protected string Name { get; set; }
    protected string Dough { get; set; }
    protected string Sauce { get; set; }
    protected string[] Toppings { get; set; }


    public void Prepare()
    {
        Console.WriteLine($"Preparing, {Name}");
        Console.WriteLine($"Tossing Dough...");
        Console.WriteLine($"Adding Sauce...");
        Console.WriteLine($"Adding Toppings...");
        foreach (var topping in Toppings)
        {
            Console.WriteLine(topping);
        }
    }


    public void Bake()
    {
        Console.WriteLine($"Baking, {Name}");
    }

    public void Cut()
    {
        Console.WriteLine($"Cuting, {Name}");
    }

    public void Box()
    {
        Console.WriteLine($"Boxing, {Name}");
    }


}

public class PepperoniPizza : Pizza
{
 
    public PepperoniPizza()
    {
        Name = "Pepperoni Pizza";
        Dough = "Crust";
        Sauce = "Marinara sauce";
        Toppings = new string[] { "Sliced Pepperoni", "Sliced Onion", "Grated parmesan cheese" };
    }
}

public class CheesePizza : Pizza
{
    public CheesePizza()
    {
        Name = "Cheese Pizza";
        Dough = "Regular Crust";
        Sauce = "Marinara Pizza Sauce";
        Toppings = new string[] { "Fresh Mozzarella", "Parmesan" };
    }
}


public class SimplePizzaFactory
{
    public Pizza CreatePizza(PizzaType type)
    {
        Pizza pizza;
        switch (type)
        {
            case PizzaType.Cheese:
                pizza = new CheesePizza();
                break;
            case PizzaType.Pepperoni:
                pizza = new PepperoniPizza();
                break;
            default:
                throw new ArgumentException($"Invalid pizza type: {type}");

        }
        return pizza;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimplePizzaFactory factory = new SimplePizzaFactory();
        Pizza cheesePizza = factory.CreatePizza(PizzaType.Cheese);
        cheesePizza.Prepare();
        cheesePizza.Bake();
        cheesePizza.Cut();
        cheesePizza.Box();

        Pizza pepperoniPizza = factory.CreatePizza(PizzaType.Pepperoni);
        pepperoniPizza.Prepare();
        pepperoniPizza.Bake();
        pepperoniPizza.Cut();
        pepperoniPizza.Box();

    }
}

