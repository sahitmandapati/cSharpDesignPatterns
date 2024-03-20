// Observer Pattern

// The Observer pattern is a behavioral design pattern that allows an object (the subject) to publish changes to its state. Other objects (the observers) subscribe to be immediately notified of any changes. This pattern promotes loose coupling between the objects, which means that the subject doesn't need to know anything about the observers and vice versa.

// Here are the terminologies used in the Observer pattern:

// Subject: This is an interface that defines the contract for the subject. It has methods to register, remove, and notify observers.

// Concrete Subject: This is a class that implements the Subject interface. It maintains a list of observers and notifies them of any changes in its state.

// Observer: This is an interface that defines the contract for the observer. It has a method to update the observer when the subject's state changes.

// Concrete Observer: This is a class that implements the Observer interface. It registers itself with the subject and gets notified when the subject's state changes.

// Client: This is where the subject and observers are instantiated and used. The client configures the system by creating a subject, creating observers, and registering the observers with the subject.

// We use the Observer pattern when we want to notify multiple objects about changes in the state of another object. It also helps in reducing the coupling between the subject and the observers.

// In this program, we will create a pizza using the Observer pattern.

// Subject: IPizzaOrder
// Concrete Subject: PizzaOrder
// Observer: IOrderObserver
// Concrete Observer: PizzaBase, PizzaTopping
// Client: Program

// Subject interface
interface IPizzaOrder
{
    void AddObserver(IOrderObserver observer);
    void RemoveObserver(IOrderObserver observer);
    void NotifyObservers();
}


// Concrete Subject

class PizzaOrder : IPizzaOrder
{
    private List<IOrderObserver> observers = new List<IOrderObserver>();
    private string order;

    public void AddObserver(IOrderObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IOrderObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(order);
        }
    }

    public void SetOrder(string order)
    {
        this.order = order;
        NotifyObservers();
    }
}

// Observer interface

interface IOrderObserver
{
    void Update(string order);
}

// Concrete Observer

class PizzaBase : IOrderObserver
{
    public void Update(string order)
    {
        Console.WriteLine($"Preparing pizza with {order} base");
    }
}

// Concrete Observer

class PizzaTopping : IOrderObserver
{
    public void Update(string order)
    {
        Console.WriteLine($"Adding {order} topping to the pizza");
    }
}


class Program
{
    static void Main(string[] args)
    {
        PizzaOrder pizzaOrder = new PizzaOrder();
        PizzaBase pizzaBase = new PizzaBase();
        PizzaTopping pizzaTopping = new PizzaTopping();

        pizzaOrder.AddObserver(pizzaBase);
        pizzaOrder.AddObserver(pizzaTopping);

        pizzaOrder.SetOrder("thin crust");
    }
}