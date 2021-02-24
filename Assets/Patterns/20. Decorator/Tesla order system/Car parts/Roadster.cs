using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    public class Roadster : _Car
    {
        public Roadster()
        {
            this.description = "Roadster";
        }

        public override string GetDescription() => this.description;

        public override float Cost() => PriceList.roadster;
    }
}
