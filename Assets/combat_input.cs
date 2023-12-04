using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combat_input : MonoBehaviour

{
    public Slider playerHP_Bar;
    public Slider enemyHP_Bar;
    public Image Marker;
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

       if(Input.GetKeyUp(KeyCode.Space) || Input.touchCount > 0)
       {
            if(markerPos.transform.localPosition.x <= 100 && markerPos.transform.localPosition.x >= -100)
            {
                Debug.Log("Correct time");
                //Damage the enemy/good defense
                if(turnChecker.currentTurn == TurnState.Player)
                {
                    //it is player turn so damage the enemy
                    turnChecker.turnLabel.text = "Hit";
                    enemyHP -= Random.Range(18, 23);
                    ChangeEnemyHP();
                    Debug.Log("Hit");

                }
                if(turnChecker.currentTurn == TurnState.Enemy)
                {
                    //blocked so player takes no damage or maybe little damage
                    turnChecker.turnLabel.text = "Hit";
                    Debug.Log("Block");

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
                    Debug.Log("Ouch");
                }
            }
            inputPressed = true;
       }

       //if the enemy health is 0 go back to main scene
       if(enemyHP <= 0)
        {
            turnChecker.turnLabel.text = "Victory";
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
        manager.ReturnToDungeon();
    }

}


