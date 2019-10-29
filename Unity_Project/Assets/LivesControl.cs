using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesControl : MonoBehaviour
{
    public GameObject Hertz1, Hertz2, Hertz3;
    public static int life;
    private static LivesControl instance = null;
    public static LivesControl Instance
    {
        get { return instance; }
    }
    // Awake is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    Hertz1.SetActive(true);
        Hertz2.SetActive(true);
        Hertz3.SetActive(true);
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
            
        }
        else
        {
            if(life == 2)
            {
                Hertz1.SetActive(false);
            }
            else
            {
                if(life == 1)
            {
                    Hertz1.SetActive(false);
                    Hertz2.SetActive(false);
                }
            }
        }
    }

    public void Death()
    {
        life = life - 1;
    }
}
