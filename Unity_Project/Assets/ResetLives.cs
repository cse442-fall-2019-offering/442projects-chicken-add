using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLives : MonoBehaviour
{
    // resets lives and level.
    void Start()
    {
        LivesControl.Instance.life = 3;
        LivesControl.Instance.level = 1;
        
    }
}
