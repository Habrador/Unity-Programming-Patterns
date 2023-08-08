# 9. Update Method

The update method will process one frame of behavior. Each object that needs it should have its own update method because it would be difficult to combine everything in the game loop's update method. So each object that has a update method should be stored in some data structure, such as a list, and then you iterate over each one in the main update method.   

**How to implement?**

This pattern has already been implemented in Unity, in the form of the Update() method, which you can use if your script inherits from MonoBehaviour. Then Unity processes each Update one-by-one in the main Update method. 

You could instead of using Unity's update method, implement your custom update method. You store all the scripts that uses this custom update method in a list. Then in some script, like a GameController, you iterate through this list in Unity's update method while calling each custom update method one-by-one. This may make it easier to for example pause your game by simply not iterating through that list when the game is paused. I've given an example of this in the code section.


## [Back](../) 