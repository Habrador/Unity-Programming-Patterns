# 19. Spatial Partition

If you have many objects in your game, store the objects in a data structure that organizes the objects by their positions. This should make it faster to for example find which objects are colliding.  

**How to implement?**  

This is a common pattern, so you have several choices:

- **Grid.** Divide the area into a grid and store in the data structure in which cell each object is located. This is the example from the book, so you can find the code for it in the code section. An alternative implementation can be found here: [Find overlaps among thousands of objects blazing fast](https://github.com/Habrador/Ten-Minute-Physics-Unity) which is implementing "Spatial Hashing" meaning that you are no longer bounded to a fixed grid - you can use a grid of infinite size!

- **Trie.** Is actually called [Trie](https://en.wikipedia.org/wiki/Trie) and not Tree! 
	- [Quadtree (2d space)](https://en.wikipedia.org/wiki/Quadtree). Divide the square area into 4 cells. But if too many objects are in the same cell, divide that cell into 4 new cells. Continue until there are not "too many objects in the same cell." A good tutorial can be found here: [Coding Challenge #98.1: Quadtree - Part 1](https://www.youtube.com/watch?v=OJxEcs0w_kE).
	- [Octree (3d space)](https://en.wikipedia.org/wiki/Octree). Is similar to Quadtree, but instead of cells you use cubes, so divide a cube volume into 8 cubes, and then split each cube into 8 new cubes and so on.

- **Binary search trees.** The name is binary, so the difference between Tree is that you split the groups into 2 smaller groups, and then you split one of the smaller groups into 2 smaller groups, and so on.  
	- [Binary space partition (BSP)](https://en.wikipedia.org/wiki/Binary_space_partitioning). You use a plane to split a group into 2 new groups. And then you use another plane to split the new group into 2 new groups, and so on until you are finished.  
	- [k-d trees](https://en.wikipedia.org/wiki/K-d_tree). In this case it has to be points that you split into smaller, and smaller groups. 
	- [Bounding volume hierarchy](https://en.wikipedia.org/wiki/Bounding_volume_hierarchy). You pick a bounding volume (or area in 2d space), such as a rectangle. The size of the first rectangle is determined so all objects fit within it. Then you split the rectangle into two new rectangles, and so on.   

If the objects move you have to update the data structure. These data stuctures are also using more memory meaning you have to measure that putting the objects in a data structure is faster than just searching for the closest object. 

**When is it useful?**

- Find the closest object to a character. This can be a really slow process if you have hundreds of objects around the character. And if you have soldiers fighting soldiers, you have to make that search for each soldier. A better way is to divide the search-area so you don't have to search thorough all objects - just the ones closest to you.

- To increase the performance of collision detection and raytracing.

- To deactivate objects if they are far away from your character to improve performance. This is called culling. You can hide for example trees and AI far away don't have to update themselves.   

- In games with pathfinding, spatial partitioning can help optimize the search for valid paths. By organizing the game world into a navigation grid or spatial data structure, pathfinding algorithms can be restricted to search only within relevant partitions, reducing computation time.


## [Back](../)