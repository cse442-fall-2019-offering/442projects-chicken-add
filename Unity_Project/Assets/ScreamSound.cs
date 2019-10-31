using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSound : MonoBehaviour
{
   public AudioSource aud;
    // Start is called before the first frame update
    public void Scream()
    {
        aud = GetComponent<AudioSource>();
        if(aud.isPlaying)
        {
            aud.Stop();
        }
        aud.Play();
        Debug.Log("OW!");
    }
}
