# 13. Component

When making a big game you should start thinking in components. A component is similar to your computer mouse, which you can attach to whatever computer you want through a USB port and it works fine. So a component is an object that's independent of other objects, making it reusable, and you can attach the component to several other objects if you want those objects to get the behavior described by the component. But in reality, some components have to communicate with each other, so they can't be entirely independent of each other: The mouse is communicating with the computer, but it's not communicating with the printer.   

**How to implement?**

In Unity you can attach components to GameObjects, such as colliders, mesh renderers, your own scripts, so it's already built-in. It's up to you to make the custom scripts you attach as reusable as possible.

**When is it useful?**

- Because Unity's FPS counter is not to be trusted, you can have a custom FPS counter that you re-use throughout all projects. Just add the script to the project and attach it to some GameObject and it works fine independently of everything else going on in the game.

- When making a car game you can put physics in one script, such as drag and rolling resistance, becuse physics will always affect the car and the physics calculations are the same for all cars. This component will not be completely independent because it will need some data from the car, such as current speed, but as said before that's fine. 

**Related patterns**  

- **Type Object.** The difference is that the Component is not always coupled with something else on the game object – it’s living its own life. In Unity you can add colliders, scripts, mesh renderers and they don’t need to know about each other to function. Type Object, however, is about adding a behavior to an existing class, so the type can't live on its own.


## [Back](../)