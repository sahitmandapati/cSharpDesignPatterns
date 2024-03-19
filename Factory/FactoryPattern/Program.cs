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

