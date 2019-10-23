using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;
    private Cinemachine.CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if (tPlayer != null)
            {
                tFollowTarget = tPlayer.transform;
                //vcam.LookAt = tFollowTarget;
                vcam.Follow = tFollowTarget;
            }
        }
    }
}
