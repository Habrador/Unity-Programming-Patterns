using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.AssembleCars
{
    public class AssembleModelS : _AssemblyLine
    {
        protected override void GetCarBase()
        {
            Debug.Log("Get Model S base");
        }

        protected override void GetCarBattery()
        {
            Debug.Log("Get Model S battery");
        }

        protected override void GetCarBody()
        {
            Debug.Log("Get Model S body");
        }

        protected override void GetWheels()
        {
            Debug.Log("Get Model S wheels");
        }
    }
}
