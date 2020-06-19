using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition.Grid
{
    //Implementation of the Spatial Partion pattern from the book Game Programming Patterns
    //The units change color if the can fight each other, and that color remains for some time to see that its working
    public class GameController : MonoBehaviour
    {
        //Drags
        public GameObject battlefieldObj;

        public Unit unitPrefab;

        public Transform unitParentTrans;

        //Private
        private Grid grid;

        //The number of units we start with
        private const int NUMBER_OF_UNITS = 100;

        //To keep track of all units so we can move them
        private HashSet<Unit> allUnits = new HashSet<Unit>();



        void Start()
        {
            grid = new Grid();


            //Make the battlefield the same size as the grid
            float battlefieldWidth = Grid.NUM_CELLS * Grid.CELL_SIZE;

            battlefieldObj.transform.localScale = new Vector3(battlefieldWidth, 1f, battlefieldWidth);

            //The grid starts at origo, so we need to change position as well
            battlefieldObj.transform.position = new Vector3(battlefieldWidth * 0.5f, 0f, battlefieldWidth * 0.5f);


            //Add units within the grid at random positions
            for (int i = 0; i < NUMBER_OF_UNITS; i++)
            {
                float randomX = Random.Range(0f, battlefieldWidth);
                float randomZ = Random.Range(0f, battlefieldWidth);

                Vector3 randomPos = new Vector3(randomX, 0f, randomZ);

                Unit newUnit = Instantiate(unitPrefab, parent: unitParentTrans) as Unit;

                //Init the unit which will also add it to the grid
                newUnit.InitUnit(grid, randomPos);

                allUnits.Add(newUnit);
            }
        }



        void Update()
        {
            //Move all units
            foreach (Unit unit in allUnits)
            {
                unit.Move(Time.deltaTime);
            }

            //Units attack each other
            grid.HandleMelee();
        }
    }
}
