# 23. Template

You have objects that uses the same overall algorithm, but the objects implement some steps in the algorithm in a different way.  

**How to implement?**

Define a template method in the parent class which consists of calling several methods. In the child class, you override the methods that are specific for the child class.

**When is it useful?**

- When your child classes share behavior and the parent class can provide these behaviors. The example in the code shows how to assemble Tesla cars. While each car consists of different parts the process of assembling a car is the same. 

**Related patterns**

- **Subclass Sandbox.** Is the opposite of the Template pattern. In the Subclass Sandbox you implement the methods in the parent class, while in Template you implement the methods in the child class.


## [Back](../)