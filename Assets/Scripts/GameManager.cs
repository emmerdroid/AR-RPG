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

    //getter and setter
    public float PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    //dungeon transformation
    private Vector3 dungeonPosition;

    //getter and setter for dungeon position
    public Vector3 DungeonPosition
    {
        get { return dungeonPosition; }
        set { dungeonPosition = value; }
    }

    public void DamagePlayer(float damageAmount)
    {
        playerHealth -= damageAmount;

        //checking that player is dead
        if(playerHealth <= 0) 
        {
            Debug.Log("You Died Game Over");

            //go to a game over scene or something


        }
    }

    public void LoadCombatScene()
    {
        //saving the dungeon position
        dungeonPosition = GameObject.FindAnyObjectByType<Dungeon>().gameObject.transform.position;
        //Load the combat scene additive
        SceneManager.LoadScene("ProperCombat", LoadSceneMode.Additive);

    }

    public void ReturnToDungeon()
    {
        //unloading the combat scene
        SceneManager.UnloadSceneAsync("ProperCombat");

        //have the dungeon position properly moved
        GameObject.FindAnyObjectByType<Dungeon>().gameObject.transform.position = dungeonPosition;

    }


}
