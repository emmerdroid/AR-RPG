using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton pattern to make sure only 1 instance exists
    private static GameManager instance;
    public static GameManager Instance 
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    //player health
    private float playerHealth = 100f;

    //dungeon transformation
    //private 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
