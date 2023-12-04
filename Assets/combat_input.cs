using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combat_input : MonoBehaviour

{
    public Slider playerHP_Bar;
    public Slider enemyHP_Bar;
    public int enemyHP = 100;
    public int playerHP = 100;
    public Transform markerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Space))
       {
            if(markerPos.transform.localPosition.x <= 120 && markerPos.transform.localPosition.x >= -120)
            {
                Debug.Log("Correct time");
            }
            else
            {
                Debug.Log("Incorrect time");
            }
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
}


