using System.Collections;
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

    void Update()
    {

        if (transform.position.y <= fallBoundary)
        {
            Debug.Log("Fell");
            DamagePlayer(9999);
        }

    }

    public void DamagePlayer (int damage)
    {
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
            Debug.Log("You Win!");
            SceneManager.LoadScene("EndGame");
            LivesControl.Instance.life = 3;
            LivesControl.Instance.level++;
        }

    }
}
