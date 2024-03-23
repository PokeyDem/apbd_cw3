// See https://aka.ms/new-console-template for more information
using apbd_cw3;
using apbd_cw3.Containers;
using apbd_cw3.Ships;

Console.WriteLine("");

LiquidContainer lq1 = new LiquidContainer(1,2,3,4,5);
lq1.Load(Products.Milk, 1);

CargoShip cargoShip = new CargoShip(10, 20);

cargoShip.LoadContainer(lq1);

RefrigeratedContainer rc1 = new RefrigeratedContainer(1, 4, 5, 6, 7, 10);
rc1.Load(Products.Butter, 3);

cargoShip.LoadContainer(rc1);
cargoShip.ShowInformation();

cargoShip.UnloadContainer(lq1);
cargoShip.ShowInformation();

rc1.ShowInformation();