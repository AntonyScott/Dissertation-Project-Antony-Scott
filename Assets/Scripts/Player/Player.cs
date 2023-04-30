using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walking,
    attacking,
    idle
}

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 change;

    //classes are declared
    private Rigidbody2D rb = null;
    private Animator animator;
    private MyGameActions input;
    private PlayerState playerState;

    // Start is called before the first frame update
    private void Awake()
    {
        input = new MyGameActions(); //input is instantiated as game actions bindings
        rb = GetComponent<Rigidbody2D>(); //grabs rigidbody on player
        animator = GetComponent<Animator>(); //grabs animator 

        //the code below attempts to find multiple game objects with the tag "Player"
        //it then destroys all but the current player gameobject, which is loaded into the DontDestroyOnLoad(gameObject)
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            for (int i = 1; i < players.Length; i++)
            {
                Destroy(players[i]);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        change = context.ReadValue<Vector2>() * moveSpeed;
        FindObjectOfType<AudioManager>().Play("Footsteps");
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        change = Vector2.zero;
        FindObjectOfType<AudioManager>().StopPlaying("Footsteps");
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        // Start attack coroutine
        if (playerState != PlayerState.attacking)
        {
            playerState = PlayerState.attacking;
            StartCoroutine(AttackCo());
        }
    }

    private void OnAttackCanceled(InputAction.CallbackContext context)
    {
        if(playerState == PlayerState.attacking)
        {
            playerState = PlayerState.idle;
            StartCoroutine(AttackCo());
        }
    }

    void FixedUpdate()
    {
        if (change != Vector2.zero)
        {
            Movement();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if(playerState == PlayerState.attacking)
        {
            animator.SetBool("isAttacking", true);
            FindObjectOfType<AudioManager>().Play("Sword Swing");

        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void Movement()
    {
        change.Normalize();
        rb.MovePosition(rb.position + change.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator AttackCo()
    {
        yield return new WaitForSeconds(0.1f);
        playerState = PlayerState.idle;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovePerformed;
        input.Player.Movement.canceled += OnMoveCanceled;
        input.Player.Attack.performed += OnAttackPerformed;
        input.Player.Attack.canceled += OnAttackCanceled;
        //input.Player.Exit.performed += OnExit;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovePerformed;
        input.Player.Movement.canceled -= OnMoveCanceled;
        input.Player.Attack.performed -= OnAttackPerformed;
        input.Player.Attack.canceled -= OnAttackCanceled;
    }

    /*private void OnExit(InputAction.CallbackContext context)
    {
        *//*Debug.Log("Quit");
        Application.Quit();*//*
        SceneManager.LoadScene("Main Menu");
        Destroy(gameObject);
    }*/
}
