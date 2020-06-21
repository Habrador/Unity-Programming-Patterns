using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    //The point of this command is to do nothing
    //Is used instead of setting a command to null, so it's called Null Object, which is another programming pattern 
    public class DoNothingCommand : Command
    {
        public override void Execute()
        {
            
        }

        public override void Undo()
        {
            
        }
    }
}
