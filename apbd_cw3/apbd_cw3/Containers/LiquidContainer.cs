﻿using apbd_cw3.Exceptions;
using apbd_cw3.Interfaces;

namespace apbd_cw3.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private static double ContainerCounter = 1;

    private static List<Products> AllowedProducts = [Products.Fuel, Products.Milk, Products.Water];
    public LiquidContainer(double cargoWeight, double cargoHeight, double maxCargoWeight, double containerWeight, double containerDepth) : base(cargoWeight, cargoHeight, maxCargoWeight, containerWeight, containerDepth)
    {
        SerialNumber += "L-" + ContainerCounter++;
    }

    public override void Load(Products product, double cargoWeight)
    {
        if (MeetRequirements(product, cargoWeight))
        {
            switch (product)
            {
                case Products.Milk or Products.Water: 
                    LoadSafeProduct(product, cargoWeight); 
                    break;
                    
                case Products.Fuel:
                    LoadDangerousProduct(product, cargoWeight);
                    break;
            }
            Console.WriteLine("Container " + SerialNumber + " was loaded with " + product);
        }
    }

    private void LoadSafeProduct(Products product, double cargoWeight)
    {
        if (CargoWeight + cargoWeight <= MaxCargoWeight * 0.9)
        {
            CargoWeight += cargoWeight;
            CargoType = product;
        }
        else
        {
            Console.WriteLine("Can't load cargo. Weight exceeds the allowable");
            NotifyAboutDangerousSituation("Attempting to load the container more than allowed");
        }
    }

    private void LoadDangerousProduct(Products product, double cargoWeight)
    {
        if (CargoWeight + cargoWeight <= MaxCargoWeight * 0.5)
        {
            CargoWeight += cargoWeight;
            CargoType = product;
        }
        else
        {
            Console.WriteLine("Can't load cargo. Weight exceeds the allowable");
            NotifyAboutDangerousSituation("Attempting to load the container more than allowed");
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
            Console.WriteLine("Can't load '" + product + "' because container already contains product '" + CargoType + "' ");
            return false;
        }

        return true;
    }

    public void ShowSerialNUmber()
    {
        Console.WriteLine(SerialNumber);
    }

    public void NotifyAboutDangerousSituation(string message)
    {
        Console.WriteLine("Warning, dangerous situation\n" + "Container number: " + SerialNumber + "\n" + message);
    }
}