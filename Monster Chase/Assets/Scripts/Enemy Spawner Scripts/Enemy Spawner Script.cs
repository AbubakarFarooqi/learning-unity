using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    private string[] positions = {"Left","Right"}; 
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private Transform leftPos;
    [SerializeField]
    private Transform rightPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            int idx = Random.Range(0, enemies.Count);
            string position = positions[Random.Range(0,2)];
            var spawnedEnemy = Instantiate(enemies[idx]);

            if (position == "Left")
            {
                spawnedEnemy.transform.position = leftPos.position;
                spawnedEnemy.GetComponent<MonsterScript>().speed = Random.Range(3, 8);
            }
            else
            {
                spawnedEnemy.transform.position = rightPos.position;
                spawnedEnemy.GetComponent<MonsterScript>().speed = -Random.Range(3, 8);
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
            }
        }


    }
}
