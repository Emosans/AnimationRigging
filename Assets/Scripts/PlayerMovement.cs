using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    float moveX;
    float moveZ;

    private Animator anim;
    private CharacterController Abe;
    private string WALK_ANIM = "IsWalking";
    void Start()
    {
        anim = GetComponent<Animator>();
        Abe = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //PlayerMoveAnim();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Abe.Move(move * moveSpeed * Time.deltaTime);
    }

    void PlayerMoveAnim()
    {
        bool isForwardPressed = Input.GetKey(KeyCode.W);
        bool isWalking = anim.GetBool(WALK_ANIM);

        if (!isWalking && isForwardPressed)
        {
            anim.SetBool(WALK_ANIM, true);

        }
        else if (isWalking && !isForwardPressed)
        {
            anim.SetBool(WALK_ANIM, false);
            //Vector3 move = transform.right * moveX + transform.forward * moveZ;
            //Remy.Move(move * moveSpeed * Time.deltaTime);
            Abe.Move(new Vector3(0f, 0f, 0f));
        }
    }
}
