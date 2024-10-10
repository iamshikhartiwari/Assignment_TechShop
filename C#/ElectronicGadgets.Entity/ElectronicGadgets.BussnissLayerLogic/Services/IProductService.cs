using System;
using ElectronicGadgets.Models;

namespace ElectronicGadgets.BussnissLayerLogic.Repository;


    internal interface IProductService
    {
        void GetProductDetails(Products product);
        void UpdateProductInfo(Products product, string newDescription, decimal newPrice);
        bool IsProductInStock(Products product, Inventory inventory);
        
    }
