// See https://aka.ms/new-console-template for more information
using apbd_cw3;
using apbd_cw3.Containers;
using apbd_cw3.Ships;

//Stworzenie kontenera danego typu
LiquidContainer liquidContainer =  new LiquidContainer(0,300, 400, 250, 500);

//Załadowanie ładunku do danego kontenera
liquidContainer.Load(Products.Fuel, 200);

CargoShip cargoShip = new CargoShip(20, 100, 100);

//Załadowanie kontenera na statek
cargoShip.LoadContainer(liquidContainer);

GasContainer gasContainer = new GasContainer(0, 250, 200, 150, 500);
gasContainer.Load(Products.Oxygen, 140);

RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(0, 320, 500, 170, 350, 15);
refrigeratedContainer.Load(Products.Bananas, 400);

List<Container> containers = new List<Container>();
containers.Add(gasContainer);
containers.Add(refrigeratedContainer);

//Załadowanie listy kontenerów na statek
cargoShip.LoadContainers(containers);

//Usunięcie kontenera ze statku
cargoShip.UnloadContainer(refrigeratedContainer);

//Rozładowanie kontenera
refrigeratedContainer.Unload();

//Zastąpienie kontenera na statku o danym numerze innym kontenerem
cargoShip.ReplaceContainer(0, refrigeratedContainer);

CargoShip cargoShipTheSecond = new CargoShip(30, 150, 300);

//Możliwość przeniesienie kontenera między dwoma statkami
cargoShip.MoveContainerToOtherShip(1, cargoShipTheSecond);

//Wypisanie informacji o danym kontenerze
gasContainer.ShowInformation();

//Wypisanie informacji o danym statku i jego ładunku
cargoShip.ShowInformation();