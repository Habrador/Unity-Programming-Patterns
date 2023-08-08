# 11. Subclass Sandbox

You have similar objects but they have different behavior. Create those behaviors in the child class by combining methods defined in the parent class.

**How to implement?**

Define several protected methods in the parent class and how they are implemented. In the child class, you call the methods you need to get the behavior you want.

**When is it useful?**

- When your child classes share behavior and the parent class can provide these behaviors. For example if you are using superpowers and the child class can combine these superpowers. This is an example from the book so you can find the code in the code section.  

**Related patterns**

- **Update Method.** The Update Method is often implemented as a Sandbox method.

- **Type Object.** Instead of defining all methods in the parent you could give the child a reference to an object that defines these methods.  

- **Template.** Here you override the methods in the parent class.


## [Back](../)