using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public static int totalSnakeKills = 0;
    public Animator animator;
    private Rigidbody2D rb;

    public GameObject coin;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HitBySword()
    {
        animator.SetBool("hit", true);
        StartCoroutine(SnakeDeath());
        GetComponent<Collider2D>().enabled = false;
    }

    public IEnumerator SnakeDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1.2f);

        float randomNumber = Random.value;

        if (randomNumber <= 0.2f)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

        // Save the updated totalSnakeKills value to PlayerPrefs
        PlayerPrefs.SetInt("SnakeKillCount", totalSnakeKills);
        PlayerPrefs.Save();
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