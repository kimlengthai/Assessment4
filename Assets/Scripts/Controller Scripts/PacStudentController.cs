using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    //Switching the PacStudent's head based on the pressed key
    int switchingHead;
    //PacStudent animator
    [SerializeField] private Animator animatorController;
    //Allows you to hold down a key for a movement
    [SerializeField] private bool onLoopMovement = false;
    //Time (s) it takes to move between one grid and the next
    [SerializeField] private float moveDuration = 0.2f;
    //size of the grid
    [SerializeField] private float gridSize = 1f;
    //store the last key that the player pressed
    private KeyCode lastInput;

    private bool isMoving = false;

    public GameObject dustParticleEffect;
    private ParticleSystem dustParticleSystem;

    /*    [SerializeField] private AudioClip audioSource;

        [SerializeField] private AudioClip pacStudentMovementAudioClip;*/

    private void Start()
    {
        dustParticleSystem = dustParticleEffect.GetComponent<ParticleSystem>();
        dustParticleSystem.Stop();

        /*        audioSource = GetComponent<audioSource>();
                audioSource.clip = pacStudentMovementAudioClip;
                audioSource.loop = true;
                audioSource.Stop();*/

        gameObject.GetComponent<Rigidbody2D>();
    }

    //Detect pellet and destroy it when PacStudent walk past
    //  void OnTriggerEnter2D(Collider2D other)
    //  {
    //      if (other.CompareTag("Pellet"))
    //      {
    //          Destroy(other.gameObject);
    //          PlayPelletEatingAudio();
    //      }
    //  }

    void PlayPelletEatingAudio()
    {
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
        //Only process on move at a time
        if (!isMoving)
        {
            //Accomodate two different types of moving
            System.Func<KeyCode, bool> inputFunction;
            if (onLoopMovement)
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
                animatorController.SetTrigger("isFlipped");
                
                switchingHead = 0;
                animatorController.SetInteger("switchingHead", switchingHead);
                lastInput = KeyCode.W;
            }
            else if (inputFunction(KeyCode.A))
            {
                animatorController.SetTrigger("isFlipped");
                switchingHead = 1;
                animatorController.SetInteger("switchingHead", switchingHead);
                lastInput = KeyCode.A;
            }
            else if (inputFunction(KeyCode.S))
            {
                animatorController.SetTrigger("isFlipped");
                switchingHead = 2;
                animatorController.SetInteger("switchingHead", switchingHead);
                lastInput = KeyCode.S;
            }
            else if (inputFunction(KeyCode.D))
            {
                animatorController.SetTrigger("isFlipped");
                switchingHead = 3;
                animatorController.SetInteger("switchingHead", switchingHead);
                lastInput = KeyCode.D;
            }

            if (!isMoving)
            {
                StartCoroutine(Move(lastInput));
            }

            /*if (isMoving && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (!isMoving && audioSource.isPlaying)
            {
                audioSource.Stop();
            }*/
        }
    }

    private bool IsWalkable(Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 0);
        return hit.collider == null;
    }

    private IEnumerator Move(KeyCode lastInput)
    {
        Vector2 direction;
        switch (lastInput)
        {
            case KeyCode.A:
                direction = Vector2.left;
                break;
            case KeyCode.S:
                direction = Vector2.down;
                break;
            case KeyCode.W:
                direction = Vector2.up;
                break;
            case KeyCode.D:
            default:
                direction = Vector2.right;
                break;

        }

        dustParticleSystem.Play();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.75f);
        if (hit)
        {
            Debug.Log(hit.collider.tag);
        }
            
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            yield break; 
        }
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

        dustParticleSystem.Stop();

        //No long moving so we can accept another move input.
        isMoving = false;
    }
}