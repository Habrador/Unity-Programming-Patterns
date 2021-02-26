using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.AssembleCars
{
    //Example of the Template Programming Pattern
    //Is using some code from the Factory pattern
    public class AssembleCarsController : MonoBehaviour
    {
        private void Start()
        {
            //Init the assembly lines
            AssembleCybertruck cybertruck = new AssembleCybertruck();

            AssembleModelS modelS = new AssembleModelS();


            //Assemble different orders
            cybertruck.AssembleCar(new List<CarExtras>() { CarExtras.DracoThruster, CarExtras.EjectionSeat });

            modelS.AssembleCar(new List<CarExtras>() { CarExtras.DracoThruster, CarExtras.EjectionSeat, CarExtras.EjectionSeat });

            modelS.AssembleCar();
        }

    }
}
