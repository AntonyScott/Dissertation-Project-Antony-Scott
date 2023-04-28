using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : EnemyBase
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform basePosition;

    public EnemyStates currentEnemyState;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DistanceCheck();
    }

    void DistanceCheck()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius) 
        {
            if(currentEnemyState == EnemyStates.idle || currentEnemyState == EnemyStates.walking
                && currentEnemyState != EnemyStates.stagger)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeEnemyState(EnemyStates.walking);
            }
            
        }
    }

    private void ChangeEnemyState(EnemyStates newState)
    {
        if (currentEnemyState != newState)
        {
            currentEnemyState = newState;
        }
    }
}
