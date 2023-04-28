using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool isInvincible = false;

    void Start()
    {
        UpdateHearts();
    }

    void Update()
    {
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }
        if (health <= 0)
        {
            // Handle player death
            Debug.Log("Player died!");
            SceneManager.LoadScene("Main Menu");
            Destroy(gameObject);
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            TakeDamage(1); // or however much damage you want the enemy to do
            StartCoroutine(InvincibilityFrames());
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player took " +  damageAmount + " damage!");
        health -= damageAmount;
    }

    IEnumerator InvincibilityFrames()
    {
        Debug.Log("Player is now invincible!");
        isInvincible = true;
        yield return new WaitForSeconds(5f); // or however long you want the invincibility frames to last
        isInvincible = false;
        Debug.Log("Player is no longer invincible.");
    }
}
