using apbd_cw3.Exceptions;

namespace apbd_cw3.Containers;

public class GasContainer : Container
{
    private static double ContainerCounter = 1;

    private double Pressure = 0;
    
    private static List<Products> AllowedProducts = [Products.Oxygen, Products.Chlorine, Products.Helium];
    
    public GasContainer(double cargoWeight, double cargoHeight, double maxCargoWeight, double containerWeight, double containerDepth) 
        : base(cargoWeight, cargoHeight, maxCargoWeight, containerWeight, containerDepth)
    {
        SerialNumber += "G-" + ContainerCounter++;
    }

    public override void Load(Products product, double cargoWeight)
    {
        if (MeetRequirements(product, cargoWeight))
        {
            CargoWeight += cargoWeight;
            Pressure += cargoWeight * 0.2; //Fake formula to simulate pressure
            CargoType = product;
        }
    }
    
    private bool MeetRequirements(Products product, double cargoWeight)
    {
        
        if (CargoWeight + cargoWeight > MaxCargoWeight)
        {
            throw new OverfilledException();
        }

        if (!AllowedProducts.Contains(product))
        {
            Console.WriteLine("Container can't store that product");
            return false;
        }

        if (CargoType != product && CargoType != null)
        {
            Console.WriteLine("Can't load product. Product already contains other product");
            return false;
        }

        return true;
    }

    public override void Unload()
    {
        CargoWeight = CargoWeight / 100 * 5;
        CargoType = null;
    }
}