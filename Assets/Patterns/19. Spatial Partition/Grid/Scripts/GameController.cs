using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition.Grid
{
    //Implementation of the Spatial Partion pattern from the book Game Programming Patterns
    //The units change color if the can fight each other, and that color remains for some time to see that its working
    public class GameController : MonoBehaviour
    {
        //Drags
        public Unit unitPrefab;

        public Transform unitParentTrans;

        //Private
        private Grid grid;

        //The number of units moving on the map
        private const int NUMBER_OF_UNITS = 100;

        //To keep track of all units so we can move them
        private HashSet<Unit> allUnits = new HashSet<Unit>();

        //Display the grid with lines

        //Grid material
        private Material gridMaterial;

        //Grid mesh
        private Mesh gridMesh;



        void Start()
        {
            grid = new Grid();

            float battlefieldWidth = Grid.NUM_CELLS * Grid.CELL_SIZE;

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



        private void LateUpdate()
        {
            //Display the grid with lines
            if (gridMaterial == null)
            {
                gridMaterial = new Material(Shader.Find("Unlit/Color"));

                gridMaterial.color = Color.black;
            }

            if (grid == null)
            {
                return;
            }

            if (gridMesh == null)
            {
                gridMesh = InitGridMesh();
            }

            //Display the mesh
            Graphics.DrawMesh(gridMesh, Vector3.zero, Quaternion.identity, gridMaterial, 0, Camera.main, 0);
        }



        private Mesh InitGridMesh()
        {
            //Generate the vertices
            List<Vector3> lineVertices = new ();

            float battlefieldWidth = Grid.NUM_CELLS * Grid.CELL_SIZE;

            Vector3 linePosX = Vector3.zero;
            Vector3 linePosY = Vector3.zero;

            for (int x = 0; x <= Grid.NUM_CELLS; x++)
            {
                lineVertices.Add(linePosX);
                lineVertices.Add(linePosX + Vector3.right * battlefieldWidth);

                lineVertices.Add(linePosY);
                lineVertices.Add(linePosY + Vector3.forward * battlefieldWidth);

                linePosX += Vector3.forward * Grid.CELL_SIZE;
                linePosY += Vector3.right * Grid.CELL_SIZE;
            }


            //Generate the indices
            List<int> indices = new ();

            for (int i = 0; i < lineVertices.Count; i++)
            {
                indices.Add(i);
            }


            //Generate the mesh
            Mesh gridMesh = new ();

            gridMesh.SetVertices(lineVertices);
            gridMesh.SetIndices(indices, MeshTopology.Lines, 0);


            return gridMesh;
        }
    }
}
