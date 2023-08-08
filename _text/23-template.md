# 23. Template

You have objects that uses the same overall algorithm, but the objects implement some steps in the algorithm in a different way.  

**How to implement?**

Define a template method in the parent class which consists of calling several methods. In the child class, you override the methods that are specific for the child class.

**When is it useful?**

- When your child classes share behavior and the parent class can provide these behaviors. The example in the code shows how to assemble Tesla cars. While each car consists of different parts the process of assembling a car is the same. 

- To define the behavior of game characters. The common algorithm structure could include actions like movement, attacking, and interacting with the environment. Subclasses representing different character types (e.g., warrior, mage, rogue) can then override specific steps to implement their unique abilities and attributes.

- In games that involve procedural level generation, the template algorithm can outline the general layout and components of a level, while subclasses can customize the details, such as terrain features, obstacles, and enemy placement.

- For AI systems, the template algorithm could include steps like evaluating threats, considering objectives, and choosing actions. Different AI agents or enemy types can then provide their own implementations for specific decision-making criteria.

- The Template Method Pattern can be applied to define the behavior of different game states (e.g., menu, gameplay, cutscene). The template algorithm could specify the transitions and behavior common to all states, while individual state subclasses can implement state-specific logic.

**Related patterns**

- **Subclass Sandbox.** Here you combine methods defined in the parent class. 


## [Back](../)