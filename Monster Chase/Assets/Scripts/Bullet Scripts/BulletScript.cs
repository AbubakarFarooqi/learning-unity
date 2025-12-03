using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static event Action<int> OnEnemyHit;
    public static event Action onDestoryBullet;
    private const string ENEMY_TAG = "Enemy";
    public Rigidbody2D myBody;
    [HideInInspector]
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        this.myBody = GetComponent<Rigidbody2D>();
        this.speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        this.myBody.linearVelocity = new Vector2(speed,myBody.linearVelocity.y);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(ENEMY_TAG))
        {
            Destroy(collider.gameObject);
            OnEnemyHit?.Invoke(1);
            Destroy(gameObject); // destroy bullet
        }
    }
    public void InvokeBulletDestroyEvent()
    {
        onDestoryBullet?.Invoke();
    }
}
