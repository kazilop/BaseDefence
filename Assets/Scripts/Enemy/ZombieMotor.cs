using System;
using UnityEngine;

public class ZombieMotor : MonoBehaviour
{
    [SerializeField] private float baseRunSpeed = 0.5f;
    [SerializeField] GameObject battleField;
    private EnemyState zstate;
    private float scaleFactor = 5.0f;

    [SerializeField] private float meeledistance = 0.5f;
    private PlayerMotor playerMotor;
    private Vector3 direction;

    private void Start()
    {
        zstate = GetComponent<EnemyIdleState>();
        playerMotor = FindObjectOfType<PlayerMotor>();

        zstate.Construct();
    }

    private void Update()
    {
        if (GameManager.Instance.isGameBegin)
            UpdateZMotor();
        else
        {
            if (zstate.status != "Idle")
            {
                zstate = GetComponent<EnemyIdleState>();
                zstate.Construct();
            }
        }

    }

    private void UpdateZMotor()
    {
        transform.LookAt(playerMotor.transform);

        if(Vector3.Distance(playerMotor.transform.position, transform.position) <= meeledistance)
        {
            MeeleAttack();
        }

        direction = new Vector3(playerMotor.transform.position.x * baseRunSpeed * Time.deltaTime, 0,
                                        playerMotor.transform.position.z * baseRunSpeed * Time.deltaTime);

        if (zstate.status != "Run")
        {
            zstate = GetComponent<EnemyRunningState>();
            zstate.Construct();
        }

        if (transform.position.z > (battleField.transform.position.z - battleField.transform.localScale.z * scaleFactor))
            transform.Translate(direction);
        else
            transform.Translate(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f));
        
    }

    private void MeeleAttack()
    {
        print("Attack");
        zstate = GetComponent<EnemyAttackState>();
        zstate.Construct();
    }

}
