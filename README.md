# Game programming patterns in Unity

Here you can find a collection of programming (design) patterns in Unity, mainly from the book [Game Programming Patterns](http://gameprogrammingpatterns.com). These are very useful to better organize your Unity project as it grows because they capture best practices and solutions to commonly occuring problems. You don't have to use them - you should see them as tools in your toolbox. You can also experiment with how they are implemented to fit your specific needs. Some patterns, such as Update, Game Loop, Component, are already built-in into Unity so you are already using them! 

Programming patterns can be divided into the following groups:
1. **Architectural patterns.** One example is the MVC (Model-View-Controller).
2. **Design patterns.** Are more specific than architectural patterns, such as the Singleton.
3. **Anti-patterns.** Are a collection of patterns programmers are using to solve problems even though they shouldn't use them because they are ineffective solutions. One example is a "God object," most likely called GameController where you collect everything you might need to make the game work. The problem with such as class is that it will grow in size, which will make it more difficult to maintain, and it will also be difficult to debug because the code doesn't belong together.  

Patterns from the book Game Programming Patterns:

1. [Command](_text/command.md)
2. [Flyweight](_text/flyweight.md)
3. [Observer](_text/observer.md)
4. [Prototype](_text/prototype.md)
5. [Singleton](_text/singleton.md)
6. [State](_text/state.md)
7. [Double Buffer](_text/double-buffer)
8. [Game Loop](_text/game-loop)
9. [Update Method](_text/update-method)
10. [Bytecode](_text/bytecode)
11. [Subclass Sandbox](_text/subclass-sandbox)
12. [Type Object](_text/type-object)
13. [Component](_text/component)
14. [Event Queue](_text/event-queue)
15. [Service Locator](_text/service-locator)
16. [Data Locality](_text/data-locality)
17. [Dirty Flag](_text/dirty-flag)
18. [Object Pool](_text/object-pool)
19. [Spatial Partition](_text/spatial-partition)

Other patterns:

20. [Decorator](_text/decorator)
21. [Factory](_text/factory)
22. [Facade](_text/facade)
23. [Template](_text/template)

Note that these are not all patterns out there. I recently read a book called "Machine Learning Design Patterns" which includes even more design patterns with a focus on machine learning problems. But I will continue adding patterns as I find them and if they are related to game development.  



# Sources and Read More

- [Game Programming Patterns](http://gameprogrammingpatterns.com)
- [Game Development Patterns with Unity 2021](https://www.amazon.com/Game-Development-Patterns-Unity-2021/dp/1800200811)
- [Head First Design Patterns](https://www.amazon.com/Head-First-Design-Patterns-Brain-Friendly/dp/0596007124)
- [Game Programming Gems](https://www.amazon.com/Game-Programming-Gems-CD/dp/1584500492)
- [Game Programming Gems 2](https://www.amazon.com/Game-Programming-Gems-GAME-PROGRAMMING/dp/1584500549)
- [Refactoring Guru](https://refactoring.guru/design-patterns)
- [Design Patterns in C# With Real-Time Examples](https://dotnettutorials.net/course/dot-net-design-patterns/)
- [Level up your code with game programming patterns](https://resources.unity.com/games/level-up-your-code-with-game-programming-patterns)



# Special Thanks

- **[masoudarvishian](https://github.com/masoudarvishian)** for implementing Event Queue pattern, Service Locator pattern, and bug fixing.
- **[VladimirMirMir](https://github.com/VladimirMirMir)** for bug fixing.
- **[JayadevHaddadi](https://github.com/JayadevHaddadi)** for fixing event code. 
