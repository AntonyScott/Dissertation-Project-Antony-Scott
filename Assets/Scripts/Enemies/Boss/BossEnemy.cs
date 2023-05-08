using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public static int totalTreeEnemyKills = 0;
    public Animator animator;
    private Rigidbody2D rb;

    private int attackCollisions = 0;

    private int hitCount = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HitBySword()
    {
        animator.SetBool("hit", true);
        //StartCoroutine(TreeDeath());
        hitCount++;
        if (hitCount == 10)
        {
            StartCoroutine(BossDeath());
        }
    }

    public IEnumerator BossDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1.2f);

        //if player has killed <= 20 snakes, <= 5 tree enemies and amassed <= coins
        /*if (PlayerPrefs.GetInt("SnakeKillCount") <= 5 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 5 
            && PlayerPrefs.GetInt("Coin Count") <= 60)
        {
            SceneManager.LoadScene("Ending 1");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        else if (PlayerPrefs.GetInt("SnakeKillCount") <= 8 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 15
            && PlayerPrefs.GetInt("Coin Count") <= 30)
        {
            SceneManager.LoadScene("Ending 2");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        else if (PlayerPrefs.GetInt("SnakeKillCount") <= 30 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 10
            && PlayerPrefs.GetInt("Coin Count") <= 0)
        {
            SceneManager.LoadScene("Ending 3");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        if (PlayerPrefs.GetInt("SnakeKillCount") <= 20 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 10
            && PlayerPrefs.GetInt("Coin Count") <= 45)
        {
            SceneManager.LoadScene("Ending 4");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        if (PlayerPrefs.GetInt("SnakeKillCount") <= 20 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 10
            && PlayerPrefs.GetInt("Coin Count") <= 20)
        {
            SceneManager.LoadScene("Ending 5");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        if (PlayerPrefs.GetInt("SnakeKillCount") <= 0 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 0
            && PlayerPrefs.GetInt("Coin Count") <= 0)
        {
            SceneManager.LoadScene("Ending 6");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        else
        {
            SceneManager.LoadScene("Ending 4");
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        Destroy(gameObject);*/

        if (PlayerPrefs.GetInt("SnakeKillCount") <= 5 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 5
            && PlayerPrefs.GetInt("Coin Count") <= 60)
        {
            SceneManager.LoadScene("Ending 1");
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") <= 8 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 15
            && PlayerPrefs.GetInt("Coin Count") <= 30)
        {
            SceneManager.LoadScene("Ending 2");
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") <= 20 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 10)
        {
            if (PlayerPrefs.GetInt("Coin Count") <= 0)
            {
                SceneManager.LoadScene("Ending 3");
            }
            else if (PlayerPrefs.GetInt("Coin Count") <= 20)
            {
                SceneManager.LoadScene("Ending 5");
            }
            else if (PlayerPrefs.GetInt("Coin Count") <= 45)
            {
                SceneManager.LoadScene("Ending 4");
            }
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") == 0 && PlayerPrefs.GetInt("TreeEnemyKillCount") == 0
            && PlayerPrefs.GetInt("Coin Count") == 0)
        {
            SceneManager.LoadScene("Ending 6");
        }
        else
        {
            SceneManager.LoadScene("Ending 4");
        }

        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            attackCollisions++;

            // Check if collision has occurred twice
            if (attackCollisions == 10)
            {
                // Reset collision counter
                attackCollisions = 0;

                StartCoroutine(BossDeath());
            }
        }
    }
}