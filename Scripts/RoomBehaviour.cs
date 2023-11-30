using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls; //setup to have walls with position 0-North, 1-South, 2-East, 3-West
    public GameObject[] doors; //same with doors


    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void updateRoom(bool[] isOpen) //when ever one of the walls is set to true then the corresponding door is set to true/active.
    {
        for (int i = 0; i<isOpen.Length; i++)
        {
            doors[i].SetActive(isOpen[i]);
            walls[i].SetActive(!isOpen[i]);
        }
    }

}
