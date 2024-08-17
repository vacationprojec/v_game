using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        int type = Random.Range(0, spawnData.Length);
        GameObject enemy = GameManager.instance.pool.Get(type);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<MonsterLogic>().Init(spawnData[type]);
    }

    
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
