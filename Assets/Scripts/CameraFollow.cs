using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float smoothing;

    
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            transform.LookAt(target);

            transform.position = Vector3.Lerp(transform.position,
                desiredPosition, smoothing * Time.deltaTime);
        }


    }
}
