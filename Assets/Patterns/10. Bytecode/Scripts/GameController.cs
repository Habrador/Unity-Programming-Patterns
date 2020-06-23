using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    //Bytecode code pattern from the book "Game Programming Patterns"
    public class GameController : MonoBehaviour
    {
        
        
        void Start()
        {
            //Test
            int[] bytecode = new int[]
            {
                (int)Instruction.INST_LITERAL, 0, //wizard id
                (int)Instruction.INST_LITERAL, 75, //amount
                (int)Instruction.INST_SET_HEALTH
            };

            VM vm = new VM(gameController: this);

            vm.Interpret(bytecode);
        }


        void Update()
        {

        }



        //0 means the player's wizard and 1, 2, ... means the other wizards in the game
        //This way we can heal our own wizard while damage other wizards with the same method
        public void SetHealth(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets health {amount}");
        }

        public void SetWizdom(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets wisdom {amount}");
        }

        public void SetAgility(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets agility {amount}");
        }

        public void PlaySound(int soundID)
        {
            Debug.Log($"Play sound {soundID}");
        }

        public void SpawnParticles(int particleType)
        {
            Debug.Log($"Spawn particle {particleType}");
        }

        public int GetHealth(int wizardID)
        {
            return 50;
        }
    }
}
