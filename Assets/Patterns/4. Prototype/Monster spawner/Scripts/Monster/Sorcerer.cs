using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.MonsterSpawner
{
    public class Sorcerer : _Monster
    {
        private int health;
        private int speed;

        private static int sorcererCounter = 0;

        public Sorcerer(int health, int speed)
        {
            this.health = health;
            this.speed = speed;

            sorcererCounter += 1;
        }

        public override _Monster Clone()
        {
            return new Sorcerer(health, speed);
        }

        public override void Talk()
        {
            Debug.Log($"Hello this is Sorcerer number {sorcererCounter}. My health is {health} and my speed is {speed}");
        }
    }
}
