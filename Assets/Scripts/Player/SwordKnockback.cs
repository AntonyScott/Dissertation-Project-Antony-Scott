using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordKnockback : MonoBehaviour
{
    [SerializeField] private float thrust;

    [SerializeField] protected float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.GetComponent<EnemyPathfinding>().currentEnemyState = EnemyStates.stagger;
                StartCoroutine(KnockCoroutine(enemy));
                Debug.Log("Enemy Hit!");
                FindObjectOfType<AudioManager>().Play("Enemy Grunt");
            }
        }

        if (collision.CompareTag("Break"))
        {
            collision.GetComponent<Pot>().Smash();
        }

        if (collision.CompareTag("Break_Chance"))
        {
            collision.GetComponent<Pot_Chance>().Smash();
        }

        if (collision.CompareTag("Snake Enemy"))
        {
            Rigidbody2D snake = collision.GetComponent<Rigidbody2D>();

            if (snake != null)
            {
                snake.GetComponent<EnemyPathfinding>().currentEnemyState = EnemyStates.stagger;
                StartCoroutine(KnockCoroutine(snake));
                collision.GetComponent<Snake>().HitBySword();
                //Debug.Log("Enemy Hit!");
                FindObjectOfType<AudioManager>().Play("Hiss");
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        Vector2 forceDirection = enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        enemy.velocity = force;
        yield return new WaitForSeconds(.3f);

        enemy.velocity = Vector2.zero;
        enemy.GetComponent<EnemyPathfinding>().currentEnemyState = EnemyStates.idle;
    }
}
