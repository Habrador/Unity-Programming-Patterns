using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decorator.OrderSystem
{
    //Decorator programming pattern example
    public class OrderSystemController : MonoBehaviour
    {
        private void Start()
        {
            //Order 1
            _Car roadster = new Roadster();

            roadster = new DracoThruster(roadster, 5);

            Debug.Log($"You ordered: {roadster.GetDescription()} and have to pay ${roadster.Cost()}");

            //Order 2
            _Car cybertruck = new Cybertruck();

            cybertruck = new DracoThruster(cybertruck, 2);
            cybertruck = new EjectionSeat(cybertruck, 1);

            Debug.Log($"You ordered: {cybertruck.GetDescription()} and have to pay ${cybertruck.Cost()}");

            //Order 3
            _Car modelS = new ModelS();

            Debug.Log($"You ordered: {modelS.GetDescription()} and have to pay ${modelS.Cost()}");



            //Some time passes while you wait for your order and Elon Musk finds a cheap way to manufacture the Cybertruck
            PriceList.cybertruck -= 50f;
            //But the price of ejections seats goes up
            PriceList.ejectionSeat += 30f;

            Debug.Log("Price changes!");

            Debug.Log($"You ordered: {roadster.GetDescription()} and have to pay ${roadster.Cost()}");
            Debug.Log($"You ordered: {cybertruck.GetDescription()} and have to pay ${cybertruck.Cost()}");
            Debug.Log($"You ordered: {modelS.GetDescription()} and have to pay ${modelS.Cost()}");
        }
    }
}
