# 21. Factory

Collect all methods on how to create new objects in their own class. The factory can also be responsible for the destruction of objects.

**How to implement?**

If you are creating several different factories, then they should inherit from some parent abstract class. And the products you create should also inherit from some parent abstract class, so you can handle them as their parent without caring which child product that actually came out from the factory.  

**When is it useful?**

- If you've implemented the **Decorator** then you can decorate the objects in a procedural way by using the Factory pattern. An example of this is in the code where you manufacture the Tesla cars you ordered in the Decorator pattern example.

- To play sounds on different devices. An example of this can be found in the code section.

- For each object you make you have to allocate some memory. By creating all objects in a central area it makes it easier to monitor these allocations.

- To keep track of all of your Singletons. 

- The Factory Pattern can be used to create game objects, such as characters, enemies, items, obstacles, terrain features, structures, power-ups, collectibles, buttons, particles, etc.

**Related patterns**

- **Prototype.** The Prototype pattern is generally used if you want to make a copy of an existing object, while the Factory pattern is generating new objects. But some argue you can put the Prototype pattern inside of the Factory pattern.

- **Object Pool.** The factory doesn't have to create new objects - it can be a recycling plant if you combine Factory with Object Pool. 


## [Back](../)