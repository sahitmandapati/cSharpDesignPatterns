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

