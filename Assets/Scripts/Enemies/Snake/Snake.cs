using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public static int totalSnakeKills = 0;
    public Animator animator;
    private Rigidbody2D rb;

    void Awake()
    {
        //GetComponent<Collider2D>().isTrigger = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HitBySword()
    {
        animator.SetBool("hit", true);
        StartCoroutine(SnakeDeath());
    }

    public IEnumerator SnakeDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            //HitBySword();
            //increments new coin to the coin counter
            totalSnakeKills++;
            //prints out total number of coins collected by the player to the debug console
            Debug.Log("You currently have " + totalSnakeKills + " snake kills.");
        }
    }
}