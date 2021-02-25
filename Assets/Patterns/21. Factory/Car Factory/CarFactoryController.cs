using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory.CarFactory;
using Decorator.OrderSystem;

//Example of the Factory Programming Pattern
//Uses classes from Decorator pattern order system example
public class CarFactoryController : MonoBehaviour
{
    
    void Start()
    {
        //The factories we can choose from
        _CarFactory US_Factory = new USFactory();

        _CarFactory China_Factory = new ChinaFactory();


        //Manufacture cars
        _Car order1 = US_Factory.ManufactureCar(CarModels.ModelS, new List<CarExtras>() { CarExtras.DracoThruster });

        FinalizeOrder(order1);


        _Car order2 = China_Factory.ManufactureCar(CarModels.Cybertruck, new List<CarExtras>() { CarExtras.DracoThruster });

        FinalizeOrder(order2);


        _Car order3 = US_Factory.ManufactureCar(CarModels.Roadster, new List<CarExtras>() { CarExtras.DracoThruster, CarExtras.EjectionSeat, CarExtras.DracoThruster });

        FinalizeOrder(order3);
    }

    
	
    private void FinalizeOrder(_Car finishedCar)
    {
        if (finishedCar == null)
        {
            Debug.Log($"Sorry but we cant manufacture your order, please try again!");
        }
        else
        {
            Debug.Log($"Your order: {finishedCar.GetDescription()} is ready for delivery as soon as you pay ${finishedCar.Cost()}");
        }
    }
}


public enum CarModels
{
    ModelS,
    Roadster,
    Cybertruck
}

public enum CarExtras
{
    EjectionSeat,
    DracoThruster
}
