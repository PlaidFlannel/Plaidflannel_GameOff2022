using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField][Range(0, 50)] int poolSize = 5;
    int poolSize;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 1f;

    [SerializeField]  GameObject[] spawnLocations;

    GameObject[] pool;

    [SerializeField] bool respawnEnemies;
    bool spawnEnemies = true;
    void Awake()
    {
        poolSize = spawnLocations.Length;
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, spawnLocations[i].transform);
            pool[i].SetActive(false);
        }

    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
        if (respawnEnemies == false)
        {
            spawnEnemies = false;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (spawnEnemies)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
