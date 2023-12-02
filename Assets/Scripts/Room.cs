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
    public BoxCollider area;
    public GameObject room;
    [SerializeField] bool isEmpty;
    public Dungeon mainDungeon;
    public GameObject enemy;
    private void Start()
    {
        isEmpty = true;
        mainDungeon = FindObjectOfType<Dungeon>();
        Invoke("GetArea", .2f);

        //have a chance of spawning an enemy in the room 1/10 chance
        if(Random.Range(0,10) == 1)
        {
            var enemySpawned = Instantiate(enemy, transform.position, enemy.transform.rotation);
            enemySpawned.transform.localScale = enemy.transform.localScale * mainDungeon.scale;
            enemySpawned.transform.parent = gameObject.transform;
            
        }
        

    }
    public void GetArea()
    {
        area = GetComponent<BoxCollider>();
        area.enabled = true;

    }
    private void FixedUpdate()
    {
        //if (isEmpty)
        //{
        //    room.SetActive(false);
        //}


    }




    //calculate the new position the player will teleport in.
    public Vector3 GetEntryPoint(Movement.DIRECTION direction)
    {
        switch(direction)
        {

        //if the player comes from up, teleport down (down coll is at (0, 0, -2.25)
        case Movement.DIRECTION.up: return new Vector3(0,1,-2f) * mainDungeon.scale;
            //if the player comes from down, teleport up (0,0,2.25)
        case Movement.DIRECTION.down: return new Vector3(0, 1, 2f) * mainDungeon.scale;
            //if the player comes from left, teleport right (2.25, 0,0)
        case Movement.DIRECTION.left: return new Vector3(2f, 1, 0) * mainDungeon.scale;
            //if the player comes from right, teleport left
        case Movement.DIRECTION.right: return new Vector3(-2f, 1, 0) * mainDungeon.scale;
                    
            default:
                return new Vector3(0, 0, 0);
        }
    }

    //private void OnDestroy()
    //{
    //    //Debug.Log("Room Clear");
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    // Debug.Log("Something inside");
    //    if (other.CompareTag("Player"))
    //    {
    //        room.SetActive(true);
    //        //Debug.Log("Player Inside");
    //    }
    //    isEmpty = false;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("Something Entered");
    //    if (other.CompareTag("Player"))
    //    {
    //        room.SetActive(true);
    //        //Debug.Log("Player Entered");
    //    }
    //    isEmpty = false;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //Debug.Log("Something Exited");
    //    if (other.CompareTag("Player"))
    //    {
    //        room.SetActive(false);
    //        //Debug.Log("Player exited");
    //        isEmpty = true;
    //    }
    //}

}
