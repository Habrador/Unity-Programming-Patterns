# Game programming patterns in Unity

A collection of programming patterns in Unity, mainly from the book [Game Programming Patterns](http://gameprogrammingpatterns.com/contents.html)

Programming patterns can generally be divided into the following groups:
1. Architectural patterns - one example is the MVC (Model-View-Controller)
2. Design patterns - are more specific than architectural patterns, such as the Singleton
3. Anti-patterns - are a collection of patterns that many programmers are using to solve problems even though they shouldn't use them because they are ineffective solutions to a problem. Once example is a God object, most like called GameController where you collect everything you might need


## 1. Command


## 2. Flyweight


## 3. Observer


## 4. Prototype


## 5. Singleton


## 6. State

**What is it?** 

Your game can be in a number of states. For example, the main character can have the following states: jump, walk, run, etc. Now you want an easy way to switch between the states. This pattern is also known as a state machine.

**How to implement?**

* You could use an enum that keeps track of each state and then a switch statement.
* The problem with the switch statement is that it tends to become complicated the more states you add. A better way is to define an object for each state and then you switch between the objects as you switch states.

**When is it useful?**

* When you have too many nested if-statements, such as in a menu system. In the code I've given an example of a menu system that uses this pattern.
* Unity is using this pattern in the animation engine. 


## 7. Double Buffer


## 8. Game Loop


## 9. Update Method


## 10. Bytecode


## 11. Subclass Sandbox


## 12. Type Object


## 13. Component


## 14. Event Queue


## 15. Service Locator


## 16. Data Locality


## 17. Dirty Flag


## 18. Object Pool


## 19. Spatial Partition

