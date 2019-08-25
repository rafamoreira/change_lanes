using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour
{
    public float spawnTimer = .5f;
    public GameObject musicSection;

    // Start is called before the first frame update
    void Start() {
	InvokeRepeating("SpawnSection", 0f, spawnTimer);
    }

    void SpawnSection(){
	Instantiate(musicSection, transform.position, Quaternion.identity);
    }
}
