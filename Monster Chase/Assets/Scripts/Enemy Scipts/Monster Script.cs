using UnityEngine;

public class MonsterScript : MonoBehaviour
{
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
        this.speed = -6;
    }

    // Update is called once per frame
    void Update()
    {
        this.myBody.linearVelocity = new Vector2(speed,myBody.linearVelocity.y);

    }
    
}
