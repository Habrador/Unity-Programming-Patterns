# Game programming patterns in Unity

*If you came here from Unity Tutorials, I've not finished the process to move all code to GitHub, so have patience*

A collection of programming patterns in Unity, mainly from the book [Game Programming Patterns](http://gameprogrammingpatterns.com). These are very useful to better organize your Unity project as the game grows. You don't have to use them - you should see them as tools in your toolbox. Some patterns, such as Update, Game Loop, Component, are already been built-in into Unity so you are already using them! 

Programming patterns can be divided into the following groups:
1. **Architectural patterns.** One example is the MVC (Model-View-Controller)
2. **Design patterns.** Are more specific than architectural patterns, such as the Singleton
3. **Anti-patterns.** Are a collection of patterns that many programmers are using to solve problems even though they shouldn't use them because they are ineffective solutions to a problem. Once example is a God object, most likely called GameController where you collect everything you might need

Patterns from the book Game Programming Patterns:

1. [Command](#1-command)
2. [Flyweight](#2-flyweight)
3. [Observer](#3-observer)
4. [Prototype](#4-prototype)
5. [Singleton](#5-singleton)
6. [State](#6-state)
7. [Double Buffer](#7-double-buffer)
8. [Game Loop](#8-game-loop)
9. [Update Method](#9-update-method)
10. [Bytecode](#10-bytecode)
11. [Subclass Sandbox](#11-subclass-sandbox)
12. [Type Object](#12-type-object)
13. [Component](#13-component)
14. [Event Queue](#14-event-queue)
15. [Service Locator](#15-service-locator)
16. [Data Locality](#16-data-locality)
17. [Dirty Flag](#17-dirty-flag)
18. [Object Pool](#18-object-pool)
19. [Spatial Partition](#19-spatial-partition)

Other patterns:

-

# Patterns from the book Game Programming Patterns

## 1. Command



## 2. Flyweight

This pattern is useful if you have many objects. Even though a single object takes up little memory – instantiating many of them can cause trouble.

**How to implement?** 

* Separate the data that’s not specific to a single instance of that object and can be shared across all of them. You can do that by creating a new class and put the shared data in it. Then each object that should share data gets a reference to a single instance of that "storage" class.

**When is it useful?**

* If you make Minecraft and have a million cubes in the scene. All cubes can share the same texture if you put all textures that belongs to each cube type (grass, stone, sand, etc) into a [texture atlas](https://en.wikipedia.org/wiki/Texture_atlas).

**Related patterns**

* [Type object](#12-type-object). The main difference is that in Type object you don't need to have the exact same data and you can also have behavior.   



## 3. Observer

Many things are constantly happening in your game. These things are called events (and sometimes messages). The difference between event and message is that an event has happened while a message is something that will happen. So this pattern is all about what will happen after an event has happened. Which methods should be called after you killed an enemy to update score, show death animation, etc? These methods should subscribe to the event. 

**How to implement?** 

This pattern is so popular that C# has implemented it for you. Unity also has its own implementation. So your alternatives are:

* EventHandler
* Action
* UnityEvent
* Your own implementation by using a delegate

I've implemented all these in the code, so if you don't understand the difference take a look there. 

**When is it useful?**

* This pattern is really useful if you want to avoid spaghetti code by making classes independent of each other, also known as decoupling. The best part of events is that the part that's triggering the event doesn't care which methods are attached to the event. There might be zero methods. So if an event is triggered but nothing is happening we can easier find where the bug might be.

* If you really want to decouple your code, then you still have a problem. To subscribe to the event you need a reference to the script where the event is defined. Another way is to create an Event Manager, which is a global class that takes care of all events. Unity has its own tutorial on how to implement that: [Creating a Simple Messaging System](https://www.youtube.com/watch?v=0AqG1fDhPT8).

* Another way to decouple the code is to make the event static. An example of a static event is available in the code.  

**Related patterns**

* [Event queue](#14-event-queue). The biggest problem with Observer is that it will trigger all methods that subscribe to the event. So if five methods subscribe, then five methods will be triggered. But what if 10 enemies are killed at the same time, then 50 methods will be triggered at the same time, which may freeze your game. This is when you should use the Event queue, which is basically the same as the Observer, but you put the events in a queue and you trigger as many as you can without freezing the game.

* Model-View-Controller (MVC). The MVC is an architectural pattern, and to implement it you can use the Observer.    



## 4. Prototype

In your game you have a game object. Now you want to duplicate that object to create another object. This pattern allows you to create as many duplicates of an object as you want.

**How to implement?**

* This is a pattern that already exists in Unity in the form of the [Instantiate-method](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html). But it assumes that the object you want to duplicate inherits from Object, which is a class in UnityEngine.

* You could also make you own implementation. But then you have to ask yourself: do you do a deep clone (a copy of the structure and the elements in the structure) or a shallow clone (a copy of the structure not the elements in the structure)? Maybe the Flyweight pattern can give you the answer?    

**When is it useful?**

* If you have a gun that fires bullets. You add one bullet prefab to the script. Each time you fire the gun you need a new bullet because you don't want to use the original bullet, so you call Unity's Instantiate-method and you get a duplicate of the original bullet.

**Related patterns**

* Factory. The main difference is that in the Factory you can also add stuff to the objects - not just duplicate them. So you can put the Prototype inside of the Factory. 

* [Object pool](#18-object-pool). If you Instantiate and destroy many game objects, it will affect the performance of the game. To solve that problem you can use the Object pool pattern. 



## 5. Singleton



## 6. State

Your game can be in a number of states. For example, the main character can have the following states: jump, walk, run, etc. Now you want an easy way to switch between the states. This pattern is also known as a **state machine**, and if you have a finite amount of states you get a **finite state machine (FSM)**.

**How to implement?**

* You could use an enum that keeps track of each state and then a switch statement.
* The problem with the switch statement is that it tends to become complicated the more states you add. A better way is to define an object for each state and then you switch between the objects as you switch states.

**When is it useful?**

* When you have too many nested if-statements, such as in a menu system. In the code, you can see an example of a menu system that uses this pattern.
* Unity is using this pattern in the animation engine. 
* When you make a turn-based combat system: [How to Code a Simple State Machine](https://www.youtube.com/watch?v=G1bd75R10m4).



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


# Other patterns

-