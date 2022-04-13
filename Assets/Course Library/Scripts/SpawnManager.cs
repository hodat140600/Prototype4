using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public int waveNumber = 1;
    public int enemyCount;
    private float spawnRange = 9;

    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    public int bossRound;

    private void Start()
    {
        int randomPowerup = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[randomPowerup], GenerateSpawnPosition(), powerupPrefab[randomPowerup].transform.rotation);
        SpawnEnemyWave(waveNumber);
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            //Spawn a boss every x number of waves
            if (waveNumber % bossRound == 0)
            {
                SpawnBossWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
            int randomPowerup = Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[randomPowerup], GenerateSpawnPosition(), powerupPrefab[randomPowerup].transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnRangeX = Random.Range(-spawnRange, spawnRange);
        float spawnRangeZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);
        return randomPos;
    }
    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;
        //we don't want to divide by 0
        if (bossRound != 0)
        {
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }
        var boss = Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        boss.GetComponent<EnemyController>().miniEnnemySpawnCount = miniEnemysToSpawn;
    }
    public void SpawnMiniEnemy(int amount) {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(),
            miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(), enemyPrefab[randomEnemy].transform.rotation);
        }
    }
}
