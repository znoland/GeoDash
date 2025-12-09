using UnityEditor.Build;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject plane;

    private bool hasActivated = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(hasActivated) return;
        
        if (other.gameObject == cube)
        {
            hasActivated = true;
            ActivatePlane();
        }
        
        if (other.gameObject == plane)
        {
            hasActivated = true;
            ActivateCube();
        }
        
    }

    void ActivatePlane()
    {
        plane.transform.position = cube.transform.position;
        
        cube.SetActive(false);
        
        plane.SetActive(true);
        
        CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
        cam.target = plane.transform;
    }

    void ActivateCube()
    {
        cube.transform.position = plane.transform.position;
        
        plane.SetActive(false);
        
        cube.SetActive(true);
        
        CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
        cam.target = cube.transform;
    }
}
