using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider coll;
    [SerializeField] float speed;
    public enum DIRECTION{up, down, left, right};
    public DIRECTION dir;
    public DIRECTION cameFrom;

    [SerializeField] FixedJoystick joyStick;
    public GameObject Y_Constraint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        //Invoke("EnableGravity", 0.3f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //noves in direction of joystick
        rb.velocity = new Vector3(joyStick.Horizontal * speed, rb.velocity.y, joyStick.Vertical * speed);
        //rotate in accordance to the joystick
        if(joyStick.Horizontal != 0 && joyStick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            Quaternion.Euler(0,0,0);
        }


        
    }

    private void Update() {
        //calculate the diredtion

        Vector2 normalizedVector = new Vector2(rb.velocity.x, rb.velocity.z).normalized;

        //keep Y to y constraint
        transform.position = new Vector3(transform.position.x, 
            Y_Constraint.transform.position.y, transform.position.z);
        
    }

    void EnableGravity()
    {
        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Doorway")) 
        {
            if (other.name == "UpCol")
            {
                cameFrom = DIRECTION.up;
            }
            else if (other.name == "DownCol")
            {
                cameFrom = DIRECTION.down;
            }

            else if (other.name == "LeftCol")
            {
                cameFrom = DIRECTION.left;
            }
            else if(other.name == "RightCol")
            {
                cameFrom = DIRECTION.right;
            }



            FindObjectOfType<Dungeon>().TransitionToRoom(cameFrom);
           
        }
    }

    
}
