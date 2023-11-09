using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //things the room should do:
        //keep track of doorways so entrances/exits--Done
        //number of enemies in a room
        //rooms will combine to become a dungeon
        //should know what room is next from up/down or left/right--Done
        //dungeons will be an n x n grid, rooms are 5x5 unity units

    // Start is called before the first frame update

   
    public BoxCollider[] doorways;
    


    //calculate the new position the player will teleport in.
    public Vector3 GetEntryPoint(Movement.DIRECTION direction)
    {
        switch(direction)
        {

        //if the player comes from up, teleport down (down coll is at (0, 0, -2.25)
        case Movement.DIRECTION.up: return new Vector3(0,1,-2f);
            //if the player comes from down, teleport up (0,0,2.25)
        case Movement.DIRECTION.down: return new Vector3(0, 1, 2f);
            //if the player comes from left, teleport right (2.25, 0,0)
        case Movement.DIRECTION.left: return new Vector3(2f, 1, 0);
            //if the player comes from right, teleport left
        case Movement.DIRECTION.right: return new Vector3(-2f, 1, 0);
            default:
                return new Vector3(0, 0, 0);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Room Clear");
    }
}
