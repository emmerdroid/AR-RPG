using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum TurnState
{
    Player,
    Enemy
}

public class MoveAttackMarker : MonoBehaviour
{   
    
    public float randomNum = 0f;
    public float currentTime = 0f;
    public float startTime = 3f;
    public TMP_Text turnLabel;
    public TurnState currentTurn = TurnState.Player;
    // Start is called before the first frame update
    void Start()
    {
        turnLabel.gameObject.SetActive(false);
        currentTime = startTime;
        this.transform.localPosition = new Vector3(370f, 133f, 0f);
        randomNum = Random.Range(3,7);
        Debug.Log(randomNum);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x - 1.5f, 133f, 0f);
        if(this.transform.localPosition.x <= -370 && randomNum > 0)
        {
            this.transform.localPosition = new Vector3(370f, 133f, 0f);
            randomNum -= 1;
            Debug.Log(randomNum);
        }
        if(randomNum <= 0)
        {
            randomNum = 0;
            currentTime = 3;
            Debug.Log("New round");
            SwapTurn();
            
            randomNum = Random.Range(3,7);

        }
    }

    void SwapTurn()
    {
        if(currentTurn == TurnState.Player)
        {
            turnLabel.text = "Opponent's Turn";
            currentTurn = TurnState.Enemy;
        }
        else
        {
            turnLabel.text = "Your Turn";
            currentTurn = TurnState.Player;
        }

        turnLabel.gameObject.SetActive(true);
    }
}
