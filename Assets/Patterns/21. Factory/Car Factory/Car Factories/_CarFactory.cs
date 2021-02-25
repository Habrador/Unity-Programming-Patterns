using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Decorator.OrderSystem;

namespace Factory.CarFactory
{
    public abstract class _CarFactory 
    {
        //This method is called the Factory Method 
        public abstract _Car ManufactureCar(CarModels carModel, List<CarExtras> carExtras);
    }
}
