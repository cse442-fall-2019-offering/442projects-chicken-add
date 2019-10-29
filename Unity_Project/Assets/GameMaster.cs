using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public static int lives;
    public GameObject Hertz1, Hertz2, Hertz3;
    //public static GameObject SpawnPoint;
    /*
    public static CinemachineVirtualCamera myCinemachine;
    double nextTimeToSeach = 0;
    */
    void Start()
    {
        Hertz1.SetActive(true);
        Hertz2.SetActive(true);
        Hertz3.SetActive(true);
        lives = 3;
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
        //myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;
    
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

    private void Update()
    {
        if (lives == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");

        }
        else
        {
            if (lives == 2)
            {
                Hertz1.SetActive(false);
            }
            else
            {
                if (lives == 1)
                {
                    Hertz1.SetActive(false);
                    Hertz2.SetActive(false);
                }
            }
        }
    }

    public GameObject getThis()
    {
        return this.gameObject;
    }
    
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
