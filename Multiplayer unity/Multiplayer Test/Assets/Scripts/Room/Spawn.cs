using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class Spawn : MonoBehaviour
{
    public GameObject playerPref_;
    public CinemachineFreeLook camSetup;
    // Start is called before the first frame update
    void Start()
    {
        var obj = PhotonNetwork.Instantiate(playerPref_.name, playerPref_.transform.position, playerPref_.transform.rotation);
        camSetup.Follow = obj.transform;
        camSetup.LookAt = obj.transform;
    }
}
