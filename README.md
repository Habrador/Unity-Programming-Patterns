# Game programming patterns in Unity

A collection of programming patterns in Unity, mainly from the book [Game Programming Patterns](http://gameprogrammingpatterns.com/contents.html). These are very useful to better organize your Unity project as the game grows. You don't have to use them - you should see them as tools in your toolbox. Some patterns, such as Update and Game Loop, are already been built-in into Unity so you have to use them! 

Programming patterns can be divided into the following groups:
1. **Architectural patterns.** One example is the MVC (Model-View-Controller)
2. **Design patterns.** Are more specific than architectural patterns, such as the Singleton
3. **Anti-patterns.** Are a collection of patterns that many programmers are using to solve problems even though they shouldn't use them because they are ineffective solutions to a problem. Once example is a God object, most likely called GameController where you collect everything you might need


## 1. Command


## 2. Flyweight


## 3. Observer


## 4. Prototype

**What is it?** 

In your game you have a game object. Now you want to duplicate the object to create another object. This pattern allows you to create as many duplicates of an object as you want.

**How to implement?**

* This is a pattern that already exists in Unity in the form of the [Instantiate-method](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html).
* You could also make you own implementation. But then you have to ask yourself: do you do a deep clone (a copy of the structure and the elements in the structure) or a shallow clone (a copy of the structure not the elements in the structure)? Maybe the Flyweight pattern can give you the answer?    

**When is it useful?**

* If you have a gun that fires bullets. You add one bullet prefab to the script. Each time you fire the gun you need a new bullet because you don't want to use the original bullet, so you call Unity's Instantiate-method and you get a duplicate of the original bullet.

**Related patterns**

* Factory. The main difference is that in the Factory you can also add stuff to the objects - not just duplicate them. So you can put the Prototype inside of the Factory. 
* Object pool. If you Instantiate and destroy many game objects, it will affect the performance of the game. To solve that problem you can use the Object pool pattern. 


## 5. Singleton


## 6. State

**What is it?** 

Your game can be in a number of states. For example, the main character can have the following states: jump, walk, run, etc. Now you want an easy way to switch between the states. This pattern is also known as a **state machine**, and if you have a finite amount of states you get a **finite state machine (FSM)**.

**How to implement?**

* You could use an enum that keeps track of each state and then a switch statement.
* The problem with the switch statement is that it tends to become complicated the more states you add. A better way is to define an object for each state and then you switch between the objects as you switch states.

**When is it useful?**

* When you have too many nested if-statements, such as in a menu system. In the code, you can see an example of a menu system that uses this pattern.
* Unity is using this pattern in the animation engine. 
* When making a turn-based combat system: [How to Code a Simple State Machine](https://www.youtube.com/watch?v=hpg5wshAqV8)


## 7. Double Buffer


## 8. Game Loop


## 9. Update Method


## 10. Bytecode


## 11. Subclass Sandbox


## 12. Type Object


## 13. Component


## 14. Event Queue


## 15. Service Locator


## 16. Data Locality


## 17. Dirty Flag


## 18. Object Pool


## 19. Spatial Partition

