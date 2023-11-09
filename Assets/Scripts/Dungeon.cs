using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    public GameObject[] rooms;
    public int size; //inherits from DungeonGeneration script
    public int playerPos; //get the player position in the array
    public GameObject currentRoom; //prefab that handles current room being displayed. 
    public GameObject player;

    int dungeonWidth;

    
    // Start is called before the first frame update
    void Start()
    {
        dungeonWidth = Mathf.FloorToInt(Mathf.Sqrt(size));
        currentRoom = Instantiate(rooms[0]);
        playerPos = 0;
       
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionToRoom(Movement.DIRECTION direction)
    {
        //calculate what room the player is in.
        int newIndex = CalculateNewRoomIndex(direction);
        //create new room
        GameObject newRoom = Instantiate(rooms[newIndex], this.transform.position, Quaternion.identity);
        //teleport the player to the corresponding position
        player.transform.position = newRoom.GetComponent<Room>().GetEntryPoint(direction);
        //delete the old room
        if(currentRoom != null)
        {
            Destroy(currentRoom);

        }
        

        currentRoom = newRoom;
    }

    int CalculateNewRoomIndex(Movement.DIRECTION direction)
    {

        //get current Index which is int PlayerPos

        switch(direction)
        {
            case Movement.DIRECTION.up:
                if (playerPos >= dungeonWidth) { playerPos -= dungeonWidth; } break;
            case Movement.DIRECTION.down:
                if (playerPos < dungeonWidth) { playerPos += dungeonWidth; } break;
            case Movement.DIRECTION.left:
                if(playerPos % dungeonWidth != 0) { playerPos--; } break;
            case Movement.DIRECTION.right:
                if((playerPos+1)%dungeonWidth != 0) { playerPos++; } break;
        }
         
        return playerPos;
    }
}
