using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviour
{
    public float speed;
    public CharacterController controller;

    private float x, z;
    private PhotonView view;
    
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            InputWithCam();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
        }
    }


    public void InputWithCam()
    {
        Vector3 move = rotateToMove(x, z);

        controller.Move(move * Time.deltaTime * speed);

        var Moved = x != 0 || z != 0;

        if (Moved)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
    }

    Vector3 rotateToMove(float x, float z)
    {
        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var move = forward * z + right * x;
        if (move.magnitude > 1.2f) move = move * 2 / 3;
        return move;
    }
}
