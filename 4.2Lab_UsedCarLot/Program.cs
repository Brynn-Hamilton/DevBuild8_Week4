List<Car> CarLotInventory = new List<Car>
{
    new Car("Kia", "Soul", 2016, 16500m),
    new Car("Hyundai", "Sonata", 2020, 23500m),
    new Car("Nissan", "Titan", 2022, 42000m),
    new UsedCar("Toyota", "Camry", 2007, 8500m, 80000),
    new UsedCar("Honda", "Accord", 2010, 10500m, 20070.15),
    new UsedCar("Kia", "Sorrento", 2021, 23700m, 10675)

};
CarLot UsedCarLot = new CarLot(CarLotInventory);
bool toContinue = true;
while (toContinue)
{
    UsedCarLot.PrintInventory();
    string input = Console.ReadLine().ToLower();
    if (input == "a" || input == "add")
    {
        UsedCarLot.AddCar();
    }
    else if (input == "q" || input == "quit")
    {
        Console.WriteLine("Thank you for considering us! Have a great day!");
        toContinue = false;
    }
    else
    {
        UsedCarLot.RemoveCar();
    }
}

class Car
{
    public string Make;
    public string Model;
    public int Year;
    public decimal Price;

    public Car(string make, string model, int year, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }

    public override string ToString()
    {
        return $"The car is a {Year} {Make} {Model}. Sale price: ${Price}";
    }
}

class UsedCar : Car
{
    public double Mileage;

    public UsedCar(string make, string model, int year, decimal price, double mileage) : base(make, model, year, price)
    {
        Mileage = mileage;
    }
    public override string ToString()
    {
        return $"The used car is a {Year} {Make} {Model} with {Mileage} miles. Sale price: ${Price}";
    }
}

class CarLot
{
    public List<Car> Cars;

    public CarLot(List<Car> cars)
    {
        Cars = cars;
    }

    public void AddCar()
    {
        Console.WriteLine("What kind of car would you like to add? New or Used?");
        string type = Console.ReadLine().ToLower();

        Console.Write("What is the car's Make? ");
        string make = Console.ReadLine();

        Console.Write("What Model is the car? ");
        string model = Console.ReadLine();

        Console.Write("What Year is the car? ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.Write("What is the Price of the car? ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        if (type == "new")
        {
            Cars.Add(new Car(make, model, year, price));
        }
        else if (type == "used")
        {
            Console.Write("How many miles does the car have? ");
            double mileage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Cars.Add(new UsedCar(make, model, year, price, mileage));
        }

    }

    public void RemoveCar()
    {
            Console.WriteLine("Which car would you like?");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Is this the car you want to buy? (y/n)");
            Console.WriteLine(Cars[index - 1]);
            string yesno = Console.ReadLine().ToLower();
            if (yesno == "y" || yesno == "yes")
            {
                Cars.RemoveAt(index - 1);
                Console.WriteLine("Congratulations on your new car!");
                Console.WriteLine();
            }
            else if (yesno == "n" || yesno == "no")
            {
                Console.WriteLine("Not a problem! Let's return to the menu to see if there is anything else you'd like to do today!");
                Console.WriteLine();
            }
    }

    public void PrintInventory()
    {
        for (int index = 0; index < Cars.Count; index++)
        {
            Car cars = Cars[index];
            Console.WriteLine($"{index + 1}: {cars} ");
        };
        Console.WriteLine("(A)dd car to car lot inventory");
        Console.WriteLine("(Q)uit");
        Console.WriteLine("Press any other key to select a car for purchase");
    }
}