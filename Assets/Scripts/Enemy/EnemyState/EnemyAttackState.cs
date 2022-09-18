public class EnemyAttackState : EnemyState
{
    public override void Construct()
    {
        animator?.SetTrigger("Attack");
    }

    public override void Transition()
    {
        base.Transition();
    }
}
