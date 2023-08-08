# 5. Singleton

In your game you might have a class that saves the game for you. It's really important that you have just one instance of this class or you might save different versions of the game if each instance includes different data. It should also be easy to access this save game class from where you need it. You can use the Singleton pattern to accomplish this. 

**How to implement?**

In C#. Make the instance static and provide a public static means of getting the reference to the single created instance. If the instance hasn't been created yet, create it. The constructor should be private and have no parameters. You can find this implemented in the code section.

If your Singleton has to be thread safe, things will get more complicated. This is a good tutorial on the topic of more advanced Singleton patterns: [Implementing the Singleton Pattern in C#](https://csharpindepth.com/articles/singleton).

In C# but the class also inherits from MonoBehaviour. If you want the Singleton to also inherit from MonoBehaviour (because you need some of that functionality) things will get more complicated. The problem now is that you can accidentally add several Singletons to the project. So you have to make sure you destroy all except one of the objects. Neither can you use a constructor, because MonoBehaviour doesn't allow it, so you have to implement your own constructor. You can find this implemented in the code section.    

**When is it not useful?**

- According to the book "Game Programming Patterns," you should avoid this pattern because global objects can cause trouble. If you need to use this pattern, then it should be for manager classes, such as GameController, SaveGame, etc. The fewer Singletons the better!

- If you use the MonoBehaviour version, a problem is that if you call the Singleton object from another object's OnDestroy method when you quit the game, the Singleton might have already been destroyed.  

**What are some alternatives?**

You tend to use the Singleton pattern because you want an easy access to that script. But if Singletons are so bad, what are some alternatives?

- **No class at all.** Most Singeltons are helpers, and in many cases you can remove the manager and put the help-code in the class the manager manages.

- **Static class.** This is basically the Service Locator pattern. 

- **Unity's built-in Find() and SendMessage().** But these are so slow they should be avoided. If you have to use them, use them only once to get a reference to the script in the Start method. 

- **Assign references to pre-existing objects.** This means dragging the object (on which the script that used to be a Singleton is attached) to public variables exposed in the Editor. The problem now is that this may become very complicated, and if you change a reference you often have to again drag them to wherever it's needed, which may be many locations if you have many objects. 

- **A global event system.** This is the Observer pattern. You still need a Singleton for this global system, but you can remove all other Singletons.

- **Dependency Injection.** You inject the reference to the object (that used to be a Singleton) in for example the constructor belonging to the class that need a reference to that object. There's also [Dependency Injection frameworks](https://www.youtube.com/watch?v=6tn8pMQuxEk) to make this process easier.

- **One Singleton.** Have just one Singleton class and all managers that used to be Singletons are collected in this class. If you need the SaveGame object, you type GameController.Instance.getSaveGameManager(). 


## [Back](../) 