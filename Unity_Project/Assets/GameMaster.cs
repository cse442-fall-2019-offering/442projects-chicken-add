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
    //Lives displays
    public GameObject Hertz1, Hertz2, Hertz3;
    //public static GameObject SpawnPoint;
    /*
    public static CinemachineVirtualCamera myCinemachine;
    double nextTimeToSeach = 0;
    */
    //On start, display the lives and initialize the variables to the global variables in LivesControl
    void Start()
    {
        Hertz1.SetActive(true);
        Hertz2.SetActive(true);
        Hertz3.SetActive(true);
        lives = LivesControl.Instance.life;
        levels = LivesControl.Instance.level;
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
        //myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    //respawn values
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;

    //saves local level and lives variables to the global variables in LivesControl
    public void SavePlayer()
    {
        LivesControl.Instance.life = lives;
        LivesControl.Instance.level = levels;
    }
    
    //Respawns the player
    public void RespawnPlayer()
    {
        //yield return new WaitForSeconds(spawnDelay);
        Debug.Log("Respawn");
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //var newPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //newPlayer.gameObject.tag = "Player";
        //Debug.Log("newPlayer==null");
        /*
        if (nextTimeToSeach <= Time.time)
            {

                GameObject result = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(result);
                if (result != null)
                {
                    Debug.Log("Not null");
                Transform tFollowTarget = result.transform;
                    myCinemachine.LookAt = tFollowTarget;
                    myCinemachine.Follow = tFollowTarget;
                    nextTimeToSeach = Time.time + 0.5;
                }
            }
            */
    }

    //constantly checks how many lives the  player has left.
    private void Update()
    {
        //if player has no more lives, values are reset, the current instance is destroyed and the gameover scene is loaded.
        if (lives == 0)
        {
            lives = 3;
            levels = 1;
            gm.SavePlayer();
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");

        }
        else
        {
            //if the player has two lives, only one life display gets disabled.
            if (lives == 2)
            {
                Hertz1.SetActive(false);
            }
            else
            {
                //if the player has one life, two life displays are disabled.
                if (lives == 1)
                {
                    Hertz1.SetActive(false);
                    Hertz2.SetActive(false);
                }
            }
            gm.SavePlayer();
        }
    }
    
    //kills player and decrements life. Player object is destroyed and respawned at the spawnpoint.
    public static void KillPlayer(Player player)
    {
        Debug.Log("Player Destroyed");
        //player.transform.position = SpawnPoint.transform.position;
        
        
        Destroy(player.gameObject);
        Debug.Log("Player Destroyed");
        gm.RespawnPlayer();
        lives--;
    }
}
