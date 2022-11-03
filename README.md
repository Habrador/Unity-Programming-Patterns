# Game programming patterns in Unity

Here you can find a collection of programming (design) patterns in Unity, mainly from the book [Game Programming Patterns](http://gameprogrammingpatterns.com). These are very useful to better organize your Unity project as it grows because they capture best practices and solutions to commonly occuring problems. You don't have to use them - you should see them as tools in your toolbox. You can also experiment with how they are implemented to fit your specific needs. Some patterns, such as Update, Game Loop, Component, are already built-in into Unity so you are already using them! 

Programming patterns can be divided into the following groups:
1. **Architectural patterns.** One example is the MVC (Model-View-Controller).
2. **Design patterns.** Are more specific than architectural patterns, such as the Singleton.
3. **Anti-patterns.** Are a collection of patterns programmers are using to solve problems even though they shouldn't use them because they are ineffective solutions. One example is a "God object," most likely called GameController where you collect everything you might need to make the game work. The problem with such as class is that it will grow in size, which will make it more difficult to maintain, and it will also be difficult to debug because the code doesn't belong together.  

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

20. [Decorator](#20-decorator)
21. [Factory](#21-factory)
22. [Facade](#22-facade)
23. [Template](#23-template)

Note that these are not all patterns out there. I recently read a book called "Machine Learning Design Patterns" which includes even more design patterns with a focus on machine learning problems. But I will continue adding patterns as I find them and if they are related to game development.  


# Patterns from the book Game Programming Patterns

## 1. Command

In you game you have many commands, such as play sound, throw cake, etc. It can be useful to wrap them in a command object. Now the command object doesn't have to care about how the command is executed. 

**How to implement?**

You have a base class called Command which has a method that a child can implement called Execute. In each child class, you put in the Execute method what will actually happen when you run (execute) that command.  

**When is it useful?**

- To rebind keys. Example of this is available in the code section. 

- To make a replay system. When you play the game, you store in some data structure which button you pressed each update. When you want to replay what has happened, you just iterate through each command while running the game. Example of this is available in the code section. 

- To make an undo and redo system. Is similar to the replay system, but in each command you also have a method called Undo() where you do the opposite of what the command is doing. Example of this is available in the code section.

**Related patterns**

- **[Subclass Sandbox](#11-subclass-sandbox).** You may end up with many child-command-classes. To easier handle the code, you can define high-level methods in the parent.

- **Memento.** With this pattern you can also return to a previous state. 



## 2. Flyweight

This pattern is useful if you have many game objects. Even though a single object takes up little memory – instantiating many of them can cause trouble.

**How to implement?** 

Separate the data that’s not specific to a single instance of that object and can be shared across all of them. You can do that by creating a new class and put the shared data in it. Then each object that should share data gets a reference to a single instance of that "storage" class.

**When is it useful?**

- If you make Minecraft and have a million cubes in the scene. All cubes can share the same texture if you put all textures that belongs to each cube type (grass, stone, sand, etc) into a [texture atlas](https://en.wikipedia.org/wiki/Texture_atlas).

- If you make a strategy game, all infantry units share the same mesh, texture, maxHealth settings, etc. You only need to create one object with this data and then all infantry units can share that object. Each individual infantry unit only need to keep track of its own position and health.   

- This is implemented in Unity as [sharedMesh](https://docs.unity3d.com/ScriptReference/MeshFilter-sharedMesh.html) and [sharedMaterial](https://docs.unity3d.com/ScriptReference/Renderer-sharedMaterial.html). If you make a change to a sharedMesh then all objects using that mesh will get a new mesh.  

**Related patterns**

- **[Type Object](#12-type-object).** The main difference is that in Type Object you don't need to have the exact same data and you can also have behavior.   



## 3. Observer

Many things are constantly happening in your game. These things are called events (or messages). The difference between event and message is that an event has happened while a message is something that will happen. So this pattern is all about what will happen after an event has happened. Which methods should be called after you killed an enemy to update score, show death animation, etc? These methods should subscribe to the event. 

**How to implement?** 

This pattern is so popular that C# has implemented it for you. Unity also has its own implementation. Your alternatives are:

- EventHandler
- Action
- UnityEvent
- Your own implementation by using a delegate

I've implemented all these in the code, so if you don't understand the difference take a look there. 

**When is it useful?**

- This pattern is really useful if you want to avoid spaghetti code by making classes independent of each other, also known as decoupling. The best part of events is the part that's triggering the event doesn't care which methods are attached to the event. There might be zero methods. So if an event is triggered but nothing is happening you can easier find where the bug might be.

- If you really want to decouple your code, then you still have a problem. To subscribe to the event you need a reference to the script where the event is defined. Another way is to create an Event Manager, which is a global class that takes care of all events. Unity has its own tutorial on how to implement that: [Creating a Simple Messaging System](https://www.youtube.com/watch?v=0AqG1fDhPT8).

- Another way to decouple the code is to make the event static. An example of a static event is available in the code.  

**Related patterns**

- **[Event Queue](#14-event-queue).** The biggest problem with Observer is that it will trigger all methods subscribing to the event. If five methods subscribe, then five methods will be triggered. But what if 10 enemies are killed at the same time? Then 50 methods will be triggered and it can freeze the game. This is when you should use the Event Queue, which is basically the same as the Observer, but you put the events in a queue and you trigger as many as you can each Update without freezing the game.

- **Model-View-Controller (MVC).** The MVC is an architectural pattern, and to implement it you can use the Observer pattern.    



## 4. Prototype

In your game you have a game object. Now you want to duplicate that object. This pattern allows you to create as many duplicates of an object as you want.

**How to implement?**

This is a pattern that already exists in Unity in the form of the [Instantiate-method](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html). But it assumes that the object you want to duplicate inherits from Object, which is a class in UnityEngine.

You can also make you own implementation. But then you have to ask yourself: do you do a deep clone (a copy of the structure and the elements in the structure) or a shallow clone (a copy of the structure not the elements in the structure)? Maybe the Flyweight pattern can give you the answer?    

**When is it useful?**

- If you have a gun that fires bullets. You add one bullet prefab to the script. Each time you fire the gun you need a new bullet because you don't want to use the original bullet, so you call Unity's Instantiate-method and you get a duplicate of the original bullet.

**Related patterns**

- **[Factory](#21-factory).** In the Factory you are generally generating new objects - not copies of already existing objects (which may include position and other states). You can put the Prototype inside of the Factory so you have one class where you create all objects instead of having the creation in multiple classes which might be troublesome if you want to change something. 

- **[Object Pool](#18-object-pool).** If you Instantiate and destroy many game objects it will affect the performance of the game. To solve that problem you can use the Object Pool pattern. 



## 5. Singleton

In your game you might have a class that saves the game for you. It's really important that you have just one instance of this class or you might save different versions of the game if each instance includes different data. It should also be easy to access this save game class from where you need it. You can use the Singleton pattern to accomplish this. 

**How to implement?**

In C#. Make the instance static and provide a public static means of getting the reference to the single created instance. If the instance hasn't been created yet, create it. The constructor should be private and have no parameters. You can find this implemented in the code section.

If your Singleton has to be thread safe, things will get more complicated. This is a good tutorial on the topic of more advanced Singleton patterns: [Implementing the Singleton Pattern in C#](https://csharpindepth.com/articles/singleton).

In C# but the class also inherits from MonoBehaviour. If you want the Singleton to also inherit from MonoBehaviour (because you need some of that functionality) things will get more complicated. The problem now is that you can accidentally add several Singletons to the project. So you have to make sure you destroy all except one of the objects. Neither can you use a constructor, because MonoBehaviour doesn't allow it, so you have to implement your own constructor. You can find this implemented in the code section.    

**When is it not useful?**

- According to the book "Game Programming Patterns," you should avoid this pattern because global objects can cause trouble. If you need to use this pattern, then it should be for manager classes, such as GameController, SaveGame, etc. The fewer Singletons the better!

- If you use the MonoBehaviour version, a problem is that if you call the Singleton object from another object's OnDestroy method when you quit the game, the Singleton might have already been destroyed.  

**What are some alternatives?**

You tend to use the Singleton pattern because you want an easy access to that script. But if Singletons are so bad, what are some alternatives?

- **No class at all.** Most Singeltons are helpers, and in many cases you can remove the manager and put the help-code in the class the manager manages.

- **Static class.** This is basically the [Service Locator pattern](#15-service-locator). 

- **Unity's built-in Find() and SendMessage().** But these are so slow they should be avoided. If you have to use them, use them only once to get a reference to the script in the Start method. 

- **Assign references to pre-existing objects.** This means dragging the object (on which the script that used to be a Singleton is attached) to public variables exposed in the Editor. The problem now is that this may become very complicated, and if you change a reference you often have to again drag them to wherever it's needed, which may be many locations if you have many objects. 

- **A global event system.** This is the [Observer pattern](#3-observer). You still need a Singleton for this global system, but you can remove all other Singletons.

- **Dependency Injection.** You inject the reference to the object (that used to be a Singleton) in for example the constructor belonging to the class that need a reference to that object. There's also [Dependency Injection frameworks](https://www.youtube.com/watch?v=6tn8pMQuxEk) to make this process easier.

- **One Singleton.** Have just one Singleton class and all managers that used to be Singletons are collected in this class. If you need the SaveGame object, you type GameController.Instance.getSaveGameManager(). 



## 6. State

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

**Related patterns**

- **[Type Object](#12-type-object).** In both cases you have a main object and then you add another object to define something. The difference is that in State you switch the other object, while in Type Object that object remains the same. So if the object in Type Object can be switched you get the State pattern.

- **Strategy.** With this pattern you can give an object a new behavior (a new strategy to follow) without taking into account its current state or states coming after the current behavior.   

- **Memento.** Same as state but you can roll back to a previous state.  

- **Behavior Tree.** Is useful if you have many states and want a more complex behavior. 
     


## 7. Double Buffer

You have two buffers: you update #1 with new data while you are not allowed to modify #2 because #2 is holding old data from previous update, which you might want to display on the screen or use when updating #1. When you have finished updating #1, you swap them, so #2 is now including fresh data and you can start updating #1 which is now including old data.

**How to implement?**

You can have two arrays. You write to one of them, and when the calculations are finished you swap the pointer to the arrays. 

**When is it useful?**

- To display stuff on the screen. This is already built-in into you computer which uses two buffers to display stuff on the screen. It reads from #2 while #1 is being updated with new data. When #1 is finished updating, the buffers are switched, so now you will see the newly updated data on the screen. It would look strange if you used just one buffer because then one part of the screen would display old data and one new data in some kind of horrible mix.

- To generate motion blur. The current buffer is blended with a bit of the previous buffer. 

- Cellular Automata (CA). In games it's common to store data in a grid (which is a 2d array). To calculate new data you combine data from the cells, such as the maximum value of the current cell and surrounding cells. But where are you storing the data for the cell you just calculated? You can't store it in the cell because that will screw up the calculations for neighboring cells because you always want to use old data when doing the calculations. So you use two grids: #2 holds the old data and #1 is using #2 to update itself. When the calculations are finished, you swap them. 

	- Cave-generation. This is the example I've included in the code. 
	
	- [Water](http://www.jgallant.com/2d-liquid-simulator-with-cellular-automaton-in-unity/). You simulate movement of water on a grid.
	
	- [Forest fire](https://www.youtube.com/watch?v=JtGp9eUugFs). You store in each cell the amount of burning material in that cell, then you simulate heat to ignite the material. When there's no more material to burn, the heat disappears.  



## 8. Game Loop

The game loop is the core of all games. It's basically an infinite while loop that keeps updating until you stop it. But the problem with such a while loop is that it updates faster on faster computers than it is on slower computers. This will be very problematic if you have some object that travels with some speed, then it will travel faster on the faster computer. To solve this problem you need to take time into account by using the following:

- Fixed time step. You determine you want the game to run at 30 frames-per-second (FPS). Now you know how long one while loop should take (1/30 = 0.03333 seconds). If the while loop is faster than that, you simply pause it at the end until 0.03333 seconds has passed. If it's slower, you should optimize your game.  

- Variable (fluid) time step. You measure how many seconds has passed since the last frame. You then pass this time to the update method, so the game world can take bigger steps if the computer is slow and smaller steps if the computer is fast.    

**How to implement?**

This pattern has already been implemented in Unity, which is actually using both versions of the while loop:
	
- Fixed time step: Time.fixedDeltaTime. This version is used for physics calculations where you should use a constant step to make more accurate calculations. 
	
- Variable time step: [Time.deltaTime](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html), which Unity defines as "The completion time in seconds since the last frame." 

The game loop is also checking for input before anything else. This is why in Unity you can type "if (Input.GetKey(KeyCode.A))" because the game loop has already checked (before the update method) if the A key has been pressed and stored that information in some data structure. 

**When is it useful?**

- When you have a bullet that should move with a constant speed. So you determine a bulletSpeed and in the update method you multiply the speed with Time.deltaTime so the bullet travels with the same speed no matter how fast the computer is.  



## 9. Update Method

The update method will process one frame of behavior. Each object that needs it should have its own update method because it would be difficult to combine everything in the game loop's update method. So each object that has a update method should be stored in some data structure, such as a list, and then you iterate over each one in the main update method.   

**How to implement?**

This pattern has already been implemented in Unity, in the form of the Update() method, which you can use if your script inherits from MonoBehaviour. Then Unity processes each Update one-by-one in the main Update method. 

You could instead of using Unity's update method, implement your custom update method. You store all the scripts that uses this custom update method in a list. Then in some script, like a GameController, you iterate through this list in Unity's update method while calling each custom update method one-by-one. This may make it easier to for example pause your game by simply not iterating through that list when the game is paused. I've given an example of this in the code section. 



## 10. Bytecode

What if other people want to help you with your game, but these people have no coding skillz. A solution is to invent a simpler programming language everyone can learn, and then you integrate it with your game. 

**How to implement?**

The programmers with no skillz write their code in a .txt-file. You read that file, loop through each row, and then use a switch statement to translate the code from your programming language to C#.

**When is it useful?**

- If you want to add modding support.

- If you don't want to hard-code behaviour. 



## 11. Subclass Sandbox

You have similar objects but they have different behavior. Create those behaviors in the child class by combining methods defined in the parent class.

**How to implement?**

Define several protected methods in the parent class and how they are implemented. In the child class, you call the methods you need to get the behavior you want.

**When is it useful?**

- When your child classes share behavior and the parent class can provide these behaviors. For example if you are using superpowers and the child class can combine these superpowers. This is an example from the book so you can find the code in the code section.  

**Related patterns**

- **[Update Method](#9-update-method).** The Update Method is often implemented as a Sandbox method.

- **[Type Object](#12-type-object).** Instead of defining all methods in the parent you could give the child a reference to an object that defines these methods.  

- **[Template](#23-template).** Is the opposite of the Subclass sandbox pattern. In the Subclass Sandbox you implement the methods in the parent class while in Template you implement the methods in the child class. 



## 12. Type Object

You have an object and now you want to change its type (such as behavior or some data) by giving it a reference to an object that defines the type, thus the name Type Object. Another way could be to use class inheritance to define a child class which includes to code for the type, but that's not always possible because different children may be of the same type.  

**How to implement?**

The Type Objects should share the same interface (or parent) to make it easier for the main class to reference the object.        

**When is it useful?**

- When you can't (or don't want to) use class inehritance. Let's say you make a game with animals. You have a base class which is parent to all animals, and then as children to that class you add birds, fish, and mammals. In the bird class you define a flying behavior, which is all fine until you add an ostrich, which can't fly. In that case you have to inherit from the bird class and create new children that can fly and can't fly. But what about bats, which is a mammal that can fly? You don't want to add flying behavior in two separate classes! A better way is to define a flying and a non-flying type in a separate class, so both ostriches remain on the ground and bats can fly.  

**Related patterns**

- **[State](#6-state).** In both cases you have a main object and then you add another object to define something. The difference is that in State you switch the other object, while in Type Object that object remains the same. So if the type can be switched you get the State pattern.
 
- **[Subclass Sandbox](#11-subclass-sandbox).** You could define all types in the parent class and then combine them in the child class. 
 
- **[Component](#13-component).** The difference is that the Component is not always coupled with something else on the game object – it’s living its own life. In Unity you can add colliders, scripts, mesh renderers and they don’t need to know about each other to function. Type Object, however, is about adding a behavior to an existing class, so the type can't live on its own. 



## 13. Component

When making a big game you should start thinking in components. A component is similar to your computer mouse, which you can attach to whatever computer you want through a USB port and it works fine. So a component is an object that's independent of other objects, making it reusable, and you can attach the component to several other objects if you want those objects to get the behavior described by the component. But in reality, some components have to communicate with each other, so they can't be entirely independent of each other: The mouse is communicating with the computer, but it's not communicating with the printer.   

**How to implement?**

In Unity you can attach components to GameObjects, such as colliders, mesh renderers, your own scripts, so it's already built-in. It's up to you to make the custom scripts you attach as reusable as possible.

**When is it useful?**

- Because Unity's FPS counter is not to be trusted, you can have a custom FPS counter that you re-use throughout all projects. Just add the script to the project and attach it to some GameObject and it works fine independently of everything else going on in the game.

- When making a car game you can put physics in one script, such as drag and rolling resistance, becuse physics will always affect the car and the physics calculations are the same for all cars. This component will not be completely independent because it will need some data from the car, such as current speed, but as said before that's fine. 

**Related patterns**  

- **[Type Object](#12-type-object).** The difference is that the Component is not always coupled with something else on the game object – it’s living its own life. In Unity you can add colliders, scripts, mesh renderers and they don’t need to know about each other to function. Type Object, however, is about adding a behavior to an existing class, so the type can't live on its own.



## 14. Event Queue

You have some events but you can wait until later to process each event. This may be useful if you have many events that may be activated at the same time which will freeze the game because this pattern will spread them out over some time period. 

**How to implement?**

Combine the [Command](#1-command) pattern with C#'s built-in queue, which is why this pattern is sometimes known as a **Command Queue**. In the Update method you pick the first Command in the queue and run it while measuring time. To measure time you can use System.Diagnostics.Stopwatch. If you have time to spare, you run the next Command, and so on until you are out of time. How much time you can spend on the Event Queue each update depends on the game, so you have to experiment.

**When is it useful?**

- When you after an event will load an asset. This may take time, so if you want to play a sound when clicking a button, the game may freeze because it has to load the sound. A better way is to play the sound some frames after the click.     

- When you after an event will play a sound effect. What if 100 enemies die at the same time and each time an enemy dies you play a death-sound. Now 100 sounds will play at the same time. If you put the events in a queue, you can check if a sound is already playing and then ignore the event. You can also merge the events that are the same, so you have only one of each event type in the queue.   

- If you are making a strategy game, you can put orders in the queue that the player wants a certain unit to do: 1. build wall, 2. collect food, 3. attack creature. Now the player doesn't have to wait for a unit to finish one task. You can also put waypoints in the queue to make a unit patrol between waypoints. The AI can also put commands in a queue to for example determine which units should attack.  

- When making a speech system. Each character has its own queue with audio it wants to say. To know which character should speak, you can go through all queues. If the player presses Escape because the player doesn't want to listen to the talk, you simply clear all queues.

**Related patterns** 

- **Event Bus.** Similar to Event Queue but there's no delay.

- **[Observer](#3-observer).** You use the Observer pattern to implement the Event Queue.



## 15. Service Locator

When making your game you use many standardized methods to for example generate random numbers. These are called services and should be accessible from everywhere (globally) but still be independet from your game's main code.   

**How to implement?**

Put each service in a static class. The static class should be in its own folder and have its own namespace to make sure you are not mixing the services with your main code.

Use a Service Locator that provides access to a service provider. To make sure no other methods than the ones you need are exposed to the outside world, the service provider should limit which methods it can provide access to.   

Unity has implemented this pattern in the form of the GetComponent() method.

**When is it useful?**

- Several services are already built-in into Unity, such as Random.Range() to get a random number, Mathf.PI to get pi, and Debug.Log() to display something in the console.

- In the game you may have different audio objects depending on if the game is running on a console or PC. This is the same example as in the book so you can find the code for it in the code section.  

**Related patterns** 

- **[Singleton](#5-singleton).** Both provide a global access to an object. So the problems with the Singleton also applies to this pattern.  

- **[Facade](#22-facade).** You can use Facade in combination with Service Locator.



## 16. Data Locality

Have you done all optimizations you can possible do? Is the game still too slow? Then this pattern may help you. It can make your game faster by accelerating memory access.   

**How to implement?**

You have to arrange data to take advantage of CPU caching. The basic idea is that you should organize your data structures so that the things you're processing are next to each other in memory. This is a big topic and can't be summarized here, so you should read about it in the book "Game Programming Patterns."

This Unity article suggest that you should use struct instead of class because they are more cache friendly [How to Write Faster Code Than 90% of Programmers](https://jacksondunstan.com/articles/3860). 

Unity has implemented this pattern in their [Data-Oriented Technology Stack (DOTS)](https://unity.com/dots).

A good Unity tutorial on the topic is: [Unity Memory Profiler: Where Are You Wasting Your Game's Memory?](https://thegamedev.guru/unity-memory/profiler-part-1/) and [Part 2](https://thegamedev.guru/unity-memory/profiler-part-2/). 

**When is it useful?**

- According to the book "Game Programming Patterns," this pattern should be used when everything else has failed. It's a waste of time to optimize code that doesn't need to be optimized - and it may also make the code more complicated to understand. You also have to make sure that cache misses is the reason your code is slow, so you first have to measure it.  



## 17. Dirty Flag

This pattern is useful if something has changed in your game and if so you have to run a costly operation. A Dirty Flag is used to tell that something has changed but the costly operation hasn't been activated yet. You can often postpone the costly operation until the result is actually needed.   

**How to implement?**

The dirty flag is just a bool.

**When is it useful?**

- Saving your game can be a costly operation. If something in your game has changed that also needs to be saved, you set a Dirty Flag in the save game object to true. Now if the player wants to quit the game, you can easily tell the player that there are unsaved changes. An example of this can be found in the code section.  

- When doing editor scripting in Unity, you can use SetDirty() to mark an object as dirty or you can even mark the entire scene as dirty. Now Unity will understand that you have changed something and those changes should be saved when you save your scene.

- Unity is using it in the physics system. A RigidBody doesn't have to be updated unless a force is applied to it. If the RigidBody is sleeping (not moving), a Dirty Flag is used so the physics system can ignore it. 

- I used this pattern when experimenting with Genetic Algorithms (GA) and the Traveling Salesman Problem (TSP) where you find the shortest path between multiple cities. The GA generates multiple solutions, like 100, to the TSP and then each iteration you evolve 100 better solutions by calculating a cost function, which is the distance between all cities. You can use "tournament selection" to find good solutions from the previous iteration to the next, which is basically picking 3 solutions and returns the solution with the shortest distance between all cities. I realized I didn't have to calculate the cost fuction 100 times each iteration because it's a costly operation. To optimize I only calculate the cost function of the cities being picked by the tournament selection. I kept track of which solution has had its cost fuction calculated by using a bool which is set to false each iteration and then to true if the cost function has been run.            



## 18. Object Pool

If you constantly create and destroy objects, the performance of your game will suffer. A better way is to create the objects once when you start the game and deactivate them. When you need an object, you pick one of the deactivate objects and activate it. When you don't need the object anymore, you deactivate it instead of destroying it.   

**How to implement?**

Create a class called object pool. Give it an object prefab and instantiate the number of objects you think you will need. Store them in a list. When you need an object you search through the list for a deactivated object and returns the first you find. If you realize you need more objects than the objects you started with, you have a few choises: 

	- You can instantiate more objects during gameplay. But make sure you don't instantiate too many objects because it will be a waste of memory. You could later remove the "extra" objects you added.  

	- Pick one of the objects that's active but the player will not notice if it suddeny disappears so you can use it.

	- Ignore that you have no more objects, which may be fine. If the screen is filled with explosions, the player will not notice a new explosion is missing.

If you search the list to find an avilable object, and the list is very long because you have many pooled objects, you waste time. A better way is to store the objects in the pool in a linked-list.

This pattern is so popular Unity has implemented their own version of it called [ObjectPool](https://docs.unity3d.com/ScriptReference/Pool.ObjectPool_1.html). Is only available in later versions of Unity.

**When is it useful?**

- When you fire bullets from a gun then you will need many bullets. I've given an example of this in the code section. You can find three versions: the optimized version which uses a linked-list, the slow ut simple version which has to search a list, and Unity's native object pool. 

- Unity is using this pattern in their particle system. In the particle settings you can set max number of particles, which can be useful so you don't accidentally instantiate millions of particles.      

**Related patterns** 

- **[Data Locality](#16-data-locality).** In this pattern you pack objects of the same type together in memory. It will help the CPU cache to be full as the game iterates over those objects, which is what the Data Locality patterns is about.

- **[Prototype](#4-prototype).**



## 19. Spatial Partition

If you have many objects in your game, store the objects in a data structure that organizes the objects by their positions. This should make it faster to for example find which objects are colliding.  

**How to implement?**  

This is a common pattern, so you have several choices:

- **Grid.** Divide the area into a grid and store in the data structure in which cell each object is located. This is the example from the book, so you can find the code for it in the code section.

- **Trie.** Is actually called [Trie](https://en.wikipedia.org/wiki/Trie) and not Tree! 
	- [Quadtree (2d space)](https://en.wikipedia.org/wiki/Quadtree). Divide the square area into 4 cells. But if too many objects are in the same cell, divide that cell into 4 new cells. Continue until there are not "too many objects in the same cell." A good tutorial can be found here: [Coding Challenge #98.1: Quadtree - Part 1](https://www.youtube.com/watch?v=OJxEcs0w_kE).
	- [Octree (3d space)](https://en.wikipedia.org/wiki/Octree). Is similar to Quadtree, but instead of cells you use cubes, so divide a cube volume into 8 cubes, and then split each cube into 8 new cubes and so on.

- **Binary search trees.** The name is binary, so the difference between Tree is that you split the groups into 2 smaller groups, and then you split one of the smaller groups into 2 smaller groups, and so on.  
	- [Binary space partition (BSP)](https://en.wikipedia.org/wiki/Binary_space_partitioning). You use a plane to split a group into 2 new groups. And then you use another plane to split the new group into 2 new groups, and so on until you are finished.  
	- [k-d trees](https://en.wikipedia.org/wiki/K-d_tree). In this case it has to be points that you split into smaller, and smaller groups. 
	- [Bounding volume hierarchy](https://en.wikipedia.org/wiki/Bounding_volume_hierarchy). You pick a bounding volume (or area in 2d space), such as a rectangle. The size of the first rectangle is determined so all objects fit within it. Then you split the rectangle into two new rectangles, and so on.   

If the objects move you have to update the data structure. These data stuctures are also using more memory meaning you have to measure that putting the objects in a data structure is faster than just searching for the closest object. 

**When is it useful?**

- Find the closest object to a character. This can be a really slow process if you have hundreds of objects around the character. And if you have soldiers fighting soldiers, you have to make that seach for each soldier. A better way is to divide the search-area so you don't have to search thorough all objects - just the ones closest to you.

- To increase the performance of collision detection and raytracing.  



# Other patterns



## 20. Decorator

You have a class you want to add some behaviors to in a flexible way without modifying the original class.  

**How to implement?**

You have a class and now you create several "decorator" classes that modifies some of the behaviors in the class you want to modify. The decorator class should wrap the class it wants to modify. The decorator class can in turn wrap itself to add other behaviors. This might be easier than the alternative to create child classes.        

**When is it useful?**

- If you have an order system where people order several products at the same time but pay at a later time. An example of this can be found in the code section where you order Tesla cars with modifications. Yes you could store each order in a list, but a better way is to store them in objects linked to each other. Instead of iterating through each object to find the price, you can just ask the "last" object to get the price of the entire chain.     

- If you ever played Pubg you know you have weapons to which you can attach various attachments you find while playing the game. You can find magazines, sights, silenzers, etc, modifying the weapon's properties. You can use the Decorator pattern to implement this in your game.   

**Related patterns**

- **[Subclass Sandbox](#11-subclass-sandbox).** You may end up with many child-classes. To easier handle the code, you can define high-level methods in the parent. 



## 21. Factory

Collect all methods on how to create new objects in their own class. The factory can also be responsible for the destruction of objects.

**How to implement?**

If you are creating several different factories, then they should inherit from some parent abstract class. And the products you create should also inherit from some parent abstract class, so you can handle them as their parent without caring which child product that actually came out from the factory.  

**When is it useful?**

- If you've implemented the [Decorator](#20-decorator) then you can decorate the objects in a procedural way by using the Factory pattern. An example of this is in the code where you manufacture the Tesla cars you ordered in the Decorator pattern example.

- To play sounds on different devices. An example of this can be found in the code section.

- For each object you make you have to allocate some memory. By creating all objects in a central area it makes it easier to monitor these allocations.  

**Related patterns**

- **[Prototype](#4-prototype).** The Prototype pattern is generally used if you want to make a copy of an existing object, while the Factory pattern is generating new objects. But some argue you can put the Prototype pattern inside of the Factory pattern.



## 22. Facade   

When you have several related classes, such as AI or audio, and want to make it simpler to access methods in those classes without creating spaghetti code. The name comes from [building facades](https://en.wikipedia.org/wiki/Fa%C3%A7ade) - you can only see the exterior of the building, but have no idea how the building looks like inside. The more classes you hide from other classes the better!     

**How to implement?**

Create a manager class that provides a single interface to a large collection of related classes.  

**When is it useful?**

- In games it's common to write standardized code libraries, such as a library for the AI, which includes pathfinding, etc. These tend to include massive amounts of classes. To make it easier for yourself you create a script that includes access to the most important methods you need, such as get a path. An example of this can't be found here but in another open source library I have: [Computational geometry](https://github.com/Habrador/Computational-geometry). For example, there are multiple methods on how to generate a Delaunay triangulation. To simplify the access to those methods I wrote a class called _Delaunay, which accesses each Delaunay method in a simple way. Otherwise you would have to first go into the Delaunay folder and figure out which class is doing what and which method you should use to generate the needed Delaunay triangulation. And if I decided to use another triangulation library I only need to change the facade script.  

**Related patterns**

- **[Service Locator](#15-service-locator).** The Service Locator is not necessarily consisting of several classes - the service we want to get might consist of a single class. But the Service Locator can use the Facade Pattern.  

- **[Singleton](#5-singleton).** The facade class is often a Singleton because you need only a single object to manage access to audio or to AI.  

- **Adapter.** This pattern is dealing with legacy code that doesn't work directly with your system and you can't modify that code on your own. This legacy code could be a facade but doesn't have to be. So you add code to make the non-functioning facade work with your system. Facade creates a new interface while Adapter adapts an old interface.    



## 23. Template

You have objects that uses the same overall algorithm, but the objects implement some steps in the algorithm in a different way.  

**How to implement?**

Define a template method in the parent class which consists of calling several methods. In the child class, you override the methods that are specific for the child class.

**When is it useful?**

- When your child classes share behavior and the parent class can provide these behaviors. The example in the code shows how to assemble Tesla cars. While each car consists of different parts the process of assembling a car is the same. 

**Related patterns**

- **[Subclass Sandbox](#11-subclass-sandbox).** Is the opposite of the Template pattern. In the Subclass Sandbox you implement the methods in the parent class, while in Template you implement the methods in the child class. 



# Sources

- [Game Programming Patterns](http://gameprogrammingpatterns.com)
- [Game Development Patterns with Unity 2021](https://www.amazon.com/Game-Development-Patterns-Unity-2021/dp/1800200811)
- [Game Programming Gems](https://www.amazon.com/Game-Programming-Gems-CD/dp/1584500492)
- [Game Programming Gems 2](https://www.amazon.com/Game-Programming-Gems-GAME-PROGRAMMING/dp/1584500549)



# Special thanks

- **[masoudarvishian](https://github.com/masoudarvishian)** for implementing Event Queue pattern, Service Locator pattern, and bug fixing.
- **[VladimirMirMir](https://github.com/VladimirMirMir)** for bug fixing.
