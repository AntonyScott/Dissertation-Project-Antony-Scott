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
        hitCount++;
        if (hitCount == 2)
        {
            Debug.Log("Boss death");
            StartCoroutine(BossDeath());
        }
    }

    public IEnumerator BossDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1.2f);

        //if player has killed <= 20 snakes, <= 5 tree enemies and amassed <= coins
        if (PlayerPrefs.GetInt("SnakeKillCount") >= 10 && PlayerPrefs.GetInt("TreeEnemyKillCount") >= 10
            && PlayerPrefs.GetInt("CoinCount") >= 60)
        {
            Debug.Log("Ending 1");
            SceneManager.LoadScene("Ending 1");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        else if (PlayerPrefs.GetInt("SnakeKillCount") > 10 && PlayerPrefs.GetInt("TreeEnemyKillCount") > 15
            && PlayerPrefs.GetInt("CoinCount") < 30)
        {
            SceneManager.LoadScene("Ending 2");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") > 30 && PlayerPrefs.GetInt("TreeEnemyKillCount") > 10
                    && PlayerPrefs.GetInt("CoinCount") > 0)
        {
            SceneManager.LoadScene("Ending 3");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") == 0 && PlayerPrefs.GetInt("TreeEnemyKillCount") == 0
                    && PlayerPrefs.GetInt("CoinCount") == 0)
        {
            SceneManager.LoadScene("Ending 6");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") <= 20 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 10
                    && PlayerPrefs.GetInt("CoinCount") <= 20)
        {
            SceneManager.LoadScene("Ending 5");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else if (PlayerPrefs.GetInt("SnakeKillCount") <= 20 && PlayerPrefs.GetInt("TreeEnemyKillCount") <= 10
                    && PlayerPrefs.GetInt("CoinCount") <= 45)
        {
            SceneManager.LoadScene("Ending 4");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        
        else
        {
            SceneManager.LoadScene("Ending 4");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine (BossDeath());
        }
    }
}