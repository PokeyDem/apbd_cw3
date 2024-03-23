using apbd_cw3.Containers;
using apbd_cw3.Interfaces;

namespace apbd_cw3.Ships;

public class CargoShip : IShowInfo
{
    public List<Container> ContainersOnBoard;
    public double MaxSpeed { get; set; }
    public double MaxCargoWeight { get; set; }

    private double CurrentCargoWeight;

    public CargoShip(double maxSpeed, double maxCargoWeight)
    {
        MaxSpeed = maxSpeed;
        MaxCargoWeight = maxCargoWeight;
        ContainersOnBoard = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (CurrentCargoWeight + container.CargoWeight <= MaxCargoWeight)
        {
            ContainersOnBoard.Add(container);
            CurrentCargoWeight += container.CargoWeight;
        }
        else
        {
            Console.WriteLine("Can't load container '" + container.SerialNumber + "' on ship, action causes ship overload");
        }
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
    }

    public void ReplaceContainer(int oldContainerIndex, Container newContainer)
    {
        ContainersOnBoard[oldContainerIndex] = newContainer;
    }

    public void MoveContainerToOtherShip(int containerIndex, CargoShip destinationShip)
    {
        Container containerToMove = ContainersOnBoard[containerIndex];
        ContainersOnBoard.Remove(containerToMove);
        destinationShip.LoadContainer(containerToMove);
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