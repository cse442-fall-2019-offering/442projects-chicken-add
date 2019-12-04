using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    //Lives UI var
    public static int lives;
    //Level UI var
    public static int levels;
    //status check to see if lives should update for optimization
    public static bool status;
    //Lives displays
    public GameObject Hertz1, Hertz2, Hertz3;
    
    //On start, display the lives and initialize the variables to the global variables in LivesControl
    void Start()
    {
        lives = LivesControl.Instance.life;
        levels = LivesControl.Instance.level;
        status = true;
        
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    //respawn values
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;

    //constantly checks how many lives the  player has left.
    private void Update()
    {

        //if player has no more lives, values are reset, the current instance is destroyed and the gameover scene is loaded.
        if (status)
        {
            if (lives <= 0)
            {
                lives = 3;
                levels = 1;
                SceneManager.LoadScene("GameOver");
                status = false;
            }
            if (lives == 3)
            {
                Hertz1.SetActive(true);
                Hertz2.SetActive(true);
                Hertz3.SetActive(true);
                
                status = false;
            }
            //if the player has two lives, only one life display gets disabled.
            if (lives == 2)
            {
                Hertz1.SetActive(false);
                Hertz2.SetActive(true);
                Hertz3.SetActive(true);
                
                status = false;
            }

            //if the player has one life, two life displays are disabled.
            if (lives == 1)
            {
                Hertz1.SetActive(false);
                Hertz2.SetActive(false);
                Hertz3.SetActive(true);
                
                status = false;
            }
        }
        
        
    }

    public void SavePlayer()
    {
        LivesControl.Instance.life = lives;
        LivesControl.Instance.level = levels;
    }
    
    //kills player and decrements life. Player object is destroyed and respawned at the spawnpoint.
    public static void KillPlayer(Player player)
    {
        lives--;
        gm.SavePlayer();
        status = true;
        SceneManager.LoadScene("World");
        Debug.Log("Player Destroyed");
    }
}
