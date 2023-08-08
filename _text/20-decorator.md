# 20. Decorator

You have a class you want to add some behaviors to in a flexible to an object way without modifying the original class. Other objects of the same class are uneffected, so it is used to dynamically extend the functionality of objects at runtime. Overall, the Decorator Pattern is a versatile and flexible design pattern that enables game developers to enhance and customize game objects or systems without modifying their core implementation.   

**How to implement?**

You have a class and now you create several "decorator" classes that modifies some of the behaviors in the class you want to modify. The decorator class should wrap the class it wants to modify. The decorator class can in turn wrap itself to add other behaviors. This might be easier than the alternative to create child classes.        

**When is it useful?**

- If you have an order system where people order several products at the same time but pay at a later time. An example of this can be found in the code section where you order Tesla cars with modifications. Yes you could store each order in a list, but a better way is to store them in objects linked to each other. Instead of iterating through each object to find the price, you can just ask the "last" object to get the price of the entire chain.     

- If you ever played Pubg you know you have weapons to which you can attach various attachments you find while playing the game. You can find magazines, sights, silenzers, etc, modifying the weapon's properties. You can use the Decorator pattern to implement this in your game.   

- To implement power-ups that temporarily modify the behavior of game objects. Each power-up can be represented as a decorator that wraps around the original object, adding specific enhancements, such as increased speed, damage boost, or invincibility.

- To add special effects or animations to UI buttons, panels, or icons.

- To dynamically adjust the difficulty level of a game. Decorators can be added or removed based on player performance or preferences, altering the game's challenges accordingly.

**Related patterns**

- **Subclass Sandbox.** You may end up with many child-classes. To easier handle the code, you can define high-level methods in the parent.


## [Back](../)