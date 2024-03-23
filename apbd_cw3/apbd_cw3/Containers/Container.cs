using apbd_cw3.Exceptions;
using apbd_cw3.Interfaces;

namespace apbd_cw3.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double CargoHeight { get; set; }
    
    public Products? CargoType { get; set; }
    public double MaxCargoWeight { get; set; }
    public double ContainerWeight { get; set; }
    public double ContainerDepth { get; set; }
    public string SerialNumber { get; set; }

    protected Container(double cargoWeight, double cargoHeight, double maxCargoWeight, double containerWeight, double containerDepth)
    {
        CargoWeight = cargoWeight;
        CargoHeight = cargoHeight;
        MaxCargoWeight = maxCargoWeight;
        ContainerWeight = containerWeight;
        ContainerDepth = containerDepth;
        CargoType = null;
        SerialNumber = "KON-";
    }

    public virtual void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(Products products, double cargoWeight)
    {
        throw new OverfilledException();
    }
    public void ShowInfo()
    {
        Console.WriteLine("\n------------------------------------\n" +
                          "SerialNumber: " + SerialNumber + 
                          "\nCargoWeight: " + CargoWeight +
                          "\nCargoHeight: " + CargoHeight +
                          "\nCargoType: " + CargoType +
                          "\nMaxCargoWeight: " + MaxCargoWeight +
                          "\nContainerWeight: " + ContainerWeight +
                          "\nContainerDepth: " + ContainerDepth +
                          "\n------------------------------------\n");
    }
}