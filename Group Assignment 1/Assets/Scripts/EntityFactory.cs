using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    private static EntityFactory instance = null;

    public List<GameObject> objectList;
    public List<float> objectTypeList;
    public List<GameObject> undoObjectList;
    public List<float> undoTypeObjectList;

    public Vector3 spawnPosition;
    public GameObject player;
    public GameObject plane;
    public GameObject cube;
    public GameObject sphere;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public static EntityFactory GetInstance
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
    public void SpawnPlayer()
    {
        objectList.Add(Instantiate(player, spawnPosition, Quaternion.identity));
        objectTypeList.Add(0);
    }
    public void SpawnPlane()
    {
        objectList.Add(Instantiate(plane, spawnPosition, Quaternion.identity));
        objectTypeList.Add(1);
    }
    public void SpawnCube()
    {
        objectList.Add(Instantiate(cube, spawnPosition, Quaternion.identity));
        objectTypeList.Add(2);
    }
    public void SpawnSphere()
    {
        objectList.Add(Instantiate(sphere, spawnPosition, Quaternion.identity));
        objectTypeList.Add(3);
    }

    private void Update()
    {

        if (objectList.Count > 0)
        {
            GameObject gameObject = objectList[objectList.Count - 1];
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+0.1f);
            }
            if (Input.GetKey(KeyCode.RightControl))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z -0.1f);
            }

        }
    }
}
