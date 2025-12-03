using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text text;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        text = GetComponent<Text>();
        text.text = $"Score: {score}";
        BulletScript.OnEnemyHit += AddScore;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void AddScore(int n)
    {
        score += n;
        text.text = $"Score: {score}";
    }
}
