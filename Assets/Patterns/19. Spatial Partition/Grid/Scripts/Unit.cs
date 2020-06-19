using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition.Grid
{
    //Code for one unit on a grid
    public class Unit : MonoBehaviour
    {
        //The body is child to an empty game object so we need an extra reference to it so we can change its color
        public GameObject unitBody;
    
        private Grid grid;

        //Pointers to other units so we can put them in a doubly-linked-list
        //We dont want these to show up in the inspector
        [System.NonSerialized] public Unit prev;
        [System.NonSerialized] public Unit next;

        //So we can change the unit's color
        private MeshRenderer meshRenderer;

        //Unit data
        private Color unitColor;

        private float unitSpeed;

        //If two units are within this distance they can attack each other
        public const float ATTACK_DISTANCE = 1.0f;



        public void InitUnit(Grid grid, Vector3 startPos)
        {
            this.grid = grid;

            transform.position = startPos;

            prev = null;
            next = null;

            //Add the unit to the grid
            grid.Add(this, isNewUnit: true);

            meshRenderer = unitBody.GetComponent<MeshRenderer>();

            //Give it a color
            unitColor = Color.white;

            meshRenderer.material.color = unitColor;

            //Give it a random speed so all units are not the same
            unitSpeed = Random.Range(1f, 5f);

            //Give it a random direction
            transform.rotation = GetRandomDirection();
        }
        


        //Move the unit one time step
        public void Move(float dt)
        {
            Vector3 oldPos = transform.position;

            Vector3 newPos = oldPos + transform.forward * unitSpeed * dt;

            //Is the new position a valid position inside of the grid?
            bool isValid = grid.IsPosValid(newPos);

            if (isValid)
            {
                transform.position = newPos;

                //Update the grid because the unit might have changed cell
                grid.Move(this, oldPos, newPos);
            }
            else
            {
                //We are outside of the grid, so don't move the character but change the rotation so we don't get stuck
                transform.rotation = GetRandomDirection();
            }
        }



        //Generate a quaternion with a random rotation around y axis
        private Quaternion GetRandomDirection()
        {
            Quaternion randomDir = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));

            return randomDir;
        }



        //Change color so we can see that the unit is fighting
        public void StartFighting()
        {
            StopCoroutine(FightCooldown());
        
            StartCoroutine(FightCooldown());
        }



        //Coroutine so we can change back to the original color after some time
        private IEnumerator FightCooldown()
        {
            meshRenderer.sharedMaterial.color = Color.red;

            yield return new WaitForSeconds(1f);

            meshRenderer.sharedMaterial.color = unitColor;
        }
    }
}
