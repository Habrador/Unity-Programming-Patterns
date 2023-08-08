# 16. Data Locality

Have you done all optimizations you can possible do? Is the game still too slow? Then this pattern may help you. It can make your game faster by accelerating memory access.   

**How to implement?**

You have to arrange data to take advantage of CPU caching. The basic idea is that you should organize your data structures so that the things you're processing are next to each other in memory. This is a big topic and can't be summarized here, so you should read about it in the book "Game Programming Patterns."

This Unity article suggest that you should use struct instead of class because they are more cache friendly [How to Write Faster Code Than 90% of Programmers](https://jacksondunstan.com/articles/3860). 

Unity has implemented this pattern in their [Data-Oriented Technology Stack (DOTS)](https://unity.com/dots).

A good Unity tutorial on the topic is: [Unity Memory Profiler: Where Are You Wasting Your Game's Memory?](https://thegamedev.guru/unity-memory/profiler-part-1/) and [Part 2](https://thegamedev.guru/unity-memory/profiler-part-2/). 

**When is it useful?**

- According to the book "Game Programming Patterns," this pattern should be used when everything else has failed. It's a waste of time to optimize code that doesn't need to be optimized - and it may also make the code more complicated to understand. You also have to make sure that cache misses is the reason your code is slow, so you first have to measure it.


## [Back](../)