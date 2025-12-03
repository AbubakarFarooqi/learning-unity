using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.LogWarning("Collided");
        if (collider.CompareTag(ENEMY_TAG))
        {
            Destroy(collider.gameObject);
        }
    }
}
