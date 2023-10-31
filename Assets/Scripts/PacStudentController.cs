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

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Collections.Specialized;
// //using System.Collections.Specialized;
// //using System.Diagnostics;
// using UnityEngine;

// public class PacStudentController : MonoBehaviour
// {
//     int switchingHead;
//     [SerializeField] private GameObject player;
//     [SerializeField] private Animator animatorController;
//     private Tweener tweener;
//     Vector3 topLeft = new Vector3(0.5f, -0.5f, 0f);
//     Vector3 topRight = new Vector3(3.5f, -0.5f, 0f);
//     Vector3 bottomRight = new Vector3(3.5f, -2.5f, 0f);
//     Vector3 bottomLeft = new Vector3(0.5f, -2.5f, 0f);
//     // Start is called before the first frame update
//     void Start()
//     {
//         tweener = GetComponent<Tweener>();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         int speed = 1;
//         if (Input.GetKeyDown("w"))
//         {
//             animatorController.SetTrigger("isFlipped");
//             float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
//             tweener.AddTween(player.transform, player.transform.position, player.transform.position + Vector3.up, fractionTime);
//             switchingHead = 3;
//             animatorController.SetInteger("switchingHead", switchingHead);
//         }

//         if (Input.GetKeyDown("d"))
//         {
//             animatorController.SetTrigger("isFlipped");
//             float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
//             tweener.AddTween(player.transform, player.transform.position, bottomRight, fractionTime);
//             switchingHead = 2;
//             animatorController.SetInteger("switchingHead", switchingHead);
//         }

//         if (Input.GetKeyDown("s"))
//         {
//             animatorController.SetTrigger("isFlipped");
//             float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
//             tweener.AddTween(player.transform, player.transform.position, bottomLeft, fractionTime);
//             switchingHead = 1;
//             animatorController.SetInteger("switchingHead", switchingHead);
//         }

//         if (Input.GetKeyDown("a"))
//         {
//             animatorController.SetTrigger("isFlipped");
//             float fractionTime = Vector3.Distance(topLeft, topRight) / speed;
//             tweener.AddTween(player.transform, player.transform.position, topLeft, fractionTime);
//             switchingHead = 0;
//             animatorController.SetInteger("switchingHead", switchingHead);
//         }

//     }
// }

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 3f;
    public float speedMultiplier = 1f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    private Vector2 direction;
    private Vector2 nextDirection;
    private Vector3 startingPosition;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        speedMultiplier = 1f;
        direction = initialDirection;
        nextDirection = Vector2.zero;
        transform.position = startingPosition;
        spriteRenderer.enabled = true;
        enabled = true;
    }

    private void Update()
    {
        // Handle input for movement
        HandleInput();

        // Rotate pacman to face the movement direction
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        // Try to move in the next direction while it's queued to make movements more responsive
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }
    }

    private void FixedUpdate()
    {
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;
        Move(translation);
    }

    private void HandleInput()
    {
        // Handle input for movement
        Vector2 inputDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputDirection = Vector2.right;
        }

        // Set the new direction based on input
        SetDirection(inputDirection);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        // Only set the direction if the tile in that direction is available
        // otherwise, we set it as the next direction so it'll automatically be
        // set when it does become available
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        // Use raycasting to check for obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.75f, obstacleLayer);
        return hit.collider != null;
    }

    private void Move(Vector2 translation)
    {
        // Calculate the new position
        Vector2 newPosition = (Vector2)transform.position + translation;

        // Check for collisions before moving
        if (!Occupied(translation.normalized))
        {
            transform.position = newPosition;
        }
    }
}

