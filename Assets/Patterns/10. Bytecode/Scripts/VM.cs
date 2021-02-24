using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    public class VM
    {
        private GameController gameController;

        //Will store values for later use in the switch statement
        private Stack<int> stackMachine = new Stack<int>();

        //The max size of the stack
        private const int MAX_STACK = 128;



        public VM(GameController gameController)
        {
            this.gameController = gameController;
        }
        
    

        public void Interpret(int[] bytecode)
        {
            stackMachine.Clear();

            //Read and execute the instructions
            for (int i = 0; i < bytecode.Length; i++)
            {
                //Convert from int to enum
                Instruction instruction = (Instruction)bytecode[i];

                switch (instruction)
                {
                    case Instruction.INST_SET_HEALTH:
                    {
                        //Important to pop amount before wizard because we push wizard before amount onto the stack
                        int amount = Pop();
                        int wizard = Pop();
                        
                        gameController.SetHealth(wizard, amount);
                        
                        break;
                    }
                    case Instruction.INST_LITERAL:
                    {
                        ////Important that this i++ is not inside bytecode[i++] or it will not jump to next i
                        //i++;
                        //int value = bytecode[i];
                        //Push(value);

                        //this can be a oneliner
                        //in this case bytecode will use i+1 bytecode element
                        Push(bytecode[++i]);

                        break;
                    }
                    case Instruction.INST_GET_HEALTH:
                    {
                        int wizard = Pop();

                        Push(gameController.GetHealth(wizard));

                        break;
                    }
                    case Instruction.INST_ADD:
                    {
                        int b = Pop();
                        int a = Pop();
                        
                        Push(a + b);
                        
                        break;
                    }
                    default:
                    {
                        Debug.Log($"The VM couldn't find the instruction {instruction} :(");
                        break;
                    }
                }
            }
        }



        //Stack methods
        private int Pop()
        {
            if (stackMachine.Count == 0)
            {
                Debug.LogError("The stack is empty :(");
            }
        
            return stackMachine.Pop();
        }

        private void Push(int number)
        {
            //Check for stack overflow, which is useful because someone might make a mod that tries to break your game
            if (stackMachine.Count + 1 > MAX_STACK)
            {
                Debug.LogError("Stack overflow is not just a place where you copy and paste code!");
            }
        
            stackMachine.Push(number);
        }
    }
}
