using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();

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
        
    }

    private void Update() {
        //calculate the diredtion

        Vector2 normalizedVector = new Vector2(rb.velocity.x, rb.velocity.z).normalized;
        
    }
}
