using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemy : MonoBehaviour
{
    public static int totalTreeEnemyKills = 0;
    public Animator animator;
    private Rigidbody2D rb;

    public GameObject heart;

    private int attackCollisions = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HitBySword()
    {
        animator.SetBool("hit", true);
        StartCoroutine(TreeDeath());
    }

    public IEnumerator TreeDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1.2f);

        float randomNumber = Random.value;

        if (randomNumber <= 0.33f)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            attackCollisions++;

            // Check if collision has occurred twice
            if (attackCollisions == 2)
            {
                // Reset collision counter
                attackCollisions = 0;

                // Increment kill count and save to PlayerPrefs
                totalTreeEnemyKills++;
                PlayerPrefs.SetInt("TreeEnemyKillCount", totalTreeEnemyKills);
                PlayerPrefs.Save();

                Debug.Log("You currently have " + totalTreeEnemyKills + " tree enemy kills.");
            }
        }
    }
}