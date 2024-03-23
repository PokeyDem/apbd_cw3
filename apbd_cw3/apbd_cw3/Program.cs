// See https://aka.ms/new-console-template for more information


using apbd_cw3;
using apbd_cw3.Containers;

LiquidContainer lc1 = new LiquidContainer(0.0, 3.0, 5.0, 10.0, 5.0);
lc1.ShowInfo();
lc1.Load(Products.Fuel, 1);
lc1.ShowInfo();
lc1.Unload();
lc1.ShowInfo();

GasContainer sc1 = new GasContainer(0.0, 3.0, 5.0, 5.0, 5.0);
sc1.ShowInfo();
sc1.Load(Products.Helium, 1);
sc1.ShowInfo();
sc1.Unload();
sc1.ShowInfo();

RefrigeratedContainer rc1 = new RefrigeratedContainer(0.0, 3.0, 4.0, 4.0, 5.0, 5);
rc1.ShowInfo();
rc1.Load(Products.Meat, 1);
rc1.ShowInfo();
rc1.Unload();
rc1.ShowInfo();

// var container = new Container(10.0,10.0)
// {
//     CargoWeight = 12.0
// };
//super() in java = base() in C#