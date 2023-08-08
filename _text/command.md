# 1. Command

In you game you have many commands, such as play sound, throw cake, etc. It can be useful to wrap them in a command object. Now the command object doesn't have to care about how the command is executed. 

**How to implement?**

You have a base class called Command which has a method that a child can implement called Execute. In each child class, you put in the Execute method what will actually happen when you run (execute) that command.  

**When is it useful?**

- To rebind keys. Example of this is available in the code section. 

- To make a replay system. When you play the game, you store in some data structure which button you pressed each update. When you want to replay what has happened, you just iterate through each command while running the game. Example of this is available in the code section. 

- To make an undo and redo system. Is similar to the replay system, but in each command you also have a method called Undo() where you do the opposite of what the command is doing. Example of this is available in the code section.

- To encapsulate AI behaviors and actions. Each AI behavior can be represented as a command, making it easier to control and update AI actions during gameplay.

- To define the sequence of actions to be executed during events or cutscenes in games.

- To manage and apply different abilities, power-ups, or effects during gameplay.

- To manage event handling by encapsulating event-specific actions as commands and executing them when the corresponding events occur.

- To simplify network communication In multiplayer games. Game commands can be serialized and sent over the network to synchronize actions among different players.

**Related patterns**

- **Subclass Sandbox.** You may end up with many child-command-classes. To easier handle the code, you can define high-level methods in the parent.

- **Memento.** With this pattern you can also return to a previous state.


## [Back](../)