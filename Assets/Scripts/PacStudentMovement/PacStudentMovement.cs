using System;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
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
        if (player.transform.position == topLeft)
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, topRight, fractionTime);
            switchingHead = 3;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        if (player.transform.position == topRight)
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, bottomRight, fractionTime);
            switchingHead = 2;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        if (player.transform.position == bottomRight)
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, bottomLeft, fractionTime);
            switchingHead = 1;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        if (player.transform.position == bottomLeft)
        {
            animatorController.SetTrigger("isFlipped");
            float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
            tweener.AddTween(player.transform, player.transform.position, topLeft, fractionTime);
            switchingHead = 0;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

    }
}