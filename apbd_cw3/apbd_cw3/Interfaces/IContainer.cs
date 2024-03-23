using apbd_cw3.Containers;

namespace apbd_cw3.Interfaces;

public interface IContainer
{
    void Unload();
    void Load(Products product, double cargoWeight);
}