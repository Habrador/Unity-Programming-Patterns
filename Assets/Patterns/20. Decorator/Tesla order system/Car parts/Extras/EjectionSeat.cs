using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    public class EjectionSeat : _CarExtras
    {
        private _Car prevCarPart;


        public EjectionSeat(_Car prevCarPart, int howMany)
        {
            this.prevCarPart = prevCarPart;
            this.howMany = howMany;
        }


        public override string GetDescription() => $"{prevCarPart.GetDescription()}, {howMany} Ejection Seat";
        

        public override float Cost() => (PriceList.ejectionSeat * howMany) + prevCarPart.Cost();
    }
}
