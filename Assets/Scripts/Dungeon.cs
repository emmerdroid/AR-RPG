using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    //dungeon is gonna contain the rooms in an array,
    //the array will just be 1 dimension
    //using a 3x3 example

    /// <summary>
    /// [0][1][2]
    /// [3][4][5]
    /// [6][7][8]
    /// 
    /// will be represented as [0,1,2,3,4,5,6,7,8]
    /// </summary>
    // lets say user starts at room 0, there only options will be to go 
    // left or down
    // left will equal + 1
    // down will equal + 3 
    // with this knowledge know that
    // right will equal - 1
    // up will equal - 3

    public GameObject[] rooms; //list of possible rooms
    public GameObject[] dungeonRooms; //actual layout of rooms; currently premade
    public int size; //inherits from RoomSpawner script
    public int playerPos; //get the player position in the array
    public GameObject currentRoom; //prefab that handles current room being displayed. 
    public GameObject player;

    public float scale;

    
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionToRoom(Movement.DIRECTION direction)
    {
       //move the dungeon based on direction units appear to be around 5.25

        if (direction == Movement.DIRECTION.up)
        {
            //since the player goes up, the map will move down
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (5.25f * scale));
            player.transform.position = new Vector3(0, 2, -1.5f) * scale;
        }
        if (direction == Movement.DIRECTION.down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5.25f * scale);
            player.transform.position = new Vector3(0, 2, 1.5f) * scale;
        }
        if(direction == Movement.DIRECTION.left) 
        {
            transform.position = new Vector3(transform.position.x + (5.25f * scale), transform.position.y, transform.position.z);
            player.transform.position = new Vector3(1.5f, 2, 0) * scale;
        }
        if(direction == Movement.DIRECTION.right)
        {
            transform.position = new Vector3(transform.position.x - (5.25f * scale), transform.position.y, transform.position.z);
            player.transform.position = new Vector3(-1.5f, 2, 0) * scale;
        }

        
    }

   
}
