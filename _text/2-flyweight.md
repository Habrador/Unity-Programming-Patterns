# 2. Flyweight

Even though a single object uses little memory – using many of them can cause trouble, so you need to make the objects lighter by sharing code.

**How to implement?** 

Separate the data that’s not specific to a single instance of that object and can be shared across all of them. You can do that by creating a new class and put the shared data in it. Then each object that should share data gets a reference to a single instance of that "storage" class.

**When is it useful?**

- If you make Minecraft and have a million cubes in the scene. All cubes can share the same texture if you put all textures that belongs to each cube type (grass, stone, sand, etc) into a [texture atlas](https://en.wikipedia.org/wiki/Texture_atlas).

- If you make a strategy game, all infantry units share the same mesh, texture, animation, maxHealth settings, etc. You only need to create one object with this data and then all infantry units can share that object. Each individual infantry unit only need to keep track of its own position and health.   

- This is implemented in Unity as [sharedMesh](https://docs.unity3d.com/ScriptReference/MeshFilter-sharedMesh.html) and [sharedMaterial](https://docs.unity3d.com/ScriptReference/Renderer-sharedMaterial.html). If you make a change to a sharedMesh then all objects using that mesh will get a new mesh. 

- In an open world game you can use the trees and rocks multiple times by rotating and scaling them - and no-one will see they are the same model.

- If you make a car game it is enough to use one crash sound - and then change the settings of that sound, such as pitch, to create different crash sounds every time the car crashes.  

**Related patterns**

- **Type Object.** The main difference is that in Type Object you don't need to have the exact same data and you can also have behavior. 


## [Back](../)