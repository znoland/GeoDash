using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float followUpThreshold = 2f; 
    public float cameraFollowSpeed = 5f;

    public float minY;
    public float planeModeY = 5f; 
    
    public bool planeMode = false;

    private void Start()
    {
        minY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        
        if (!planeMode)
        {
            float desiredY = pos.y;
            
            if (target.position.y > pos.y + followUpThreshold)
            {
                desiredY = target.position.y - followUpThreshold;
            }
            
            else if (target.position.y < pos.y - followUpThreshold)
            {
                desiredY = target.position.y + followUpThreshold;
            }
            
            desiredY = Mathf.Max(desiredY, minY);
            
            pos.y = Mathf.Lerp(pos.y, desiredY, Time.deltaTime * cameraFollowSpeed);
        }
        else
        {
            pos.y = planeModeY;
        }

        transform.position = pos;
    }
}
