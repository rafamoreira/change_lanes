using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnSpaces;
    public float spawnTimer = .5f;
    public GameObject enemy;
    int offset_spawn = 500;

    // Start is called before the first frame update
    void Start() {
	InvokeRepeating("SpawnEnemy", 0f, spawnTimer);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void SpawnEnemy(){
	Transform spawnPoint = spawnSpaces[Random.Range(0, spawnSpaces.Length)];
	Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }
}
