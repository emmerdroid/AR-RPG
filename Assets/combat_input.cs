using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combat_input : MonoBehaviour

{
    public Slider playerHP_Bar;
    public Slider enemyHP_Bar;
    public Image Marker;
    public AudioSource source;
    public AudioClip hit, miss, player_Take_Dmg, block;
    public int enemyHP = 100;
    public int playerHP = 100;
    public Transform markerPos;
    public combat_Turn turnChecker;
    public GameManager manager;
    public bool inputPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        turnChecker = FindObjectOfType<combat_Turn>();

        //get player health form Game Manager
        manager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
       {
            if(markerPos.transform.localPosition.x <= 100 && markerPos.transform.localPosition.x >= -100)
            {
                Debug.Log("Correct time");
                //Damage the enemy/good defense
                if(turnChecker.currentTurn == TurnState.Player)
                {
                    //it is player turn so damage the enemy
                    turnChecker.turnLabel.text = "Hit";
                    turnChecker.turnLabel.gameObject.SetActive(true);
                    enemyHP -= Random.Range(18, 23);
                    ChangeEnemyHP();
                    Debug.Log("Hit");
                    source.clip = hit;
                    source.Play();

                }
                if(turnChecker.currentTurn == TurnState.Enemy)
                {
                    //blocked so player takes no damage or maybe little damage
                    turnChecker.turnLabel.text = "Block";
                    turnChecker.turnLabel.gameObject.SetActive(true);
                    Debug.Log("Block");
                    source.clip = block;
                    source.Play();

                }
                

            }
            else
            {
                Debug.Log("Incorrect time");
                if(turnChecker.currentTurn == TurnState.Player)
                {
                    //player turn so miss
                    Debug.Log("Miss");
                    turnChecker.turnLabel.text = "Miss";
                    turnChecker.turnLabel.gameObject.SetActive(true);
                    source.clip = miss;
                    source.Play();
                }
                //miss/take damage
                if(turnChecker.currentTurn == TurnState.Enemy)
                {
                    //enemy turn so damage player
                    //random range around 19-23 damage
                    int damage = Random.Range(18,23);
                    manager.DamagePlayer(damage);
                    playerHP -= damage;
                    ChangeHP();
                    turnChecker.turnLabel.text = "Ouch";
                    turnChecker.turnLabel.gameObject.SetActive(true);
                    Debug.Log("Ouch");
                    source.clip = player_Take_Dmg;
                    source.Play();
                }
            }
             playerHP = manager.PlayerHealth;

            markerPos.transform.localPosition = new Vector3(1600f, 528f, 0f);
            turnChecker.randomNum -= 1;
       }

       //if the enemy health is 0 go back to main scene
       if(enemyHP <= 0)
        {
            turnChecker.turnLabel.text = "Victory";
            turnChecker.turnLabel.gameObject.SetActive(true);

            Invoke("CallingGameManager", 1f);

        }
    }

    public void ChangeHP()
    {
        playerHP_Bar.value = playerHP;
    }

    public void ChangeEnemyHP()
    {
        enemyHP_Bar.value = enemyHP;
    }

    void CallingGameManager()
    {
        manager.DestroyEnemy();
        manager.ReturnToDungeon();
    }

}


