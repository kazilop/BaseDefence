

public class EnemyIdleState : EnemyState
{
    
    public override void Construct()
    {
        status = "Idle";
        animator?.SetTrigger(status);
        
    }
}
