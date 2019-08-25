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

  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("SpawnSection", 0f, spawnTimer);
  }

  void SpawnSection()
  {
    musicList.Add(Instantiate(musicSection, transform.position, Quaternion.identity));
  }
}
