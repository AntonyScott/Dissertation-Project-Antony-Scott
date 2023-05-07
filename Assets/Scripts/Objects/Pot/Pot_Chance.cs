using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Chance : MonoBehaviour
{
    private Animator animator;

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

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

        if(randomNumber <= 0.25f)
        {
            Instantiate(object1, transform.position, Quaternion.identity);
        }
        if (randomNumber <= 0.50f)
        {
            Instantiate(object2, transform.position, Quaternion.identity);
        }
        else if ((randomNumber <= 1.0f))
        {
            Instantiate(object3, transform.position, Quaternion.identity);
        }
        
    }
}
