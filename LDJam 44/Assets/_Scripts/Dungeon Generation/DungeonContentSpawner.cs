using System.Collections.Generic;
using UnityEngine;

public class DungeonContentSpawner : MonoBehaviour {

    public List<GameObject> Rooms;

    public GameObject[] enemies;
    public GameObject shop;
    public GameObject exit;

    private int spawnType;
    private float waitTime = 2;

    private void Start()
    {
        Invoke("SpawnContent", waitTime);
    }

    public void SpawnContent()
    {
        for(int i = 0; i < Rooms.Count; i++)
        {
            if(i == Rooms.Count / 2)
            {
                Instantiate(shop, Rooms[i].transform.position, Quaternion.identity);
            }else if(i == Rooms.Count - 1)
            {
                Instantiate(exit, Rooms[i].transform.position, Quaternion.identity);
            }else
            {
                spawnType = Random.Range(0, 8);
                if(spawnType > -1 && spawnType < 5)
                {
                    Instantiate(enemies[Random.Range(0, enemies.Length)], Rooms[i].transform.position, Quaternion.identity);
                }
            }
        }
    }
}
