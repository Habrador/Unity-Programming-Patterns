# 6. State

Your game can be in a number of states. The main character can have the following states: jump, walk, run, etc. Now you want an easy way to switch between the states. This pattern is also known as a **state machine,** and if you have a finite amount of states you get a **finite state machine (FSM).**

**How to implement?**

You could use an enum that keeps track of each state and then a switch statement. The problem with the switch statement is that it becomes complicated the more states you add. A better way is to define an object for each state and then you switch between the objects as you switch states.

**When is it useful?**

- When you have too many nested if-statements, such as in a menu system. In the code, you can see an example of a menu system using the State pattern.

- Unity is using this pattern in the animation engine.
 
- When you make a turn-based combat system: [How to Code a Simple State Machine](https://www.youtube.com/watch?v=G1bd75R10m4).

- If you are making a GTA-style game. You have one state for driving, one for when the character is not in a vehicle, another state for flying, etc. Then you can also add state-of-states. For example, in the state class where the character is not in a vehicle, you can have several sub-states, such as holding nothing, holding grenade, holding pistol, etc. 

- Enemy AI is often using the State pattern. The creepers in Minecraft have three states: move randomly when you are far away, move towards you if you are closer, blow up when you are very close.

- The game itself can be a number of states: intro video, main menu, main game, mini game, etc. 

- Can be used to manage interactions between different game objects. For example, a door object can have states like open, closed, locked, and unlocked, and its behavior changes depending on its current state.

**Related patterns**

- **Type Object.** In both cases you have a main object and then you add another object to define something. The difference is that in State you switch the other object, while in Type Object that object remains the same. So if the object in Type Object can be switched you get the State pattern.

- **Strategy.** With this pattern you can give an object a new behavior (a new strategy to follow) without taking into account its current state or states coming after the current behavior.   

- **Memento.** Same as state but you can roll back to a previous state.  

- **Behavior Tree.** Is useful if you have many states and want a more complex behavior. 


## [Back](../) 