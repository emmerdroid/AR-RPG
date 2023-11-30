using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    //refrencing https://github.com/BlackthornProd/Random-Dungeon-Generation 
    // Start is called before the first frame update

    public string Direction;
    int random;
    private RoomTypes roomType;
    [SerializeField]private bool roomPresent = false;
    int limit = 6;
    int ammount;
    [SerializeField] Dungeon dungeonController;





    void Start()
    {
        //Destroy(gameObject, 2f);
        roomType = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTypes>();
        Invoke("Spawn", 0.2f);
        ammount = 0;
        dungeonController = FindObjectOfType<Dungeon>();
    }

    // Update is called once per frame
    void Spawn()
    {
        if(roomPresent == false && ammount < limit)
        {

            if(Direction == "Up")
            {
                //have room with a Down
                random = Random.Range(0, roomType.bottomRooms.Length);
                var room = Instantiate(roomType.bottomRooms[random], transform.position, roomType.bottomRooms[random].transform.rotation);
                room.transform.localScale = room.transform.localScale * dungeonController.scale;
                room.transform.parent = gameObject.transform;
                ammount++;
            }
            else if(Direction == "Down")
            {
                //have a room with an Up
                random = Random.Range(0, roomType.topRooms.Length);
                var room = Instantiate(roomType.topRooms[random], transform.position, roomType.topRooms[random].transform.rotation);
                room.transform.localScale = room.transform.localScale * dungeonController.scale;
                room.transform.parent = gameObject.transform;
                ammount++;
            }
            else if (Direction =="Right")
            {
                //have a room with a Left
                random = Random.Range(0, roomType.leftRooms.Length);
                var room = Instantiate(roomType.leftRooms[random], transform.position, roomType.leftRooms[random].transform.rotation);
                room.transform.localScale = room.transform.localScale * dungeonController.scale;
                room.transform.parent = gameObject.transform;
                ammount++;

            }
            else if (Direction == "Left")
            {
                //have a room with a Right
                random = Random.Range(0, roomType.rightRooms.Length);
                var room = Instantiate(roomType.rightRooms[random], transform.position, roomType.rightRooms[random].transform.rotation) ;
                room.transform.localScale = room.transform.localScale * dungeonController.scale;
                room.transform.parent = gameObject.transform;

                ammount++;
            }

            roomPresent = true;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().roomPresent == false && roomPresent == false)
            {
                //call closed rooms
                //Instantiate(roomType.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject); 
            }
            roomPresent = true;
        }
    }
}
