using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    public static EntityFactory instance;

    public List<GameObject> objectList;

    public Vector3 spawnPosition;
    public GameObject player;
    public GameObject plane;
    public GameObject cube;
    public GameObject sphere;

    public EntityFactory GetInstance
    {
        get
        {
            if (!instance)
            {
                GameObject gameObject = new GameObject();
                instance = gameObject.GetComponent<EntityFactory>();
            }
            return instance;
        }
    }
    public void SpawnPlayer() { Instantiate(player, spawnPosition, Quaternion.identity); objectList.Add(player); }
    public void SpawnPlane() { Instantiate(plane, spawnPosition, Quaternion.identity); objectList.Add(plane); }
    public void SpawnCube() { Instantiate(cube, spawnPosition, Quaternion.identity); objectList.Add(cube); }
    public void SpawnSphere() { Instantiate(sphere, spawnPosition, Quaternion.identity); objectList.Add(sphere); }
}
