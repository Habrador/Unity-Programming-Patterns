using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    //Command pattern rebind keys example from the book "Game Programming Patterns"
    //Is also including undo, redo, and replay system
    public class GameController : MonoBehaviour
    {
        public MoveObject objectThatMoves;
        
        //The keys we have
        private Command buttonW;
        private Command buttonA;
        private Command buttonS;
        private Command buttonD;

        //Store the commands here to make undo, redo, replay easier
        private List<Command> oldCommands = new List<Command>();
        //Start at -1 because in the beginning we haven't added any commands
        private int currentCommandIndex = -1;

        private bool isReplaying = false;

        //To make replay work we need to know where the object started
        private Vector3 startPos;



        void Start()
        {
            //Bind the keys to default commands
            buttonW = new MoveForwardCommand(objectThatMoves);
            buttonA = new TurnLeftCommand(objectThatMoves);
            buttonS = new MoveBackCommand(objectThatMoves);
            buttonD = new TurnRightCommand(objectThatMoves);

            startPos = objectThatMoves.transform.position;
        }



        void Update()
        {
            if (isReplaying)
            {
                return;
            }
            
            //We will here jump in steps to make the undo system easier
            //If we were moving with speed * Time.deltaTime, the undo system would be more comlicated to implement.
            //When we undo, the Time.deltaTime may be different so we end up at another position than we previously had
            //You could solve this by saving the Time.deltaTime somewhere
            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteCommand(buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteCommand(buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteCommand(buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteCommand(buttonD);
            }
            //Undo with u (ctrl + z is sometimes interfering with the editor's undo system)
            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (currentCommandIndex == -1)
                {
                    Debug.Log("Can't undo because we are back where we started");
                }
                else
                {
                    Command lastCommand = oldCommands[currentCommandIndex];

                    lastCommand.Undo();

                    currentCommandIndex -= 1;
                }
            }
            //Redo with r
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentCommandIndex == oldCommands.Count - 1)
                {
                    Debug.Log("Can't redo because we are at the end");
                }
                else
                {
                    Command nextCommand = oldCommands[currentCommandIndex + 1];

                    nextCommand.Execute();

                    currentCommandIndex += 1;
                }
            }


            //Rebind keys by just swapping A and D buttons
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ref is important or the keys will not be swapped
                SwapKeys(ref buttonA, ref buttonD);
            }


            //Start replay
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(Replay());

                isReplaying = true;
            }
        }



        //Replay
        private IEnumerator Replay()
        {
            objectThatMoves.transform.position = startPos;
        
            for (int i = 0; i < oldCommands.Count; i++)
            {
                Command currentCommand = oldCommands[i];

                currentCommand.Execute();

                yield return new WaitForSeconds(0.5f);
            }

            //Is used if oldCommands length is 0, then we never reach isReplaying = false;
            yield return new WaitForSeconds(0.01f);

            isReplaying = false;

            //Now we are always at the end of the list, so make sure the currentCommandIndex is there as well
            currentCommandIndex = oldCommands.Count - 1;
        }



        //Will execute the command and do stuff to the list to make the replay, undo, redo system work
        private void ExecuteCommand(Command commandButton)
        {
            commandButton.Execute();

            //First we have to remove all commands that may be in the list after the current command
            if (oldCommands.Count > 0)
            {
                //We earlier stored them from redo, but that shouldn't be possible now because we added a new command and should just be able to undo
                oldCommands.RemoveRange(currentCommandIndex + 1, oldCommands.Count - (currentCommandIndex + 1));
            }

            //Add the new command to the last position in the list
            oldCommands.Add(commandButton);

            //The current command index is now the last position in the list
            currentCommandIndex = oldCommands.Count - 1;
        }



        //Swap the pointers to two commands
        private void SwapKeys(ref Command key1, ref Command key2)
        {
            Command temp = key1;

            key1 = key2;
            
            key2 = temp;
        }
    }
}
