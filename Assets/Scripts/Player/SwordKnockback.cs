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
