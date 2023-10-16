using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custim_Joystick : MonoBehaviour
{

    [SerializeField] GameObject player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA, pointB;
    public Transform innerCircle, outerCircle; 

    public RectTransform canvasInnerCircle, canvasOuterCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            innerCircle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;

            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;


        }


        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MoveCharacter(direction * -1);

            innerCircle.transform.position = new Vector2(pointA.x + direction.x,
                pointA.y + direction.y) * -1;
        }
        else
        {
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        Vector3 properDirection = new Vector3(direction.x, 0, direction.y);
        player.transform.Translate(properDirection * speed * Time.deltaTime);
    }
}
