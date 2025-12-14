using UnityEngine;

public class MeleeBoss : AbstractEnemy
{
    [Range(0.1f, 10)]
    public float attackRange = 2;
    [Range(1, 100)]
    public int damage = 5;

    RunTo runState;
    Attack attackState;
    Stunned stunnedState;
    RotateTo rotateState;

    private Animator animator;

    private void Start()
    {
        base.Start();
        runState = new RunTo(this);
        attackState = new Attack(this);
        stunnedState = new Stunned(this);
        rotateState = new RotateTo(this);

        stateMachine.startingState(runState);

        animator = GetComponent<Animator>();
    }

    public override void updateState()
    {
        if (dead == true) return;

        if (stunned == true)
        {
            stateMachine?.setState(stunnedState);
        }
        else
        {
            if (Vector3.Angle(transform.forward, player.position - transform.position) > 20)
            {
                stateMachine?.setState(rotateState);
            }
            else
            if (Vector3.Distance(transform.position, player.position) > attackRange)
            {
                stateMachine?.setState(runState);
            }
            else
            if (Vector3.Angle(transform.forward, player.position - transform.position) > 10)
            {
                stateMachine?.setState(rotateState);
            }
            else
            {
                stateMachine?.setState(attackState);
            }
        }

        stateMachine?.update();
    }

    public override void attack(bool state)
    {
        if (Random.Range(0, 100) < 30)
        {
            // Анимация доп аттаки
        }
        else
        {
            base.attack(state);
        }
    }

    public void dealDamage()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Health playerHP = player.GetComponent<Health>();
            Debug.Log(playerHP);
            
            if (playerHP != null)
            {
                playerHP.hpDecrease(damage);
            }
        }
    }
    
    public void dealAltDamage()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Health playerHP = player.GetComponent<Health>();
            Debug.Log(playerHP);
            
            if (playerHP != null)
            {
                playerHP.hpDecrease(damage * 2);
            }
        }

        // Тут нужна логика альт аттаки (допустим по радиусу, если противник типа прыгнул)
    }
}
