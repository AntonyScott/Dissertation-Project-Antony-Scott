using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;

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
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
