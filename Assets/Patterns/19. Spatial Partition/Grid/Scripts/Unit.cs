using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition.Grid
{
    //Code for one unit on a grid
    public class Unit : MonoBehaviour
    {
        //The body is child to an empty game object
        public GameObject unitBody;
    
        private Grid grid;

        //Pointers to other units so we can put them in a doubly-linked-list
        //We dont want these to show up in the inspector
        [System.NonSerialized] public Unit prev;
        [System.NonSerialized] public Unit next;

        //So we can change the unit's color
        private MeshRenderer meshRenderer;

        private Color unitColor;



        public void InitUnit(Grid grid, Vector3 startPos)
        {
            this.grid = grid;

            transform.position = startPos;

            prev = null;
            next = null;

            //Add the unit to the grid
            grid.Add(this);

            meshRenderer = unitBody.GetComponent<MeshRenderer>();

            //Give it a random color
            unitColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

            LookingForFight();
        }
        

        public void Move(Vector3 newPos)
        {
            //transform.position = newPos;

            grid.Move(this, newPos);
        }


        //To see that the unit is fighting we change the color
        public void Fight()
        {
            meshRenderer.sharedMaterial.color = Color.red;
        }

        public void LookingForFight()
        {
            meshRenderer.sharedMaterial.color = unitColor;
        }
    }
}
