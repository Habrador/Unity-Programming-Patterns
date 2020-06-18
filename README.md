# Game programming patterns in Unity

*If you came here from Unity Tutorials, I've not finished the process to move all code to GitHub, so have patience*

A collection of programming patterns in Unity, mainly from the book [Game Programming Patterns](http://gameprogrammingpatterns.com). These are very useful to better organize your Unity project as the game grows. You don't have to use them - you should see them as tools in your toolbox. Some patterns, such as Update, Game Loop, Component, are already been built-in into Unity so you are already using them! 

Programming patterns can be divided into the following groups:
1. **Architectural patterns.** One example is the MVC (Model-View-Controller)
2. **Design patterns.** Are more specific than architectural patterns, such as the Singleton
3. **Anti-patterns.** Are a collection of patterns that many programmers are using to solve problems even though they shouldn't use them because they are ineffective solutions to a problem. Once example is a God object, most likely called GameController where you collect everything you might need

Patterns from the book Game Programming Patterns:

1. ~~[Command](#1-command)~~
2. [Flyweight](#2-flyweight)
3. [Observer](#3-observer)
4. [Prototype](#4-prototype)
5. ~~[Singleton](#5-singleton)~~
6. [State](#6-state)
7. ~~[Double Buffer](#7-double-buffer)~~
8. ~~[Game Loop](#8-game-loop)~~
9. ~~[Update Method](#9-update-method)~~
10. ~~[Bytecode](#10-bytecode)~~
11. [Subclass Sandbox](#11-subclass-sandbox)
12. [Type Object](#12-type-object)
13. [Component](#13-component)
14. ~~[Event Queue](#14-event-queue)~~
15. [Service Locator](#15-service-locator)
16. ~~[Data Locality](#16-data-locality)~~
17. [Dirty Flag](#17-dirty-flag)
18. [Object Pool](#18-object-pool)
19. ~~[Spatial Partition](#19-spatial-partition)~~

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

**Related patterns**

* [Type Object](#12-type-object). In both cases you have a main object and then you add another object to define something. The difference is that in State you switch the other object, while in Type Object that object remains the same. So if the object in Type Object can be switched you get the State pattern.
     


## 7. Double Buffer


## 8. Game Loop


## 9. Update Method


## 10. Bytecode


## 11. Subclass Sandbox

You have similar objects but they have different behavior. Create those behaviors in the child class by combining methods defined in the parent class.

**How to implement?**

* Define several protected methods in the parent class. In the child class, you combine the methods inside a method called Activate.

**When is it useful?**

* When your child classes share behavior and the parent class can provide these behaviors. For example if you are using superpowers and the child class can combine these superpowers. This is an example from the book so you can find the code in the code section.  

**Related patterns**

* [Update Method](#9-update-method). The Update Method is often implemented as a Sandbox method.

* [Type Object](#12-type-object). Instead of defining all methods in the parent you could give the child a reference to an object that defines these methods.  



## 12. Type Object

You have an object and now you want to change its type (such as behavior or some data) by giving it a reference to an object that defines the type, thus the name Type Object. Another way could be to use class inheritance to define a child class which includes to code for the type, but that's not always possible because different children may be of the same type.  

**How to implement?**

* The Type Objects should share the same interface (or parent) to make it easier for the main class to reference the object.        

**When is it useful?**

* When you can't (or don't want to) use class inehritance. Let's say you make a game with animals. You have a base class which is parent to all animals, and then as children to that class you add birds, fish, and mammals. In the bird class you define a flying behavior, which is all fine until you add an ostrich, which can't fly. In that case you have to inherit from the bird class and create new children that can fly and can't fly. But what about bats, which is a mammal that can fly? You don't want to add flying behavior in two separate classes! A better way is to define a flying and a non-flying type in a separate class, so both ostriches remain on the ground and bats can fly.  

**Related patterns**

* [State](#6-state). In both cases you have a main object and then you add another object to define something. The difference is that in State you switch the other object, while in Type Object that object remains the same. So if the type can be switched you get the State pattern.
 
* [Subclass Sandbox](#11-subclass-sandbox). You could define all types in the parent class and then combine them in the child class. 
 
* [Component](#13-component). The difference is that the Component is not always coupled with something else on the game object – it’s living its own life. In Unity you can add colliders, scripts, mesh renderers and they don’t need to know about each other to function. Type Object, however, is about adding a behavior to an existing class, so the type can't live on its own. 



## 13. Component

When making a big game you should start thinking in components. A component is similar to your computer mouse, which you can attach to whatever computer you want through a USB port and it works fine. So a component is an object that's independent of other objects, making it reusable, and you can attach the component to several other objects if you want those objects to get the behavior described by the component. But in reality, some components have to communicate with each other, so they can't be entirely independent of each other: The mouse is communicating with the computer, but it's not communicating with the printer.   

**How to implement?**

* In Unity you can attach components to GameObjects, such as colliders, mesh renderers, your own scripts, so it's already built-in. It's up to you to make the custom scripts you attach as reusable as possible.

**When is it useful?**

* Because Unity's FPS counter is not to be trusted, you can have a custom FPS counter that you re-use throughout all projects. Just add the script to the project and attach it to some GameObject and it works fine independently of everything else going on in the game.

* When making a car game you can put physics in one script, such as drag and rolling resistance, becuse physics will always affect the car and the physics calculations are the same for all cars. This component will not be completely independent because it will need some data from the car, such as current speed, but as said before that's fine. 

**Related patterns**  

* [Type Object](#12-type-object). The difference is that the Component is not always coupled with something else on the game object – it’s living its own life. In Unity you can add colliders, scripts, mesh renderers and they don’t need to know about each other to function. Type Object, however, is about adding a behavior to an existing class, so the type can't live on its own.



## 14. Event Queue


## 15. Service Locator

When making your game you use many standardized methods to for example generate random numbers. These are called services and should be accessible from everywhere (globally) but still be independet from your game's main code.   

**How to implement?**

* Put each service in a static class. The static class should be in its own folder and have its own namespace to make sure you are not mixing the services with your main code.

* A slightly more complicated way is to use a service locator that provides access to a service provider. To make sure no other methods than the ones you need are exposed to the outside world, the service provider should limit which methods it can provide access to.   

* Unity has implemented this pattern in the form of the GetComponent() method.

**When is it useful?**

* Several services are already built-in into Unity, such as Random.Range() to get a random number, Mathf.PI to get pi, and Debug.Log() to display something in the console.

* In the game you may have different audio objects depending on if the game is running on a console or on a PC. This is the same example as in the book so you can find the code for it in the code section.  

**Related patterns** 

* [Singleton](#5-singleton). Both provide a global access to an object. So the problems with the Singleton also applies to this pattern.  



## 16. Data Locality


## 17. Dirty Flag

This pattern is useful if something has changed in your game, and if so you have to run a costly operation. A Dirty Flag is used to tell that something has changed but the costly operation hasn't been activated.   

**How to implement?**

* The dirty flag is just a simple boolean, which is set to true if something has changed.

**When is it useful?**

* Saving your game can be a costly operation. If something in your game has changed that also needs to be saved, you set a Dirty Flag in the save game object to true. Now if the player wants to quit the game, you can easily tell the player that there are unsaved changes.

* If you ever done some editor scripting in Unity, you know that you can use SetDirty() to mark an object as dirty or you can even mark the entire scene as dirty. Now Unity will understand that you have changed something and those changes should be saved when you save your scene.

* Unity is using it in the physics system. A RigidBody doesn't have to be updated unless a force is applied to it. If the RigidBody is sleeping (not moving), a Dirty Flag is used so the physics system can ignore it.      



## 18. Object Pool

If you constantly create and destroy objects, the performance of your game will suffer. A better way is to create the objects once in the beginning and deactivate them. When you need an object, you pick one of the deactivate objects and activate it. When you don't need the object anymore, you deactivate it instead of destroying it.   

**How to implement?**

* Create a class called object pool. Give it an object prefab and instantiate the number of objects you think you will need. Store them in a list. When you need an object you search through the list for a deactivated object and returns the first you find. If you realize you need more objects than the objects you started with, you have a few choises: 

	* You can instantiate more objects during gameplay. But make sure you don't instantiate too many objects because it will be a waste of memory. You could later remove the "extra" objects you added.  

	* Find one of the objects that's active but the player will not notice if it suddeny disappears so you can use it.

	* Ignore that you have no more objects, which may be fine. If the screen is filled with explosions, the player will not notice a new explosion is missing.

* If the objects you pool reference another object which is destroyed, then it's important to clear this reference when the object in the pool is deactivated. Otherwise the garbage collector will not be able to do its work on the destroyed object because it's still referenced by a living object.

* One problem with storing objects in a list and search the list to find an avilable object is that the list may be very long, so it's a waste of time. Another way is to store the objects in the pool in a linked-list.   

**When is it useful?**

* The most common example is when you fire bullets from a gun, then you will need many bullets. I've given an example of this in the code section. You can find two versions: the optimized version which uses a linked-list, and the slow version which has to search a list to find an available bullet. 

* Unity is using this pattern in their particle system. In the particle settings you can set max number of particles, which can be useful so you don't accidentally instantiate millions of particles.      

**Related patterns** 

* [Data Locality](#16-data-locality). In this pattern we pack objects of the same type together in memory. It will help the CPU cache to be full as the game iterates over those objects, which is what the Data Locality patterns is about.



## 19. Spatial Partition

If you have many objects in your game, store the objects in a data structure that organizes the objects by their positions. This should make it faster to for example find the closest object.  

**How to implement?**  

This is a common pattern, so you have several choices:

* **Grid.** Divide the area into a grid and store in the data structure in which cell each object is located. This is the example from the book, so you can find the code for it in the code section. The problem with this solution is that it will be difficult to find the closest object - we can only find the closest object in the same or in the 8 surrounding cells. What if they are all empty? But this may be fine if we say that we don't care about those objects if they are too far away anyway. Another way is to use a flood-fill algorithm that floods the grid until we find a cell with an object in it.   

* **Trie.** Is actually called [Trie](https://en.wikipedia.org/wiki/Trie) and not Tree! 
	* [Quadtree (2d space)](https://en.wikipedia.org/wiki/Quadtree). Divide the square area into 4 cells. But if too many objects are in the same cell, divide that cell into 4 new cells. Continue until there are not "too many objects in the same cell." A good tutorial can be found here: [Coding Challenge #98.1: Quadtree - Part 1](https://www.youtube.com/watch?v=OJxEcs0w_kE).
	* [Octree (3d space)](https://en.wikipedia.org/wiki/Octree). Is similar to Quadtree, but instead of cells you use cubes, so divide a cube volume into 8 cubes, and then split each cube into 8 new cubes until not "too many objects are in the same cube."

* **Binary search trees.** The name is binary, so the difference between Tree is that you split the groups into 2 smaller groups, and then you split one of the smaller groups into 2 smaller groups, and so on.  
	* [Binary space partition (BSP)](https://en.wikipedia.org/wiki/Binary_space_partitioning). You use a plane to split a group into 2 new groups. And then you use another plane to split the new group into 2 new groups, and so on until you are finished.  
	* [k-d trees](https://en.wikipedia.org/wiki/K-d_tree). In this case it has to be points that you split into smaller, and smaller groups. 
	* [Bounding volume hierarchy](https://en.wikipedia.org/wiki/Bounding_volume_hierarchy). You pick a bounding volume (or area in 2d space), such as a rectangle. The size of the first rectangle is determined so all objects fit within it. Then you split the rectangle into two new rectangles, and so on.   

A problem is if the objects move. If so you have to update the data structure or it will not be valid anymore. These data stuctures are also using more memory. So you have to measure that putting the objects in a data strcuture is faster than just searching for the closest object. 

**When is it useful?**

* Find the closest object to a character. This can be a really slow process if you have hundreds of objects around the character. And if you have soldiers fighting soldiers, you have to make that seach for each soldier. A better way is to divide the search-area so you don't have to search thorough all objects - just the ones closest to you.

* To increase the performance of collision detection and raytracing.  



# Other patterns

-