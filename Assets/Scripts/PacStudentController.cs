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

public class PacStudentController : MonoBehaviour
{
   /* public float speed = 3f;
    public float speedMultiplier = 1f;
    public Vector2 initialDir;
    public AudioSource footStepSource;
    public AudioClip[] footStepClips;
    private int currentClip = 0;

    int switchingHead;
    [SerializeField] private Animator animatorController;

    private Vector2 direction;
    private Vector2 nextDir;
    private Vector3 startingPos;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPos = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        speedMultiplier = 1f;
        direction = initialDir;
        nextDir = Vector2.zero;
        transform.position = startingPos;
        spriteRenderer.enabled = true;
        enabled = true;
    }

    private void Update()
    {
        // Handle input movement for PacStudentMovement
        HandleInputMovement();

        // Trying to move in the next direction while it's queued to make movements more responsive
        if (nextDir != Vector2.zero)
        {
            SetDirection(nextDir);
        }
    }

    //Allow the PacStudent to move in any direction we pressed.
    private void FixedUpdate()
    {
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;
        Move(translation);
    }

    private void HandleInputMovement()
    {
        // Handle input movement for movement
        Vector2 inputMovement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            animatorController.SetTrigger("isFlipped");
            inputMovement = Vector2.up;
            switchingHead = 0;
            animatorController.SetInteger("switchingHead", switchingHead);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animatorController.SetTrigger("isFlipped");
            inputMovement = Vector2.left;
            switchingHead = 1;
            animatorController.SetInteger("switchingHead", switchingHead);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animatorController.SetTrigger("isFlipped");
            inputMovement = Vector2.down;
            switchingHead = 2;
            animatorController.SetInteger("switchingHead", switchingHead);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animatorController.SetTrigger("isFlipped");
            inputMovement = Vector2.right;
            switchingHead = 3;
            animatorController.SetInteger("switchingHead", switchingHead);
        }

        // Set the new direction based on input movement
        SetDirection(inputMovement);
        //add a foot step audio on PacStudent
        FootstepAudio();
    }

    //add audio for PacStudent foot step
    public void FootstepAudio()
    {
        if (!footStepSource.isPlaying)
        {
            currentClip = 1 - currentClip;
            footStepSource.clip = footStepClips[currentClip];
            footStepSource.Play();
        }
        else if (footStepSource.isPlaying)
        {
            footStepSource.Stop();
        }
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        // Only set the direction if the tile in that direction is available
        // otherwise, we set it as the next direction so it'll automatically be
        // set when it does become available
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            nextDir = Vector2.zero;
        }
        else
        {
            nextDir = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        // Use raycasting to check for obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.75f);
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            return true;
        }
        return hit.collider != null;
      return false;

    }

    private void Move(Vector2 translation)
    {
        // Calculating the new position
        Vector2 newPos = (Vector2)transform.position + translation;

        // Check for collisions before moving
        if (!Occupied(translation.normalized))
        {
            transform.position = newPos;
        }
    }*/

    //Allows you to hold down a key for a movement
    [SerializeField] private bool isRepeatedMovement = false;
    //Time (s) it takes to move between one grid  and the next
    [SerializeField] private float moveDuration = 0.1f;
    //size of the grid
    [SerializeField] private float gridSize = 1f;

    private bool isMoving = false;

    private void Update()
    {
        //Only process on move at a time
        if (!isMoving)
        {
            //Accomodate two different types of moving
            System.Func<KeyCode, bool> inputFunction;
            if (isRepeatedMovement)
            {
                //GetKey repeatdly fires.
                inputFunction = Input.GetKey;
            }
            else
            {
                //GetKeyDown fires once per keypress
                inputFunction = Input.GetKeyDown;
            }
            if (inputFunction(KeyCode.W))
            {
                StartCoroutine(Move(Vector2.up));
            }
            else if (inputFunction(KeyCode.S))
            {
                StartCoroutine(Move(Vector2.down));
            }
            else if (inputFunction(KeyCode.A))
            {
                StartCoroutine(Move(Vector2.left));
            }
            else if (inputFunction(KeyCode.D))
            {
                StartCoroutine(Move(Vector2.right));
            }
        }
    }
    private IEnumerator Move(Vector2 direction)
    {
        //Record that we're moving so we don't accept more input
        isMoving = true;
        //currentPos and the next position we're going.
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + (direction * gridSize);

        //Smoothly move in the desired direction taking the required time
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = Vector2.Lerp(startPos, endPos, percent);
            yield return null;
        }
        //Ensure we end up in where we want.
        transform.position = endPos;

        //No long moving so we can accept another move input.
        isMoving = false;
    }
}

