# 18. Object Pool

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

- **Data Locality.** In this pattern you pack objects of the same type together in memory. It will help the CPU cache to be full as the game iterates over those objects, which is what the Data Locality patterns is about.

- **Prototype.**


## [Back](../)