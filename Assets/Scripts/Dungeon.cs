using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class Dungeon : MonoBehaviour
{
   

    public GameObject[] rooms; //list of possible rooms
    public GameObject[] dungeonRooms; //actual layout of rooms; currently premade
    public int size; //inherits from RoomSpawner script
    public int playerPos; //get the player position in the array
    public GameObject currentRoom; //prefab that handles current room being displayed. 
    public GameObject player;
    public GameObject AROrigin;
    public GameObject upEnt, downEnt, leftEnt, rightEnt;
    public float scale;

    
    // Start is called before the first frame update
    void Start()
    {
        AROrigin = FindObjectOfType<ARSessionOrigin>().gameObject;
       
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
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (5 * scale));
            player.transform.position = downEnt.transform.position;
        }
        if (direction == Movement.DIRECTION.down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (5f * scale));
            player.transform.position = upEnt.transform.position;
        }
        if(direction == Movement.DIRECTION.left) 
        {
            transform.position = new Vector3(transform.position.x + (5f * scale), transform.position.y, transform.position.z);
            player.transform.position = rightEnt.transform.position;
        }
        if(direction == Movement.DIRECTION.right)
        {
            transform.position = new Vector3(transform.position.x - (5f * scale), transform.position.y, transform.position.z);
            player.transform.position = leftEnt.transform.position;
        }

        
    }

   
}
