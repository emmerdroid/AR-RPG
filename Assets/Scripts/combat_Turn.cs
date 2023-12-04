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

public class combat_Turn : MonoBehaviour
{   
    
    public float randomNum = 0f;
    public float currentTime = 0f;
    public float startTime = 3f;
    public bool turnOver = false;
    public TMP_Text turnLabel;
    public TMP_Text countdown;
    public TurnState currentTurn = TurnState.Player;
    // Start is called before the first frame update
    void Start()
    {
        turnLabel.gameObject.SetActive(false);
        countdown.gameObject.SetActive(false);
        currentTime = startTime;
        this.transform.localPosition = new Vector3(1570f, 528f, 0f);
        randomNum = Random.Range(3,7);
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnOver)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x - 3f, 528f, 0f);
        }
        else
        {
            currentTime -= 5 * Time.deltaTime;
            countdown.text = currentTime.ToString("0");
            if(currentTime <= 0)
            {
                countdown.gameObject.SetActive(false);
                turnLabel.gameObject.SetActive(false);
                turnOver = false;
            }
        }

        if(this.transform.localPosition.x <= -1575 && randomNum > 0)
        {
            this.transform.localPosition = new Vector3(1570f, 528f, 0f);
            randomNum -= 1;
        }

        if(randomNum <= 0)
        {
            randomNum = 0;
            currentTime = 3;
            SwapTurn();
            turnOver = true;
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
        countdown.gameObject.SetActive(true);
        
    }


}