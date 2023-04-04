using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private MyGameActions input = null; //input system controls

    [SerializeField] private float moveSpeed = 5f; // Player movement speed
    [SerializeField] private float runSpeed = 10f; // Player running speed
    [SerializeField] private float dashDistance = 5f; // Player dash distance
    [SerializeField] private float dashDuration = 0.2f; // Player dash duration
    [SerializeField] private float dashCooldown = 1f; // Player dash cooldown

    //rigidbody and moveVector variables
    private Rigidbody2D rb = null;
    private Vector2 movement = Vector2.zero;
    private Animator animator;

    //movement bool variables
    private bool isRunning = false;
    private bool isDashing = false;
    private bool canDash = false;

    private void Awake()
    {
        //checks to see if there is more than one instance of player in the scene
        //if there is more than once instance of player then the object is deleted
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
        {
            for (int i = 1; i < players.Length; i++)
            {
                Destroy(players[i]);
            }
        }
        DontDestroyOnLoad(gameObject);

        //initialising variables
        input = new MyGameActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
        input.Player.Exit.performed += OnExit;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        input.Player.Exit.performed -= OnExit;
    }

    private void FixedUpdate() //fixed update used for physics calculations such as player movement
    {
        //Debug.Log("Vector: " + moveVector);
        //Debug.Log("Player Position: " + transform.position); //outputs player position in world space to the console
        //rb.velocity= moveVector * moveSpeed;
        if(!isDashing)
        {
            if(movement.magnitude > 0.1f)
            {
                rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
            }
            UpdateAnimationStates();
        }
    }

    //void used for handling animation in relation to x,y coordinates
    private void UpdateAnimationStates()
    {
        Vector2 direction = movement.normalized;

        //animations are called through code rather than animator
        if(direction.x > 0)
        {
            animator.Play("Player_Run_Right");
            //Debug.Log("Walking right");
        }
        else if(direction.x < 0)
        {
            animator.Play("Player_Run_Left");
            //Debug.Log("Walking left");
        }
        else if (direction.y > 0)
        {
            animator.Play("Player_Walking_Up");
            //Debug.Log("Walking up");
        }
        else if (direction.y < 0)
        {
            animator.Play("Player_Walking_Down");
            //Debug.Log("Walking down");
        }
        else
        {
            animator.Play("Player_Idle");
            //Debug.Log("Idle");
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value) //takes in movement actions which have been performed and passes through to OnEnable()
    {
        movement = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value) //takes in movement actions which have been cancelled and passes through to OnDisable()
    {
        movement = Vector2.zero;
    }

    private void OnExit(InputAction.CallbackContext button)
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
