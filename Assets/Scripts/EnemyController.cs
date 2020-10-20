using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IHitable
{
    [SerializeField] int health = 100;

    NavMeshAgent navMeshAgent;
    Transform target;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health < 0)
        {
            health = 0;
        }

        if(health == 0)
        {
            animator.SetBool("IsDead", true);
            Destroy(gameObject);
        }
    }
}
