using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //things the room should do:
        //keep track of doorways so entrances/exits
        //number of enemies in a room
        //rooms will combine to become a dungeon
        //should know what room is next from up/down or left/right
        //dungeons will be an n x n grid, rooms are 5x5 unity units

    // Start is called before the first frame update

    public GameObject doors;
    public BoxCollider[] doorways;
    void Start()
    {
        GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
