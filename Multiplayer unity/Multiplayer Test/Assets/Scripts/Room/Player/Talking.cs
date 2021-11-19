using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using Photon.Realtime;
using Photon.Pun;

public class Talking : MonoBehaviour
{
    public KeyCode talkKey = KeyCode.V;
    public Recorder voiceRecorder;
    private PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        voiceRecorder.TransmitEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        voiceRecorder.TransmitEnabled = Input.GetKey(talkKey) && view.IsMine;
    }
}
