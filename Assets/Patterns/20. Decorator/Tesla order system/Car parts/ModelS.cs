using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    public class ModelS : _Car
    {
        public ModelS()
        {
            this.description = "Model S";
        }

        public override string GetDescription() => this.description;

        public override float Cost() => PriceList.modelS;
    }
}
