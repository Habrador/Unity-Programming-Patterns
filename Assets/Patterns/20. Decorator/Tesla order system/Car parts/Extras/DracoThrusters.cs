using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    //Tesla is actually planning to put SpaceX Draco Thrusters on the Roadster to increase the performance so this class is not a lie!
    public class DracoThruster : _CarExtras
    {
        private _Car prevCarPart;


        public DracoThruster(_Car prevCarPart, int howMany)
        {
            this.prevCarPart = prevCarPart;
            this.howMany = howMany;
        }


        public override string GetDescription() => $"{prevCarPart.GetDescription()}, {howMany} Draco Thruster";
        

        public override float Cost() => (PriceList.dracoThruster * howMany) + prevCarPart.Cost();
    }
}
