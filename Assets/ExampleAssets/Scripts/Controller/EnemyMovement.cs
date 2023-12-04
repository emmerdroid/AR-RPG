using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius;
    public float speed;
    Transform target;
    public GameManager manager;

    //get reference to the dugneon scale
    public Dungeon mainDungeon;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Movement>().gameObject.transform;
        manager = GameManager.Instance;
        mainDungeon = FindObjectOfType<Dungeon>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position) * mainDungeon.scale;

        //do nothing/ idle
        if(distance > lookRadius * mainDungeon.scale * 0.25f)
        {
            Debug.Log("Idling doing nothing");
            Debug.Log($"{distance} and radius is {lookRadius * mainDungeon.scale}" );
        }

        else
        {
            Debug.Log($"{distance}" + $" player detected  radius is {lookRadius * mainDungeon.scale}");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        //stay on the Y axis
        transform.position = new Vector3(transform.position.x,
            target.gameObject.GetComponent<Movement>().Y_Constraint.transform.position.y, transform.position.z);

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void IdleMovements()
    {
        Vector3 startPosition = transform.position; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("Hit the Player, battle time");
            manager.SetEnemy(gameObject);
            manager.LoadCombatScene();


        }
    }

}
