using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;

    public GameObject coin;
    public GameObject snake;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash() 
    {
        animator.SetBool("hit", true);
        StartCoroutine(Disintegrate());
        
    }

    public IEnumerator Disintegrate()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

        float randomNumber = Random.value;

        if(randomNumber <= 0.6f)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(snake, transform.position, Quaternion.identity);
        }
        
    }
}
