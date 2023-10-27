/*using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // public float moveSpeed = 3.0f;
    // private Vector3 targetPos;
    // private Vector3 nextPos;
    // private Vector3 currentInput = Vector3.zero;
    // private Vector3 lastInput = Vector3.zero;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     targetPos = new Vector3(0.5f, -0.5f, 0f);
    //     transform.position = targetPos;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (!isLerping())
    //     {
    //         getPacStudentInput();
    //     }
    // }

    // bool isLerping()
    // {
    //     return transform.position != targetPos;
    // }

    // public void getPacStudentInput()
    // {
    //     Vector3 inputDirection = Vector3.zero;

    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         inputDirection = Vector3.up;
    //     }
    //     else if (Input.GetKey(KeyCode.A))
    //     {
    //         inputDirection = Vector3.left;
    //     }
    //     else if (Input.GetKey(KeyCode.S))
    //     {
    //         inputDirection = Vector3.down;
    //     }
    //     else if (Input.GetKey(GetCode.D))
    //     {
    //         inputDirection = Vector3.right;
    //     }

    //     if (inputDirection != Vector3.zero)
    //     {
    //         lastInput = inputDirection;
    //     }
    // }

}
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    int switchingHead;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animatorController;
    private Tweener tweener;
    Vector3 topLeft = new Vector3(0.5f, -0.5f, 0f);
    Vector3 topRight = new Vector3(3.5f, -0.5f, 0f);
    Vector3 bottomRight = new Vector3(3.5f, -2.5f, 0f);
    Vector3 bottomLeft = new Vector3(0.5f, -2.5f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {

        int speed = 1;
        if (Input.GetKeyDown("w"))
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, player.transform.position + Vector3.up, fractionTime);
            switchingHead = 3;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        if (Input.GetKeyDown("d"))
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, bottomRight, fractionTime);
            switchingHead = 2;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        if (Input.GetKeyDown("s"))
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, bottomLeft, fractionTime);
            switchingHead = 1;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        if (Input.GetKeyDown("a"))
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, topLeft, fractionTime);
            switchingHead = 0;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

    }
}