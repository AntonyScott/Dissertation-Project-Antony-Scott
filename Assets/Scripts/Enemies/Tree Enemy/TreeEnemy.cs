using System.Collections;
using UnityEngine;

public class TreeEnemy : MonoBehaviour
{
    public static int totalTreeEnemyKills = 0;
    public Animator animator;
    private Rigidbody2D rb;

    public GameObject heart;

    private int hitCount = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HitBySword()
    {
        hitCount++;
        if (hitCount == 2)
        {
            StartCoroutine(TreeDeath());
        }
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

        totalTreeEnemyKills++;
        Debug.Log("Tree hit");
        PlayerPrefs.SetInt("TreeEnemyKillCount", totalTreeEnemyKills);
        PlayerPrefs.Save();

        Debug.Log("You currently have " + totalTreeEnemyKills + " tree enemy kills.");

        animator.SetBool("hit", true); // Set the "hit" parameter of the animator to true

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hitCount > 0 && !animator.GetBool("hit"))
            {
                hitCount = 0;
            }
        }
    }
}
