using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates{ 
    idle,
    walking,
    attacking,
    stagger
}

public class EnemyBase : MonoBehaviour
{
    public int healthPoints = 1;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed = 10f;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
