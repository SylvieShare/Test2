using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int spawnCount;
    public Vector2 spawn;
    public float startWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(
                    enemy,
                    new Vector3(Random.Range(-21f, 21f), 13, 0),
                    enemy.transform.rotation);
            }
            yield return new WaitForSeconds(Random.Range(spawn.x, spawn.y));
        }
    }
}
