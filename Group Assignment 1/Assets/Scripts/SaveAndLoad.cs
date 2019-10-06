using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SaveAndLoad : MonoBehaviour
{
    EntityFactory entityFactory;
    private void Start()
    {
        entityFactory = EntityFactory.GetInstance;
    }
    const string DLL_NAME = "DLL";
    [DllImport(DLL_NAME)]
    private static extern void Save(float[] objectList);
    [DllImport(DLL_NAME)]
    private static extern System.IntPtr Load();
    
    public List<float> tempList;

    public void SaveButton()
    {
        List<GameObject> objList = entityFactory.objectList;
        float[] tempFloat = new float[objList.Count * 4 + 1];
        tempFloat[0] = objList.Count*4+1;
        tempList.Add(0);
        tempList.Clear();
        //tempList.Add()
        for (int i = 0; i < objList.Count; i++)
        {
            tempList.Add(objList[i].transform.position.x);
            tempList.Add(objList[i].transform.position.y);
            tempList.Add(objList[i].transform.position.z);
            tempList.Add(entityFactory.objectTypeList[i]);
        }
        for(int i = 1; i < tempList.Count+1;i++)
        {
            tempFloat[i] = tempList[i - 1];
        }
        Save(tempFloat);
    }

    public void LoadButton()
    {
        float[] temp = { 0 };
        Marshal.Copy(Load(), temp, 0, 1);
        float[] temp2 = new float[(int)temp[0]];
        Marshal.Copy(Load(), temp2, 0, (int)temp[0]);

        tempList.Clear();
        for(int i = 1; i < (int)temp[0]; i++)
        {
            tempList.Add(temp2[i]);
        }
        for(int i = 0; i < tempList.Count/4; i++)
        {
            Vector3 position = new Vector3(0,0,0);
            position.x = tempList[0];
            tempList.RemoveAt(0);
            position.y = tempList[0];
            tempList.RemoveAt(0);
            position.z = tempList[0];
            tempList.RemoveAt(0);
            entityFactory.spawnPosition = position;

            if (tempList[0] == 0)
                entityFactory.SpawnPlayer();
            else if (tempList[0] == 1)
                entityFactory.SpawnPlane();
            else if (tempList[0] == 2)
                entityFactory.SpawnCube();
            else
                entityFactory.SpawnSphere();

            tempList.RemoveAt(0);
        }
    }
}
