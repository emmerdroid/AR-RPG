using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    //find the player
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>().transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //stay on the Y axis
        transform.position = new Vector3(transform.position.x,
            player.gameObject.GetComponent<Movement>().Y_Constraint.transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("Hit the Player, Chest Found");
            Invoke(" SceneManager.LoadScene(\"Victory\")", 1f);
            


        }
    }
}
