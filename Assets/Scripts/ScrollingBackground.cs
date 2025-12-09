using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Material material;
    Vector2 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
