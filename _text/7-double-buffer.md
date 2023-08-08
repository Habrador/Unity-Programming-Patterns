# 7. Double Buffer

You have two buffers: you update #1 with new data while you are not allowed to modify #2 because #2 is holding old data from previous update, which you might want to display on the screen or use when updating #1. When you have finished updating #1, you swap them, so #2 is now including fresh data and you can start updating #1 which is now including old data.

**How to implement?**

You can have two arrays. You write to one of them, and when the calculations are finished you swap the pointer to the arrays. 

**When is it useful?**

- To display stuff on the screen. This is already built-in into you computer which uses two buffers to display stuff on the screen. It reads from #2 while #1 is being updated with new data. When #1 is finished updating, the buffers are switched, so now you will see the newly updated data on the screen. It would look strange if you used just one buffer because then one part of the screen would display old data and one new data in some kind of horrible mix.

- To generate motion blur. The current buffer is blended with a bit of the previous buffer. 

- Cellular Automata (CA). In games it's common to store data in a grid (which is a 2d array). To calculate new data you combine data from the cells, such as the maximum value of the current cell and surrounding cells. But where are you storing the data for the cell you just calculated? You can't store it in the cell because that will screw up the calculations for neighboring cells because you always want to use old data when doing the calculations. So you use two grids: #2 holds the old data and #1 is using #2 to update itself. When the calculations are finished, you swap them. 

	- Cave-generation. This is the example I've included in the code. 
	
	- [Water](http://www.jgallant.com/2d-liquid-simulator-with-cellular-automaton-in-unity/). You simulate movement of water on a grid.
	
	- [Forest fire](https://www.youtube.com/watch?v=JtGp9eUugFs). You store in each cell the amount of burning material in that cell, then you simulate heat to ignite the material. When there's no more material to burn, the heat disappears.  
	

## [Back](../) 