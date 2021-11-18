using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ToRoom : MonoBehaviourPunCallbacks
{
    public InputField create, join;
    public Text failed;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(join.text);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(create.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Gameplay");
    }


    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        failed.text = "Join room failed: " + message + ", return code: " + returnCode;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        failed.text = "Create room failed: " + message + ", return code: " + returnCode;
    }
}
