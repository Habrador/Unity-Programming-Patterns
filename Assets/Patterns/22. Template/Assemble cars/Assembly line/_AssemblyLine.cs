using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory.CarFactory;

namespace Template.AssembleCars
{
    //This is the Template class, which includes methods for how to assemble a car
    public abstract class _AssemblyLine 
    {
        //This is the template itself we want all children to use
        //A problem is that a child can hide this method because there's no way to prevent that in C#
        //Java has the final keyword that prevents that...
        public void AssembleCar(List<CarExtras> carExtras = null)
        {
            InitAssemblyProcess();

            if (!CanManuFactureCar())
            {
                return;
            }

            GetCarBase();
            GetCarBattery();
            GetCarBody();

            CoffeeBreak();

            GetWheels();
            GetCarExtras(carExtras);
        }


        //It can define concrete methods
        protected void CoffeeBreak()
        {
            Debug.Log("Take a coffee break");
        }

        protected void InitAssemblyProcess()
        {
            Debug.Log("");
        }

        protected void GetCarExtras(List<CarExtras> carExtras)
        {
            if (carExtras == null)
            {
                Debug.Log("This car comes with no extras");
            
                return;
            }
        
            foreach (CarExtras extra in carExtras)
            {
                if (extra == CarExtras.DracoThruster)
                {
                    Debug.Log("Get Draco Thruster");
                }
                else if (extra == CarExtras.EjectionSeat) 
                {
                    Debug.Log("Get Ejection Seat");
                }
            }
        }


        //..abstract methods
        protected abstract void GetCarBody();

        protected abstract void GetCarBase();

        protected abstract void GetCarBattery();

        protected abstract void GetWheels();


        //...and hooks which is a method the child can override if needed
        protected virtual bool CanManuFactureCar()
        {
            return true;
        }
    }
}
