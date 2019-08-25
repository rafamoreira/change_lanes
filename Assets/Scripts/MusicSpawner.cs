using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour
{
  private static MusicSpawner _instance;

  public static MusicSpawner Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = GameObject.FindObjectOfType<MusicSpawner>();
      }

      return _instance;
    }
  }
  public float spawnTimer = .5f;
  public GameObject musicSection;

  public List<GameObject> musicList;

  public Transform preRenderedWaveCubes;

  // Start is called before the first frame update
  void Start()
  {
    Transform[] allChildren = preRenderedWaveCubes.GetComponentsInChildren<Transform>();
    foreach (Transform child in preRenderedWaveCubes) {
        musicList.Add(child.gameObject);
    }

    InvokeRepeating("SpawnSection", 0f, spawnTimer);
  }

  void SpawnSection()
  {
    musicList.Add(Instantiate(musicSection, transform.position, Quaternion.identity));
  }
}
