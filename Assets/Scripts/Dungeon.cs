using System.Collections;
using System.Collections.Generic;
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

    public Room[] rooms;
    public int size; //inherits from DungeonGeneration script
    public int playerPos;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
