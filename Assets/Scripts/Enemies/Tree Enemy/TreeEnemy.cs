using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemy : MonoBehaviour
{
    public static int totalTreeEnemyKills = 0;
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HitBySword()
    {
        animator.SetBool("hit", true);
        StartCoroutine(TreeDeath());
    }

    public IEnumerator TreeDeath()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            HitBySword();
            //increments new coin to the coin counter
            totalTreeEnemyKills++;
            //prints out total number of coins collected by the player to the debug console
            Debug.Log("You currently have " + totalTreeEnemyKills + " tree enemy kills.");
        }
    }
}