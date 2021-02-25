using System.Collections;
using System.Collections.Generic;
using Decorator.OrderSystem;
using UnityEngine;

namespace Factory.CarFactory
{
    public class USFactory : _CarFactory
    {
        public override _Car ManufactureCar(CarModels carModel, List<CarExtras> carExtras)
        {
            _Car car = null;

            if (carModel == CarModels.Cybertruck)
            {
                car = new Cybertruck();
            }
            else if (carModel == CarModels.ModelS)
            {
                car = new ModelS();
            }
            else if (carModel == CarModels.Roadster)
            {
                car = new Roadster();
            }

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
                //Ejection seats are not legal in US so cant manufacture it (but we will still manufacture the rest of the car)
                else
                {
                    Debug.Log("Sorry but this factory cant add this car extra :(");
                }
            }

            return car;
        }
    }
}
