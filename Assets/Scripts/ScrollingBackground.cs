using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform player;
    public float parallaxFactor = 0.5f;

    private float length;
    private Vector3 lastPlayerPos;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        lastPlayerPos = player.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float deltaX = player.position.x - lastPlayerPos.x;
        
        transform.position += new Vector3(deltaX * parallaxFactor, 0, 0);

        lastPlayerPos = player.position;
        
        float distanceFromPlayer = transform.position.x - player.position.x;

        if (distanceFromPlayer < -length)
        {
            transform.position += new Vector3(length * 2.5f, 0, 0);
        }
    }
}
