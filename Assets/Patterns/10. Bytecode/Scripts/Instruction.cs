using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    //These are the instrusctions we can choose from in our programming language
    public enum Instruction
    {
        //Write stats
        INST_SET_HEALTH,
        INST_SET_WISDOM,
        INST_SET_AGILITY,
        INST_PLAY_SOUND,
        INST_SPAWN_PARTICLES,
        //So we can use parameters
        INST_LITERAL,
        //Read stats
        INST_GET_HEALTH,
        INST_GET_WISDOM,
        INST_GET_AGILITY,
        //Arithmetic
        INST_ADD
    }
}
