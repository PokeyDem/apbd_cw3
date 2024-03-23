using apbd_cw3.Exceptions;

namespace apbd_cw3.Containers;

public class RefrigeratedContainer : Container
{
    private Dictionary<Products, double> AllowedProductsWithTemperature = new Dictionary<Products, double>() { {Products.Bananas, 13.3},
        { Products.Chocolate, 18}, { Products.Fish, 2}, { Products.Meat, -15}, { Products.IceCream, -18},
        { Products.FrozenPizza, -30}, { Products.Cheese, 7.2}, { Products.Sausages,5}, { Products.Butter,20.5},
        { Products.Eggs, 19}};

    private double ContainerTemperature { get; set; }
    
    private static double ContainerCounter = 1;

    public RefrigeratedContainer(double cargoWeight, double cargoHeight, double maxCargoWeight, double containerWeight, double containerDepth, double containerTemperature) 
        : base(cargoWeight, cargoHeight, maxCargoWeight, containerWeight, containerDepth)
    {
        ContainerTemperature = containerTemperature;
        SerialNumber += "C-" + ContainerCounter++;
    }

    public override void Load(Products product, double cargoWeight)
    {
        if (MeetRequirements(product, cargoWeight))
        {
            CargoWeight += cargoWeight;
            CargoType = product;
            Console.WriteLine("Product loaded");
        }
    }

    private bool MeetRequirements(Products product, double cargoWeight)
    {
        
        if (CargoWeight + cargoWeight > MaxCargoWeight)
        {
            throw new OverfilledException();
        }

        if (!AllowedProductsWithTemperature.ContainsKey(product))
        {
            Console.WriteLine("Container can't store that product");
            return false;
        }

        if (CargoType != product && CargoType != null)
        {
            Console.WriteLine("Can't load product. Product already contains other product");
            return false;
        }

        if (AllowedProductsWithTemperature[product] > ContainerTemperature)
        {
            Console.WriteLine("Can't load product. Temperature in container lower than required");
            return false;
        }

        return true;
    }

    public override void Unload()
    {
        CargoType = null;
        CargoWeight = 0;
    }
    
}