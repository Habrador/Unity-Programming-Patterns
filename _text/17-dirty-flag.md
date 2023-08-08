# 17. Dirty Flag

This pattern is useful if something has changed in your game and if so you have to run a costly operation. A Dirty Flag is used to tell that something has changed but the costly operation hasn't been activated yet. You can often postpone the costly operation until the result is actually needed. So this pattern allows games to avoid unnecessary computations, updates, and data processing.   

**How to implement?**

The dirty flag is just a bool.

**When is it useful?**

- Saving your game can be a costly operation. If something in your game has changed that also needs to be saved, you set a Dirty Flag in the save game object to true. Now if the player wants to quit the game, you can easily tell the player that there are unsaved changes. An example of this can be found in the code section.  

- When doing editor scripting in Unity, you can use SetDirty() to mark an object as dirty or you can even mark the entire scene as dirty. Now Unity will understand that you have changed something and those changes should be saved when you save your scene.

- Unity is using it in the physics system. A RigidBody doesn't have to be updated unless a force is applied to it. If the RigidBody is sleeping (not moving), a Dirty Flag is used so the physics system can ignore it. 

- I used this pattern when experimenting with Genetic Algorithms (GA) and the Traveling Salesman Problem (TSP) where you find the shortest path between multiple cities. The GA generates multiple solutions, like 100, to the TSP and then each iteration you evolve 100 better solutions by calculating a cost function, which is the distance between all cities. You can use "tournament selection" to find good solutions from the previous iteration to the next, which is basically picking 3 solutions and returns the solution with the shortest distance between all cities. I realized I didn't have to calculate the cost fuction 100 times each iteration because it's a costly operation. To optimize I only calculate the cost function of the cities being picked by the tournament selection. I kept track of which solution has had its cost fuction calculated by using a bool which is set to false each iteration and then to true if the cost function has been run.  

- In multiplayer games, the Dirty Flag Pattern can be used to track changes in game state for network synchronization. Only data that has been marked as "dirty" needs to be sent across the network, reducing bandwidth usage and improving network performance.

- Can be used to track changes in the game environment or AI state. The AI system can then prioritize updates and decision-making for objects or AI agents with "dirty" data.


## [Back](../)