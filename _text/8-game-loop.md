# 8. Game Loop

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


## [Back](../)  