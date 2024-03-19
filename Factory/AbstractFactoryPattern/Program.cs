// The Abstract Factory Pattern is a creational design pattern that provides an interface for creating families of related or dependent objects without specifying their concrete classes. Here are the key terminologies:

// Abstract Factory: This is an interface that declares a set of methods for creating abstract products. In your code, IPizzaIngredientFactory would be considered the abstract factory.

// Concrete Factory: These are classes that implement the abstract factory's methods to create concrete products. In your code, a concrete factory would be a specific implementation of IPizzaIngredientFactory.

// Abstract Product: This is an interface for a type of product objects. In your code, Pizza is an abstract product.

// Concrete Product: These are various implementations of the abstract product interface. In your code, CheesePizza is a concrete product.

// Client: This is a class that uses the factory to create objects. The client only interacts with the abstract factory and abstract product interfaces, so it can work with any concrete factories and products. In your code, a client would be a class that uses IPizzaIngredientFactory to create Pizza objects.

// Here the Abstract Factory is IPizzaIngredientFactory and the Concrete Factories are DominoIngredientFactory and PizzaHutIngredientFactory. The Abstract Product is Pizza and the Concrete Products are CheesePizza and PepperoniPizza. The Client is Program class.

public enum PizzaType
{
    Cheese,
    Pepperoni
}

public abstract class Pizza
{

    protected string Dough;
    protected string Sauce;  
    protected string[] Toppings;

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

public class CheesePizza : Pizza
{
    private IPizzaIngredientFactory _ingredientFactory;
    public CheesePizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;

    }
    public override void Prepare()
    {
        Console.WriteLine($"Preparing, {nameof(CheesePizza)}");
        Dough = _ingredientFactory.CreateDough();
        Sauce = _ingredientFactory.CreateSauce();
        Toppings = _ingredientFactory.CreateToppings();
        Console.WriteLine($"Dough: {Dough}, Sauce: {Sauce}, Toppings: {string.Join(",", Toppings)}");
    }
}

public class PepperoniPizza : Pizza
{
    private IPizzaIngredientFactory _ingredientFactory;

    public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;

    }
    public override void Prepare()
    {
        Console.WriteLine($"Preparing, {nameof(PepperoniPizza)}");
        Dough = _ingredientFactory.CreateDough();
        Sauce = _ingredientFactory.CreateSauce();
        Toppings = _ingredientFactory.CreateToppings();
        Console.WriteLine($"Dough: {Dough}, Sauce: {Sauce}, Toppings: {string.Join(",", Toppings)}");
    }
}


public interface IPizzaIngredientFactory
{
    string CreateDough();
    string CreateSauce();
    string[] CreateToppings();
}

public class DominoIngredientFactory : IPizzaIngredientFactory
{
    public string CreateDough()
    {
        return "Thin Crust Dough";
    }

    public string CreateSauce()
    {
        return "Marinara Sauce";
    }

    public string[] CreateToppings()
    {
        return new string[] {"Grated Reggiano Cheese", "Fresh Clams", "Garlic", "Onion"};
    }
}

public class PizzaHutIngredientFactory : IPizzaIngredientFactory
{
    public string CreateDough()
    {
        return "Thick Crust Dough";
    }

    public string CreateSauce()
    {
        return "Plum Tomato Sauce";
    }

    public string[] CreateToppings()
    {
        return new string[] {"Shredded Mozzarella Cheese", "Black Olives", "Spinach", "Eggplant"};
    }
}




public abstract class PizzaStore
{
    public Pizza OrderPizza(PizzaType type)
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
        IPizzaIngredientFactory ingredientFactory = new DominoIngredientFactory();

        switch (type)
        {
            case PizzaType.Cheese:
                return new CheesePizza(ingredientFactory);
            case PizzaType.Pepperoni:
                return new PepperoniPizza(ingredientFactory);
            default:
                throw new Exception("Invalid Pizza Type");
        }
    }


}


public class PizzaHutStore : PizzaStore
{
    IPizzaIngredientFactory ingredientFactory = new PizzaHutIngredientFactory();

    protected override Pizza CreatePizza(PizzaType type)
    {
        switch (type)
        {
            case PizzaType.Cheese:
                return new CheesePizza(ingredientFactory);
            case PizzaType.Pepperoni:
                return new PepperoniPizza(ingredientFactory);
            default:
                throw new Exception("Invalid Pizza Type");
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        PizzaStore dominoStore = new DominoStore();
        dominoStore.OrderPizza(PizzaType.Cheese);
        dominoStore.OrderPizza(PizzaType.Pepperoni);
        Console.WriteLine("ordered at " + dominoStore.GetType().Name + "\n");
        PizzaStore pizzaHutStore = new PizzaHutStore();
        pizzaHutStore.OrderPizza(PizzaType.Cheese);
        pizzaHutStore.OrderPizza(PizzaType.Pepperoni);
        Console.WriteLine("ordered at " + pizzaHutStore.GetType().Name + "\n");
    }
}