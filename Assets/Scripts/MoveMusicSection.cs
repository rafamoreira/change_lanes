using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMusicSection : MonoBehaviour
{
    Rigidbody rbd;
    public float speed = 2;
    float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 27;
        rbd = GetComponent<Rigidbody>();
	    rbd.velocity = new Vector3(0, 0, speed);   
    }

    void Update(){
        if (lifeTime >= 0){
            lifeTime -= Time.deltaTime;
        } else {
            Despawn();
        }
    }

    void Despawn(){
        MusicSpawner.Instance.musicList.Remove(gameObject);
        Destroy(gameObject);
    }
}
