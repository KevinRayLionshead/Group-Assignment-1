using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    public Vector3 spawnPosition;
    public GameObject player;
    public GameObject plane;
    public GameObject cube;
    public GameObject sphere;

    public void SpawnPlayer() { Instantiate(player, spawnPosition, Quaternion.identity); }
    public void SpawnPlane() { Instantiate(plane, spawnPosition, Quaternion.identity); }
    public void SpawnCube() { Instantiate(cube, spawnPosition, Quaternion.identity); }
    public void SpawnSphere() { Instantiate(sphere, spawnPosition, Quaternion.identity); }
}
