# 22. Facade   

When you have several related classes, such as AI or audio, and want to make it simpler to access methods in those classes. The name Facade comes from [building facades](https://en.wikipedia.org/wiki/Fa%C3%A7ade) - you can only see the exterior of the building, but have no idea how the building looks like inside. You can still access classes in the subsystem if you need to - the Facade is just making it simpler to access the more common classes.

**How to implement?**

Create a manager class that provides a single interface to a large collection of related classes.

**When is it useful?**

- In games it's common to write standardized code libraries, such as a library for the AI, which includes pathfinding, etc. These tend to include massive amounts of classes. To make it easier for yourself you create a script that includes access to the most important methods you need, such as get a short path. I made an open source library: [Computational geometry](https://github.com/Habrador/Computational-geometry). There are multiple methods on how to generate a Delaunay triangulation. To simplify the access to those methods I wrote a class called _Delaunay, which access each Delaunay method in a simple way. Otherwise you would have to first go into the Delaunay folder and figure out which class is doing what and which method you should use to generate the needed Delaunay triangulation. And if I decided to use another triangulation library I only need to change the facade script. Multiple Facades are allowed, so I also have another Facade for the intersection algorithms.

- Random numbers are common in games. Should you use Unity's Random.Range or C#'s System.Random.Next? You can use the Facade pattern to easier switch between them. An example of this can be found in the code section. And if you find a third random number library, you can add it and you don't have to make a single change to the code that uses this Facade.

- Can simplify audio interactions by providing methods for playing, pausing, stopping, and managing different audio sources.

- Can provide a unified interface to handle keyboard, mouse, and controller inputs, abstracting the complexities of different input devices.

- Can be used to create a simplified interface for managing game save and load operations. It encapsulates the details of serialization, deserialization, and data storage.

- For games with physics simulation, a facade can provide a simplified interface for applying forces, detecting collisions, and managing physical interactions. It abstracts away the underlying physics engine complexities.         

**Related patterns**

- **Service Locator.** The Service Locator is not necessarily consisting of several classes - the service we want to get might consist of a single class. But the Service Locator can use the Facade Pattern.  

- **Singleton.** The facade class is often a Singleton because you need only a single object to manage access to audio or to AI.  

- **Adapter.** This pattern is dealing with how to make code you can't modify work with your system. While Facade creates a new interface to simplify, Adapter adapts an old interface. These patterns are so similar that a book included both in the same chapter.


## [Back](../)