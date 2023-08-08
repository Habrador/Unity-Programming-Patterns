# 4. Prototype

In your game you have a game object. Now you want to duplicate that object. This pattern allows you to create as many duplicates of an object as you want.

**How to implement?**

This is a pattern that already exists in Unity in the form of the [Instantiate-method](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html). But it assumes that the object you want to duplicate inherits from Object, which is a class in UnityEngine.

You can also make you own implementation. But then you have to ask yourself: do you do a deep clone (a copy of the structure and the elements in the structure) or a shallow clone (a copy of the structure not the elements in the structure)? Maybe the Flyweight pattern can give you the answer?    

**When is it useful?**

- If you have a gun that fires bullets. You add one bullet prefab to the script. Each time you fire the gun you need a new bullet because you don't want to use the original bullet, so you call Unity's Instantiate-method and you get a duplicate of the original bullet.

**Related patterns**

- **Factory.** In the Factory you are generally generating new objects - not copies of already existing objects (which may include position and other states). You can put the Prototype inside of the Factory so you have one class where you create all objects instead of having the creation in multiple classes which might be troublesome if you want to change something. 

- **Object Pool.** If you Instantiate and destroy many game objects it will affect the performance of the game. To solve that problem you can use the Object Pool pattern.


## [Back](../) 