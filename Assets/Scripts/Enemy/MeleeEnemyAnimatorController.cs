using UnityEngine;

public class MeleeEnemyAnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAttack(bool isAttacking)
    {
        animator.SetTrigger("Attack");
    }

    public void SetRun(bool isRunning)
    {
        
    }

    public void SetStunned(bool isStunned)
    {
        animator.SetTrigger("Hit");
    }

    public void SetRotate(bool isRotating)
    {
        //animator.SetBool("isRotating", isRotating);
    }

    public void SetDead(bool isDead)
    {
        animator.SetTrigger("Die");
    }
}
