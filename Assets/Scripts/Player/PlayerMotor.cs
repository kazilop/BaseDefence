using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMotor : MonoBehaviour
{
    [HideInInspector] public Vector3 moveVector;

    [Header("Settings")]

    public float baseRunSpeed = 50.0f;

    public CharacterController controller;

    private BaseState state;
    private Transform playerTransform;
    private Vector3 startPosition;

    [SerializeField] GameObject safeZone;


    private bool isPaused;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        state = GetComponent<RunningState>();
        playerTransform = GetComponent<Transform>();

        startPosition = transform.position;

        isPaused = true;

        state.Construct();
    }

    private void Update()
    {
        if (!isPaused)
        {
            UpdateMotor();
            CorrectRotation();
            CheckSafeZone();
        }

        // Костыли от rigidbody - летят вверх
        if(controller.transform.position.y > 0)
        {
            controller.transform.position = new Vector3(controller.transform.position.x, 0, controller.transform.position.z);
        }
    }

    private void CheckSafeZone()
    {
        if(transform.position.z > (safeZone.transform.position.z + safeZone.transform.lossyScale.z *5))
        {
            GameManager.Instance.isGameBegin = true;
        }
        else
            GameManager.Instance.isGameBegin = false;
    }

    private void CorrectRotation()
    {
        if (playerTransform.rotation.x != 0)
        {
            playerTransform.rotation = Quaternion.Euler(0, playerTransform.rotation.y, 0);
        }
    }

    private void UpdateMotor()
    {
        moveVector = Vector3.zero;
        moveVector = state.ProcessMotion();

        state.Transition();

        controller.Move(moveVector * Time.deltaTime * baseRunSpeed);
        
    }

   
    public void ChangeState(BaseState s)
    {
        state.Destruct();
        state = s;
        state.Construct();
    }

  
    public void PausePlayer()
    {
        isPaused = true;
    }

    public void ResumePlayer()
    {
        isPaused = false;
    }



    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string hitLayerName = (hit.gameObject.tag);

        if (hitLayerName == "Death")
        {
            //  ChangeState(GetComponent<DeathState>());
            print("Death");
        }
    }

    public void RespawnPlayer()
    {
        ChangeState(GetComponent<RespawnState>());
      //  GameManager.Instance.ChangeCamera(GameCamera.Respawn);
    }

    public void ResetPlayer()
    {
        
        transform.position = startPosition;
        PausePlayer();
        ChangeState(GetComponent<RunningState>());

    }
}
