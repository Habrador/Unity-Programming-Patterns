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
        
        //The keys we have that are also connected to commands
        private Command buttonW;
        private Command buttonA;
        private Command buttonS;
        private Command buttonD;

        //Store the commands here to make undo, redo, replay easier
        //The book is using one list and an index
        //private List<Command> oldCommands = new List<Command>();
        //Start at -1 because in the beginning we haven't added any commands
        //private int currentCommandIndex = -1;
        //But I think its easier to use two Stacks
        //When replay, we convert the undo stack to an array
        private Stack<Command> undoCommands = new Stack<Command>();
        private Stack<Command> redoCommands = new Stack<Command>();

        private bool isReplaying = false;

        //To make replay work we need to know where the object started
        private Vector3 startPos;

        //The time between each command execution when we replay so we can see what's going on
        private const float REPLAY_PAUSE_TIMER = 0.5f;



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
            //We can check for input while we are replaying
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
                ExecuteNewCommand(buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(buttonD);
            }
            //Undo with u (ctrl + z is sometimes interfering with the editor's undo system)
            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (undoCommands.Count == 0)
                {
                    Debug.Log("Can't undo because we are back where we started");
                }
                else
                {
                    Command lastCommand = undoCommands.Pop();

                    lastCommand.Undo();

                    //Add this to redo if we want to redo the undo
                    redoCommands.Push(lastCommand);
                }
            }
            //Redo with r
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (redoCommands.Count == 0)
                {
                    Debug.Log("Can't redo because we are at the end");
                }
                else
                {
                    Command nextCommand = redoCommands.Pop();

                    nextCommand.Execute();

                    //Add to undo if we want to undo the redo
                    undoCommands.Push(nextCommand);
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
            //Move the object back to where it started
            objectThatMoves.transform.position = startPos;

            //Pause so we can see that it has started at the start position
            yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);

            //Convert the undo stack to an array
            Command[] oldCommands = undoCommands.ToArray();
            
            //This array is inverted so we iterate from the back
            for (int i = oldCommands.Length - 1; i >= 0; i--)
            {
                Command currentCommand = oldCommands[i];

                currentCommand.Execute();

                yield return new WaitForSeconds(REPLAY_PAUSE_TIMER);
            }

            isReplaying = false;
        }



        //Will execute the command and do stuff to the list to make the replay, undo, redo system work
        private void ExecuteNewCommand(Command commandButton)
        {
            commandButton.Execute();

            //Add the new command to the last position in the list
            undoCommands.Push(commandButton);

            //Remove all redo commands because redo is not defined when we have add a new command
            redoCommands.Clear();
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
