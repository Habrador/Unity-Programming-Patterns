using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoubleBuffer.Cave
{
    //Illustrate the Double Buffer game programming pattern by generating a cave pattern and display it on a plane
    //The idea is based on this Unity tutorial https://www.youtube.com/watch?v=v7yyZZjF1z4 
    public class GameController : MonoBehaviour
    {
        //Display the pattern on this plane
        public MeshRenderer displayPlaneRenderer;

        //Is used to init the cellular automata by spreading random dots on a grid
        //And from these dots we will generate caves
        //The higher the fill percentage, the smaller the caves
        [Range(0, 1)]
        public float randomFillPercent;

        //The double buffer
        //Notice that the Unity tutorial is using one buffer, which works but is not entirely correct because it results in a strong diagonal bias
        //Someone in the comment section is also complaining about it, so this is the correct version
        //Is storing int where 1 is wall and 0 is cave
        private int[,] bufferOld;
        private int[,] bufferNew;

        //The size of the grid
        private const int GRID_SIZE = 100;

        //How many steps do we want to simulate?
        private const int SIMULATION_STEPS = 20;

        //For how long will we pause between each simulation step so we can look at the result
        private float PAUSE_TIME = 1f;



        void Start()
        {
            bufferOld = new int[GRID_SIZE, GRID_SIZE];
            bufferNew = new int[GRID_SIZE, GRID_SIZE];

            //To get the same random numbers each time we run the script
            Random.InitState(100);

            //Init the old values so we can calculate the new values
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    //We dont want holes in our walls, so the border is always a wall
                    if (x == 0 || x == GRID_SIZE - 1 || y == 0 || y == GRID_SIZE - 1)
                    {
                        bufferOld[x, y] = 1;
                    }
                    //Random walls and caves
                    else
                    {
                        bufferOld[x, y] = Random.Range(0f, 1f) < randomFillPercent ? 1 : 0;
                    }
                }
            }
            
            //For testing that init is working
            //GenerateAndDisplayTexture(bufferOld);
            
            //Start the simulation
            StartCoroutine(SimulateCavePattern());
        }



        //Do the simulation in a coroutine so we can pause and see what's going on
        private IEnumerator SimulateCavePattern()
        {
            for (int i = 0; i < SIMULATION_STEPS; i++)
            {
                //Calculate the new values
                RunCellularAutomataStep();

                //Generate texture and display it on the plane
                GenerateAndDisplayTexture(bufferNew);

                //Swap the pointers to the buffers
                (bufferOld, bufferNew) = (bufferNew, bufferOld);

                yield return new WaitForSeconds(PAUSE_TIME);
            }

            Debug.Log("Simulation completed!");
        }



        //Generate caves by smoothing the data
        //Remember to always put the new results in bufferNew and use bufferOld to do the calculations
        private void RunCellularAutomataStep()
        {
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    //Border is always wall
                    if (x == 0 || x == GRID_SIZE - 1 || y == 0 || y == GRID_SIZE - 1)
                    {
                        bufferNew[x, y] = 1;

                        continue;
                    }

                    //Uses bufferOld to get the wall count
                    int surroundingWalls = GetSurroundingWallCount(x, y);

                    //Use some smoothing rules to generate caves
                    if (surroundingWalls > 4)
                    {
                        bufferNew[x, y] = 1;
                    }
                    else if (surroundingWalls == 4)
                    {
                        bufferNew[x, y] = bufferOld[x, y];
                    }
                    else
                    {
                        bufferNew[x, y] = 0;
                    }
                }
            }
        }



        //Given a cell, how many of the 8 surrounding cells are walls?
        private int GetSurroundingWallCount(int cellX, int cellY)
        {
            int wallCounter = 0;

            for (int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX ++)
            {
                for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++)
                {
                    //We dont need to care about being outside of the grid because we are never looking at the border
                
                    //This is the cell itself and no neighbor!
                    if (neighborX == cellX && neighborY == cellY)
                    {
                        continue;
                    }

                    //This neighbor is a wall
                    if (bufferOld[neighborX, neighborY] == 1)
                    {
                        wallCounter += 1;
                    }
                }
            }

            return wallCounter;
        }



        //Generate a black or white texture depending on if the pixel is cave or wall
        //Display the texture on a plane
        private void GenerateAndDisplayTexture(int[,] data)
        {
            //We are constantly creating new textures, so we have to delete old textures or the memory will keep increasing
            //The garbage collector is not collecting unused textures
            Resources.UnloadUnusedAssets();
            //We could also use 
            //Destroy(displayPlaneRenderer.sharedMaterial.mainTexture);
            //Or reuse the same texture


            //These two arrays are always the same so we could init them once at start
            Texture2D texture = new Texture2D(GRID_SIZE, GRID_SIZE);

            texture.filterMode = FilterMode.Point;

            Color[] textureColors = new Color[GRID_SIZE * GRID_SIZE];

            for (int y = 0; y < GRID_SIZE; y++)
            {
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    //From 2d array to 1d array
                    textureColors[y * GRID_SIZE + x] = data[x, y] == 1 ? Color.black : Color.white;
                }
            }

            texture.SetPixels(textureColors);

            texture.Apply();

            displayPlaneRenderer.sharedMaterial.mainTexture = texture;
        }
    }
}
