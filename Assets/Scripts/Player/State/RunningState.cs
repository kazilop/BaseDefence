using UnityEngine;

public class RunningState : BaseState
{
    private Vector3 worldPosition;
    private Touch touch;
    private bool isRuning;
    private Animator animator;

    [SerializeField] private ModelScript model;
        

    public override void Construct()
    {
        isRuning = false;
        animator = GetComponent<Animator>();
    }

    public override void Transition()
    {
        if (isRuning)
        {
            animator?.SetTrigger("Run");
        }
        else
        {
            animator?.SetTrigger("Idle");
        }
    }


    public override Vector3 ProcessMotion()
    {
        
        if (Input.touchCount > 0)
        {
            
            ChangeRunning(true);
            touch = Input.GetTouch(0);
            

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    worldPosition = transform.InverseTransformPoint(hit.point);
                }

                RotateModel(hit.point);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                worldPosition = Vector3.Lerp(worldPosition, Vector3.zero, 1f);
                
            }

        }
        else
            ChangeRunning(false);


        worldPosition.y = 0f;
        return worldPosition.normalized;       
    }

    private void RotateModel(Vector3 myPosition)
    {
        model.transform.LookAt(myPosition);
    }

    private void ChangeRunning(bool status)
    {
        if (isRuning == status) { return; }
        else
        {
            isRuning = status;
        }
    }
   
}
