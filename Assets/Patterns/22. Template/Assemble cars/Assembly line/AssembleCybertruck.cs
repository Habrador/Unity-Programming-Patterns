using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.AssembleCars
{
    public class AssembleCybertruck : _AssemblyLine
    {    
        protected override void GetCarBase()
        {
            Debug.Log("Get Cybertruck base");
        }

        protected override void GetCarBattery()
        {
            Debug.Log("Get Cybertruck battery");
        }

        protected override void GetCarBody()
        {
            Debug.Log("Get Cybertruck body");
        }

        protected override void GetWheels()
        {
            Debug.Log("Get Cybertruck wheels");
        }

        protected override bool CanManuFactureCar()
        {
            Debug.Log("Sorry but the Cybertruck is still a prototype so we can't manufacture it!");
        
            return false;
        }
    }
}
