// Mediator pattern.

// The Mediator pattern is a behavioral design pattern that encapsulates how a set of objects interact. It promotes loose coupling by keeping objects from referring to each other explicitly, and it allows their interaction to vary independently. Here are the terminologies used in the Mediator pattern:

// Mediator: This is an interface that defines a contract for communication between colleague objects. In this case, it has a method SendOrder which is used to send orders.

// Concrete Mediator: This is a class that implements the Mediator interface. It coordinates communication between colleague objects. It maintains a list of PizzaBase objects and can send orders to them.

// Colleague: These are the classes that communicate with each other via the Mediator. In this case, PizzaBase is an abstract class that represents a pizza base. It has a reference to the Mediator object and a method to order a pizza.

// Concrete Colleague: These are specific implementations of the Colleague class. They use the Mediator to communicate with other colleagues.

// Client: This is where the Mediator and Colleagues are instantiated and used. The client configures the system by creating a Mediator, creating Colleagues, and registering the Colleagues with the Mediator.

// We use Mediator pattern when the communication between objects is complex and needs to be centralized. It also helps in reducing the complexity of communication between objects.

// In this program we will create a pizza using the Mediator pattern.

// Mediator : IPizzaOrderMediator
// Concrete Mediator : PizzaOrderMediator
// Colleague : PizzaBase
// Concrete Colleague : ThinCrustPizza, ThickCrustPizza
// Client : Program

// Mediator interface
interface IPizzaOrderMediator
{
    void SendOrder(string order, PizzaBase pizzaBase);
}

// Concrete Mediator
class PizzaOrderMediator : IPizzaOrderMediator
{
    private List<PizzaBase> pizzaBases = new List<PizzaBase>();

    public void AddPizzaBase(PizzaBase pizzaBase)
    {
        pizzaBases.Add(pizzaBase);
    }

    public void SendOrder(string order, PizzaBase pizzaBase)
    {
        Console.WriteLine($"Order received: {order}");
        Console.WriteLine($"Preparing pizza with {pizzaBase.Type} base");
        pizzaBase.CompleteOrder();
    }
}

// Colleague
abstract class PizzaBase
{
    protected IPizzaOrderMediator mediator;
    public string Type { get; }

    public PizzaBase(IPizzaOrderMediator mediator, string type)
    {
        this.mediator = mediator;
        this.Type = type;
    }

    public abstract void OrderPizza();
    public void CompleteOrder()
    {
        Console.WriteLine($"Pizza with {Type} base is ready!");
    }
}

// Concrete Colleague
class ThinCrustPizza : PizzaBase
{
    public ThinCrustPizza(IPizzaOrderMediator mediator) : base(mediator, "thin crust") { }

    public override void OrderPizza()
    {
        mediator.SendOrder("Thin crust pizza", this);
    }
}

// Concrete Colleague
class ThickCrustPizza : PizzaBase
{
    public ThickCrustPizza(IPizzaOrderMediator mediator) : base(mediator, "thick crust") { }

    public override void OrderPizza()
    {
        mediator.SendOrder("Thick crust pizza", this);
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        var mediator = new PizzaOrderMediator();

        var thinCrustPizza = new ThinCrustPizza(mediator);
        var thickCrustPizza = new ThickCrustPizza(mediator);

        mediator.AddPizzaBase(thinCrustPizza);
        mediator.AddPizzaBase(thickCrustPizza);

        thinCrustPizza.OrderPizza();
        thickCrustPizza.OrderPizza();
    }
}
