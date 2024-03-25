using apbd_cw3.Containers;
using apbd_cw3.Interfaces;

namespace apbd_cw3.Ships;

public class CargoShip : IShowInfo
{
    public List<Container> ContainersOnBoard;
    public double MaxSpeed { get; set; }
    public double MaxCargoWeight { get; set; }

    public int MaxAmountOfContainers { get; set; }

    private double CurrentCargoWeight;

    private int CurrentAmountOfContainers;

    public CargoShip(double maxSpeed, int maxAmountOfContainers, double maxCargoWeight)
    {
        MaxSpeed = maxSpeed;
        MaxCargoWeight = maxCargoWeight;
        MaxAmountOfContainers = maxAmountOfContainers;
        ContainersOnBoard = new List<Container>();
        CurrentAmountOfContainers = 0;
    }

    public void LoadContainer(Container container)
    {
        if (CheckRequirements(container))
        {
            ContainersOnBoard.Add(container);
            CurrentCargoWeight += container.CargoWeight;
            CurrentAmountOfContainers++;
            Console.WriteLine("Container " + container.SerialNumber + " was loaded on ship");
        }

    }

    public bool CheckRequirements(Container container)
    {
        if (CurrentCargoWeight + container.CargoWeight > MaxCargoWeight * 1000)
        {
            Console.WriteLine("Can't load container '" + container.SerialNumber + "' on ship, action causes ship overload");
            return false;
        }

        if (CurrentAmountOfContainers + 1 > MaxAmountOfContainers)
        {
            Console.WriteLine("Can't load container '" + container.SerialNumber + "' on ship, reached limit of containers on board");
            return false;
        }

        return true;

    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(Container container)
    {
        ContainersOnBoard.Remove(container);
        Console.WriteLine("Container " + container.SerialNumber + " was unloaded from ship");
    }

    public void ReplaceContainer(int oldContainerIndex, Container newContainer)
    {
        String oldContainerSerialNumber = ContainersOnBoard[oldContainerIndex].SerialNumber;
        ContainersOnBoard[oldContainerIndex] = newContainer;
        Console.WriteLine("Container " + oldContainerSerialNumber +  " was replaced with " + newContainer.SerialNumber);
    }

    public void MoveContainerToOtherShip(int containerIndex, CargoShip destinationShip)
    {
        Container containerToMove = ContainersOnBoard[containerIndex];
        ContainersOnBoard.Remove(containerToMove);
        destinationShip.LoadContainer(containerToMove);
        Console.WriteLine("Container " + containerToMove.SerialNumber +  " was moved to other ship ");
    }


    public void ShowInformation()
    {
        Console.WriteLine("\nCargo ship (" + "MaxSpeed: " + MaxSpeed + ", MaxCargoWeight: " + MaxCargoWeight
        + ", CurrentCargoWeight: " + CurrentCargoWeight + "\nCargo list: ");
        int containerCounter = 1;
        foreach (var container in ContainersOnBoard)
        {
            Console.WriteLine(containerCounter++ + ". " + container.SerialNumber);
        }
        
    }
}