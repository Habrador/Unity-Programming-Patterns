# 12. Type Object

You have an object and now you want to change its type (such as behavior or some data) by giving it a reference to an object that defines the type, thus the name Type Object. Another way could be to use class inheritance to define a child class which includes to code for the type, but that's not always possible because different children may be of the same type.  

**How to implement?**

The Type Objects should share the same interface (or parent) to make it easier for the main class to reference the object.        

**When is it useful?**

- When you can't (or don't want to) use class inehritance. Let's say you make a game with animals. You have a base class which is parent to all animals, and then as children to that class you add birds, fish, and mammals. In the bird class you define a flying behavior, which is all fine until you add an ostrich, which can't fly. In that case you have to inherit from the bird class and create new children that can fly and can't fly. But what about bats, which is a mammal that can fly? You don't want to add flying behavior in two separate classes! A better way is to define a flying and a non-flying type in a separate class, so both ostriches remain on the ground and bats can fly.

- In game event systems, the Type Object can be used to define event types as objects. This allows for dynamic registration and handling of different event types during runtime, making the event system more versatile and adaptable.

- Can be used to manage game configuration and settings. By representing different configuration options or settings as objects, you can dynamically switch between different configurations.

- If you need to switching type at runtime.

**Related patterns**

- **State.** In both cases you have a main object and then you add another object to define something. The difference is that in State you switch the other object, while in Type Object that object remains the same. So if the type can be switched you get the State pattern.
 
- **Subclass Sandbox.** You could define all types in the parent class and then combine them in the child class. 
 
- **Component.** The difference is that the Component is not always coupled with something else on the game object – it’s living its own life. In Unity you can add colliders, scripts, mesh renderers and they don’t need to know about each other to function. Type Object, however, is about adding a behavior to an existing class, so the type can't live on its own.


## [Back](../)