using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    public class Cybertruck : _Car
    {
        public Cybertruck()
        {
            this.description = "Cybertruck";
        }

        public override string GetDescription() => this.description;

        public override float Cost() => PriceList.cybertruck;
    }
}
