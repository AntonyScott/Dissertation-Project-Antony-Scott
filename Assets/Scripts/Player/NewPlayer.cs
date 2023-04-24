using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*public enum PlayerState
{
    walking,
    attacking,
    interacting,
    idle
}*/

public class NewPlayer : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 change;

    //
    private Rigidbody2D rb;
    private Animator animator;
    

    // Start is called before the first frame update
    private void Awake()
    {
        

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            for (int i = 1; i < players.Length; i++)
            {
                Destroy(players[i]);
            }
        }
        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

        if ((Vector3)change != Vector3.zero)
        {
            //transform.Translate(new Vector3(change.x, change.y));
            Movement();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);
            FindObjectOfType<AudioManager>().Play("Footsteps");
        }
        else
        {
            animator.SetBool("isMoving", false);
            FindObjectOfType<AudioManager>().StopPlaying("Footsteps");
        }
    }

    void Movement()
    {
        rb.MovePosition(transform.position + ((Vector3)change).normalized * moveSpeed * Time.deltaTime);
    }
}
