using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    private const string BULLET_TAG = "Bullet";
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
        if (collider.CompareTag(ENEMY_TAG) || collider.CompareTag(BULLET_TAG))
        {
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag(BULLET_TAG))
        {
            collider.gameObject.GetComponent<BulletScript>().InvokeBulletDestroyEvent();
            Destroy(collider.gameObject);
        }
    }
}
