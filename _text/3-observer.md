# 3. Observer

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

- **Event Queue.** The biggest problem with Observer is that it will trigger all methods subscribing to the event. If five methods subscribe, then five methods will be triggered. But what if 10 enemies are killed at the same time? Then 50 methods will be triggered and it can freeze the game. This is when you should use the Event Queue, which is basically the same as the Observer, but you put the events in a queue and you trigger as many as you can each Update without freezing the game.

- **Model-View-Controller (MVC).** The MVC is an architectural pattern, and to implement it you can use the Observer pattern. 


## [Back](../)  