using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class moveMarker : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(1331f, 333f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x - 2f, 333f, 0f);
        if(this.transform.localPosition.x <= -1330)
        {
            this.transform.localPosition = new Vector3(1331f, 333f, 0f);
        }
    }
}
