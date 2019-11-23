﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [System.Serializable]
    
    public class PlayerStats
    {
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -25;

    public GameObject ouch;

    void Update()
    {
        ouch = GameObject.Find("Ouchie");
        if (transform.position.y <= fallBoundary)
        {
            Debug.Log("Fell");
            DamagePlayer(9999);
        }

    }

    public void DamagePlayer (int damage)
    {
        ScreamSound s = (ScreamSound)ouch.GetComponent<ScreamSound>();
        s.Scream();
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    if (collision.collider.tag == "Enemy")
        {
            
        DamagePlayer(9999);
        Debug.Log("Shot");
        //GameMaster.KillPlayer(this);
        }
    if (collision.collider.tag == "Finish")
        {
            Debug.Log("Level: " + LivesControl.Instance.level);
            if (LivesControl.Instance.level == 1)
            {
                Debug.Log("You Win!");
                SceneManager.LoadScene("CodePuzzle");
                LivesControl.Instance.life = 3;
                LivesControl.Instance.level++;
            }
            else if (LivesControl.Instance.level == 2)
            {
                Debug.Log("You Win!");
                SceneManager.LoadScene("CodePuzzle2");
                LivesControl.Instance.life = 3;
                LivesControl.Instance.level++;
            }
            else if (LivesControl.Instance.level == 3)
            {
                Debug.Log("You Win!");
                SceneManager.LoadScene("CodePuzzle3");
                LivesControl.Instance.life = 3;
                LivesControl.Instance.level++;
            }
            else if (LivesControl.Instance.level == 4)
            {
                Debug.Log("You Win!");
                SceneManager.LoadScene("CodePuzzle4");
                LivesControl.Instance.life = 3;
                LivesControl.Instance.level++;
            }
            else
            {
                Debug.Log("Level Error");
            }
            /*Debug.Log("You Win!");
            SceneManager.LoadScene("CodePuzzle");
            LivesControl.Instance.life = 3;
            LivesControl.Instance.level++;*/
            Debug.Log("Level"+LivesControl.Instance.level);
        }

    }
}
