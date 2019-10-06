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
    public GameObject rock;
    public GameObject tree;
    public GameObject bush;
    public GameObject flower;

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
    public void SpawnRock()
    {
        objectList.Add(Instantiate(rock, spawnPosition, Quaternion.identity));
        objectTypeList.Add(0);
    }
    public void SpawnTree()
    {
        objectList.Add(Instantiate(tree, spawnPosition, Quaternion.identity));
        objectTypeList.Add(1);
    }
    public void SpawnBush()
    {
        objectList.Add(Instantiate(bush, spawnPosition, Quaternion.identity));
        objectTypeList.Add(2);
    }
    public void SpawnFlower()
    {
        objectList.Add(Instantiate(flower, spawnPosition, Quaternion.identity));
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
