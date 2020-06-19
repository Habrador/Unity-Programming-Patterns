using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartition.Grid
{
    //The grid class which will also handle fighting
    public class Grid
    {
        public const int NUM_CELLS = 10;

        public const int CELL_SIZE = 5;
    
        private Unit[,] cells = new Unit[NUM_CELLS, NUM_CELLS];

        //How many units do we have on the grid, which should be faster than to iterate through all cells and count them
        public int unitCount { get; private set; }



        public Grid()
        {
            //Clear the grid
            for (int x = 0; x < NUM_CELLS; x++)
            {
                for (int y = 0; y < NUM_CELLS; y++)
                {
                    cells[x, y] = null;
                }
            }
        }



        //Add unit to grid
        //This is also used when a unit already on the grid is moving into a new cell
        public void Add(Unit newUnit, bool isNewUnit = false)
        {
            //Determine which grid cell it's in
            Vector2Int cellPos = ConvertFromWorldToCell(newUnit.transform.position);

            //Add the unit to the front of list for the cell it's in
            newUnit.prev = null;
            newUnit.next = cells[cellPos.x, cellPos.y];

            //Associate the cell with this unit
            cells[cellPos.x, cellPos.y] = newUnit;

            //If there already was a unit in this cell, it should point to the new unit
            if (newUnit.next != null)
            {
                Unit nextUnit = newUnit.next;
                
                nextUnit.prev = newUnit;
            }

            if (isNewUnit)
            {
                unitCount += 1;
            }
        }



        //Move a unit on the grid = see if it has changed cell
        //Make sure newPos is a valid position inside of the grid
        public void Move(Unit unit, Vector3 oldPos, Vector3 newPos)
        {
            //See what cell it was in before we assign the new position
            Vector2Int oldCellPos = ConvertFromWorldToCell(oldPos);

            //See which cell it's moving to
            Vector2Int newCellPos = ConvertFromWorldToCell(newPos);

            //If it didn't change cell, we are done
            if (oldCellPos.x == newCellPos.x && oldCellPos.y == newCellPos.y)
            {
                return;
            }

            //Unlink it from the list of its old cell
            UnlinkUnit(unit);

            //If this unit is the head of a linked-list in this cell, remove it
            if (cells[oldCellPos.x, oldCellPos.y] == unit)
            {
                cells[oldCellPos.x, oldCellPos.y] = unit.next;
            }

            //Add it back to the grid at its new cell
            Add(unit);
        }



        //Unlink a unit from its linked list
        private void UnlinkUnit(Unit unit)
        {
            if (unit.prev != null)
            {
                //The previous unit should get a new next
                unit.prev.next = unit.next;
            }

            if (unit.next != null)
            {
                //The next unit should get a new prev
                unit.next.prev = unit.prev;
            }            
        }



        //Help method to convert from Vector3 to cell pos
        public Vector2Int ConvertFromWorldToCell(Vector3 pos)
        {
            //Dividing coordinate by cell size converts from world space to cell space
            //Casting to int converts from cell space to cell index
            //int cellX = (int)(pos.x / CELL_SIZE);
            //int cellY = (int)(pos.z / CELL_SIZE); //z instead of y because y is up in Unity's coordinate system

            //Casting to int in C# doesnt work in same way as in C++ so we have to use FloorToInt instead
            //It works like this if cell size is 2:
            //pos.x is 1.8, then cellX will be 1.8/2 = 0.9 -> 0
            //pos.x is 2.1, then cellX will be 2.1/2 = 1.05 -> 1
            int cellX = Mathf.FloorToInt(pos.x / CELL_SIZE);
            int cellY = Mathf.FloorToInt(pos.z / CELL_SIZE); //z instead of y because y is up in Unity's coordinate system

            Vector2Int cellPos = new Vector2Int(cellX, cellY);

            return cellPos;
        }



        //Test if a position is a valid position (= is inside of the grid)
        public bool IsPosValid(Vector3 pos)
        {
            Vector2Int cellPos = ConvertFromWorldToCell(pos);

            if (cellPos.x >= 0 && cellPos.x < NUM_CELLS && cellPos.y >= 0 && cellPos.y < NUM_CELLS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //
        // Fighting
        //

        //Make the units fight
        public void HandleMelee()
        {
            //Loop through all cells
            for (int x = 0; x < NUM_CELLS; x++)
            {
                for (int y = 0; y < NUM_CELLS; y++)
                {
                    HandleCell(x, y);
                }
            }
        }



        //Handles fight for a single cell
        private void HandleCell(int x, int y)
        {
            Unit unit = cells[x, y];

            //Make each unit fight all other units once in this cell
            //It works like this: If the units in the cell are linked like: A-B-C-D
            //We always start with the first unit A, which we get from the cells[x, y]
            //Loop 1: A vs B, C, D. Change to unit B
            //Loop 2: B vs C, D. Change to unit C. (A-B where fighting in round 1, so they dont need to fight again)
            //Loop 3: C vs D. Change to unit D (C-A and C-B have already been fighting)
            //Loop 4: unit will be null so the loop will terminate
            while (unit != null)
            {
                //Try to fight other units in this cell
                HandleUnit(unit, unit.next);

                //We also should try to fight units in the 8 surrounding cells because some of them might be within the attack distance
                //But we cant check all 8 cells because then some units might fight each other two times, so we only check half (it doesnt matter which half)
                //We also have to check that there's a surrounding cell because the current cell might be the border
                //This assumes attack distance is less than cell size, or we might have to check more cells
                if (x > 0 && y > 0)
                {
                    HandleUnit(unit, cells[x - 1, y - 1]);
                }
                if (x > 0)
                {
                    HandleUnit(unit, cells[x - 1, y - 0]);
                }
                if (y > 0)
                {
                    HandleUnit(unit, cells[x - 0, y - 1]);
                }
                if (x > 0 && y < NUM_CELLS - 1)
                {
                    HandleUnit(unit, cells[x - 1, y + 1]);
                }

                unit = unit.next;
            }
        }



        //Handles fight for a single unit vs a linked-list of units
        private void HandleUnit(Unit unit, Unit other)
        {
            while (other != null)
            {
                //Make them fight if they have similar position - use square distance because it's faster
                if ((unit.transform.position - other.transform.position).sqrMagnitude < Unit.ATTACK_DISTANCE * Unit.ATTACK_DISTANCE)
                {
                    HandleAttack(unit, other);
                }

                other = other.next;
            }
        }

        

        //Handles attack between two units
        private void HandleAttack(Unit one, Unit two)
        {
            //Insert fighting mechanic
            one.StartFighting();
            two.StartFighting();
        }
    }
}
