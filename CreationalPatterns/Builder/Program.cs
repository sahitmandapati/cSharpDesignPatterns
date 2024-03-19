// Builer Pattern

// In Builder Pattern we have
// 1. Product
// 2. Concrete Builder
// 3. Builder
// 4. Director

// Let's say we are making a Product called Pizza and we have two types of Concrete Builders called Domino and PizzaHut and we have a Builder called IPizzaBuilder and we have a Director called PizzaDirector

// In this example, we will create a Pizza using the Builder Pattern.
// Product - Pizza
// Concrete Builder - Domino, PizzaHut
// Builder - IPizzaBuilder
// Director - PizzaDirector



class Program
{
    static void Main(string[] args)
    {
        PizzaDirector pizzaDirector = new PizzaDirector();

        DominoPizzaBuilder dominoPizzaBuilder = new DominoPizzaBuilder();
        PizzaHutBuilder pizzaHutBuilder = new PizzaHutBuilder();

        Pizza dominoPizza = pizzaDirector.BuildPizza(dominoPizzaBuilder);
        Pizza pizzaHutPizza = pizzaDirector.BuildPizza(pizzaHutBuilder);

        dominoPizza.Display();
        pizzaHutPizza.Display();

    }
}


public interface IPizzaBuilder
{
    void BuildCrust();
    void BuildSauce();
    void BuildToppings();
    Pizza GetPizza();
}


public class DominoPizzaBuilder : IPizzaBuilder
{
    private Pizza pizza;

    public DominoPizzaBuilder()
    {
        pizza = new Pizza();
    }

    public void BuildCrust()
    {
        pizza.Crust = "Thick crust";
    }

    public void BuildSauce()
    {
        pizza.Sauce = "Marinara sauce";
    }

    public void BuildToppings()
    {
        pizza.Toppings.Add("Pepperoni");
        pizza.Toppings.Add("Mushrooms");
        pizza.Toppings.Add("Cheese");
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

public class PizzaHutBuilder : IPizzaBuilder
{
    private Pizza pizza;
    public PizzaHutBuilder()
    {
        pizza = new Pizza();
    }

    public void BuildCrust()
    {
        pizza.Crust = "Thin crust";
    }

    public void BuildSauce()
    {
        pizza.Sauce = "Tomato sauce";
    }

    public void BuildToppings()
    {
        pizza.Toppings.Add("Ham");
        pizza.Toppings.Add("Pineapple");
        pizza.Toppings.Add("Cheese");
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

public class Pizza
{
    public string Crust { get; set; }
    public string Sauce { get; set; }
    public List<string> Toppings { get; set; }

    public Pizza()
    {
        Toppings = new List<string>();
    }

    public void Display()
    {
        Console.WriteLine($"Crust: {Crust}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine("Toppings:");
        foreach (var topping in Toppings)
        {
            Console.WriteLine($"- {topping}");
        }
    }
}

public class PizzaDirector
{

    public Pizza BuildPizza(IPizzaBuilder builder)
    {
        builder.BuildCrust();
        builder.BuildSauce();
        builder.BuildToppings();
        return builder.GetPizza();

    }
}