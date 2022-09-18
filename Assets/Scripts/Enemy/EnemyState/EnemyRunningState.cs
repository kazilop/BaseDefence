
public class EnemyRunningState : EnemyState
{
    public override void Construct()
    {
        status = "Run";
        animator?.SetTrigger(status);
    }

    
}
