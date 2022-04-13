using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;

    public bool isBoss = false;
    public float spawnInterval;
    private float nextSpawn;
    public int miniEnnemySpawnCount;
    private SpawnManager spawnManager;

    private Rigidbody enemyRb;
    private GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (isBoss) {
            spawnManager = FindObjectOfType<SpawnManager>();

        }
    }


    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if (isBoss) {
            if (Time.time > nextSpawn) {
                nextSpawn = Time.time + spawnInterval;
                spawnManager.SpawnMiniEnemy(miniEnnemySpawnCount);
            }
        }

        if (transform.position.y < -10) { Destroy(gameObject); }
    }
}
