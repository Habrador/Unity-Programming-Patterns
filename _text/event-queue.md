# 14. Event Queue

You have some events but you can wait until later to process each event. This may be useful if you have many events that may be activated at the same time which will freeze the game because this pattern will spread them out over some time period. 

**How to implement?**

Combine the Command pattern with C#'s built-in queue, which is why this pattern is sometimes known as a **Command Queue**. In the Update method you pick the first Command in the queue and run it while measuring time. To measure time you can use System.Diagnostics.Stopwatch. If you have time to spare, you run the next Command, and so on until you are out of time. How much time you can spend on the Event Queue each update depends on the game, so you have to experiment.

**When is it useful?**

- When you after an event will load an asset. This may take time, so if you want to play a sound when clicking a button, the game may freeze because it has to load the sound. A better way is to play the sound some frames after the click.     

- When you after an event will play a sound effect. What if 100 enemies die at the same time and each time an enemy dies you play a death-sound. Now 100 sounds will play at the same time. If you put the events in a queue, you can check if a sound is already playing and then ignore the event. You can also merge the events that are the same, so you have only one of each event type in the queue.   

- If you are making a strategy game, you can put orders in the queue that the player wants a certain unit to do: 1. build wall, 2. collect food, 3. attack creature. Now the player doesn't have to wait for a unit to finish one task. You can also put waypoints in the queue to make a unit patrol between waypoints. The AI can also put commands in a queue to for example determine which units should attack.  

- When making a speech system. Each character has its own queue with audio it wants to say. To know which character should speak, you can go through all queues. If the player presses Escape because the player doesn't want to listen to the talk, you simply clear all queues.

**Related patterns** 

- **Event Bus.** Similar to Event Queue but there's no delay.

- **Observer.** You use the Observer pattern to implement the Event Queue.


## [Back](../)