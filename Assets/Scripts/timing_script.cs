using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timing_script : MonoBehaviour

{
    public Slider playerHP_Bar;
    public Slider enemyHP_Bar;
    public int enemyHP = 100;
    public int playerHP = 100;
    public Rigidbody2D player;
    public Transform markerPos;
    public float jumpforce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Space) &&  player.velocity.y== 0)
       {
            if(markerPos.transform.localPosition.x <= 120 && markerPos.transform.localPosition.x >= -120)
            {
                Jump();
                enemyHP -= 20;
                ChangeEnemyHP();
            }
            else
            {
                playerHP -= 20;
                ChangeHP();
            }
       }
    }

    void Jump()
    {
        player.AddForce(transform.up*jumpforce);
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

