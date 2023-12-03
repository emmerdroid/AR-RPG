using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState
{
    Player,
    Enemy
}
public class CombatTurnSystem : MonoBehaviour
{

    public Slider progressBar;
    public Slider cursor;
    public bool play_hit_attack;
    public bool enemy_has_attacked;


    public TurnState currentTurn = TurnState.Player;
    // Start is called before the first frame update
    void Start()
    {
        play_hit_attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTurn == TurnState.Player)
        {
            Button button = FindObjectOfType<Button>();
            button.interactable = true;
            if(play_hit_attack)
            {
                StartPlayerTurn();

            }

         

        }
        if(currentTurn == TurnState.Enemy)
        {

            Debug.Log("Get Ready To defend");
            Invoke("StartEnemyTurn", 2f);
            

        }
       
    }

    void MoveCursor()
    {
        float cursorValue = Mathf.PingPong(Time.time, 1.0f);
        cursor.value = cursorValue;

        //progress equal to cursor position
        progressBar.value = cursor.value;
    }

    bool CheckTap()
    {
        if(Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            float rangeStart = 0.4f;
            float rangeEnd = 0.6f;

            if(cursor.value >= rangeStart && cursor.value <= rangeEnd)
            {
                Debug.Log("Success Hit/Block");
                if (currentTurn == TurnState.Player)
                {
                    //change turn
                    currentTurn = TurnState.Enemy;
                }

                else if (currentTurn == TurnState.Enemy)
                {
                    //swap to the player turn??
                    currentTurn = TurnState.Player;
                }

                play_hit_attack = false;
               
                return true;
            }

            else
            {
                Debug.Log("Miss/Take Hit");
                if (currentTurn == TurnState.Player)
                {
                    //change turn
                    currentTurn = TurnState.Enemy;
                }

                else if (currentTurn == TurnState.Enemy)
                {
                    //swap to the player turn??
                    currentTurn = TurnState.Player;
                }
                play_hit_attack = false;
                
                return false;
            }
        }

        
            return false;
    }

    void StartPlayerTurn()
    {
        //Player turn they hit Attack,
        MoveCursor();
        CheckTap();
    }

    public void AttackButtonPressed()
    {
        play_hit_attack = true;
        Button button = FindObjectOfType<Button>();
        button.interactable = false;

    }

    void StartEnemyTurn()
    {
        if(currentTurn == TurnState.Enemy)
        {
            MoveCursor();
            CheckTap();

        }
    }
}
