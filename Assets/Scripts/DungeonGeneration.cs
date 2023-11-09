using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{

    public GameObject[] rooms;
    public int dungeonSize;
    public Dungeon gen_Dungeon;

    //use the dungeonSize to create an n x n grid,
    //attach the room types together to create this dungeon. 

    //the rooms have colliders, will need to find a way to have them connect with the colliders
    //as the point of connection
    //each room is a 5x5 unity unit area
    // when going through need to transfer data of the direction and to go to the next room
    //on the map
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
