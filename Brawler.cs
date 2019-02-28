using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brawler : MonoBehaviour
{
    Animator animator;
    int closeAttackerCount = 0;
    int attackStartTime = 2;
    [SerializeField] int damage = 100;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerClose())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerClose()
    {
        Attacker[] attackers = FindObjectsOfType<Attacker>();
        foreach (Attacker attacker in attackers)
        {
                bool isCloseEnough =
                    (Mathf.Abs(attacker.transform.position.x - transform.position.x) <= attackStartTime 
                    && Mathf.Abs(attacker.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                closeAttackerCount++;
            }
        }
        if (closeAttackerCount == 0)
        {
            return false;
        }
        else
        {
            closeAttackerCount = 0;
            return true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(damage);
        }
    }

}
