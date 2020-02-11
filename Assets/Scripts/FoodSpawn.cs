using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public Transform[] SpawnPosition;
    public GameObject food;
    GameObject foodClone;

    public int spawnRate = 5;

    public List<GameObject> foods;

    Vector3[] Locations;

    void SpawnObject(Vector3 spawnLocation)
    {
        foods.Add(Instantiate(food, spawnLocation, new Quaternion()));
    }

    private void Update()
    {
        //every 5 seconds
        int randomChoice = Random.Range(0, SpawnPosition.Length);
        SpawnObject(  SpawnPosition[randomChoice].position   );
        //chose random location
        //SpawnObject(randomlocation)
    }
}

