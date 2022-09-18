using UnityEngine;

public class ModelScript : MonoBehaviour
{
   
    void FixedUpdate()
    {
        if(transform.rotation.x != 0)
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
    }
}
