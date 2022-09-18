using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    protected ZombieMotor zmotor;
    protected Animator animator;
    public string status;
    
    public virtual void Construct() { }

    public virtual void Destruct() { }

    public virtual void Transition() { }

    private void Awake()
    {
        zmotor = GetComponent<ZombieMotor>();
        animator = GetComponent<Animator>();
        status = "Base";
    }
}
