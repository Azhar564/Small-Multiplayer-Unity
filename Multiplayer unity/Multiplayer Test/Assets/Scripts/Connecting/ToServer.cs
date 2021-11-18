using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;

public class ToServer : MonoBehaviourPunCallbacks
{
    public Text connectingTxt;

    private int i;
    private string loadText;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        loadText = connectingTxt.text;
        StartCoroutine(ConnectAnim(.2f));
    }

    private IEnumerator ConnectAnim(float time)
    {
        while (true)
        {
            i = i > 5 ? 1 : i + 1;
            connectingTxt.text = loadText;
            for (int k = 0; k < i; k++)
            {
                connectingTxt.text += ".";
            }
            yield return new WaitForSeconds(time);
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
