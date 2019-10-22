using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    /*
    public static CinemachineVirtualCamera myCinemachine;
    double nextTimeToSeach = 0;
    */
    void Start()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
        //myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;
    
    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
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
    
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        //Debug.Log("Player Destroyed");
        gm.StartCoroutine (gm.RespawnPlayer());
    }
}
