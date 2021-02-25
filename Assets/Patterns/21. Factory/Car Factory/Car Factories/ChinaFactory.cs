using System.Collections;
using System.Collections.Generic;
using Decorator.OrderSystem;
using UnityEngine;

namespace Factory.CarFactory
{
    public class ChinaFactory : _CarFactory
    {
        public override _Car ManufactureCar(CarModels carModel, List<CarExtras> carExtras)
        {
            _Car car = null;

            if (carModel == CarModels.ModelS)
            {
                car = new ModelS();
            }
            else if (carModel == CarModels.Roadster)
            {
                car = new Roadster();
            }

            //Notice that the Cybertruck is missing here, so we cant manufacture it!
            if (car == null)
            {
                Debug.Log("Sorry but this factory cant manufacture this model :(");
            
                return car;
            }


            //Add the extras
            foreach (CarExtras carExtra in carExtras)
            {
                if (carExtra == CarExtras.DracoThruster)
                {
                    car = new DracoThruster(car, 1);
                }
                else if (carExtra == CarExtras.EjectionSeat)
                {
                    car = new EjectionSeat(car, 1);
                }
                else
                {
                    Debug.Log("Sorry but this factory cant add this car extra :(");
                }
            }

            return car;
        }
    }
}
