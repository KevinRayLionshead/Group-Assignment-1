using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SaveAndLoad : MonoBehaviour
{
    EntityFactory entityFactory;
    private void Start()//get the entity factory instance(singleton)
    {
        entityFactory = EntityFactory.GetInstance;
    }
    //load in the dll functions
    const string DLL_NAME = "DLL";
    [DllImport(DLL_NAME)]
    private static extern void Save(float[] objectList);
    [DllImport(DLL_NAME)]
    private static extern System.IntPtr Load();
    
    //Creates a temporary list for the float data to be loaded.
    public List<float> tempList;

    public void SaveButton()
    {
        List<GameObject> objList = entityFactory.objectList;
        //creates a temperary float large enough to store the x,y,z and type of each object
        //Also stores the size of itself in the first slot
        float[] tempFloat = new float[objList.Count * 4 + 1];
        tempFloat[0] = objList.Count*4+1;
        tempList.Add(0);
        tempList.Clear();
        //adds all the info for each object to a list so it can be stored in the correct order.
        for (int i = 0; i < objList.Count; i++)
        {
            tempList.Add(objList[i].transform.position.x);
            tempList.Add(objList[i].transform.position.y);
            tempList.Add(objList[i].transform.position.z);
            tempList.Add(entityFactory.objectTypeList[i]);
        }
        // stores all the info into the array
        for(int i = 1; i < tempList.Count+1;i++)
        {
            tempFloat[i] = tempList[i - 1];
        }
        //Writes the info to a file
        Save(tempFloat);
    }

    public void LoadButton()
    {
        float[] temp = { 0 };
        //reads in the size of the float
        Marshal.Copy(Load(), temp, 0, 1);
        //creates an array to hold the correct number of floats and loads them in
        float[] temp2 = new float[(int)temp[0]];
        Marshal.Copy(Load(), temp2, 0, (int)temp[0]);

        tempList.Clear();
        //adds all the info to a list so it can be parsed more easily
        for(int i = 1; i < (int)temp[0]; i++)
        {
            tempList.Add(temp2[i]);
        }
        //gets the spawn position and object type to create it in the correct spot.
        //the loop is run the same number of times as their are objects in the file
        for(int i = 0; i < ((int)temp[0]-1)/4; i++)
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
                entityFactory.SpawnRock();
            else if (tempList[0] == 1)
                entityFactory.SpawnTree();
            else if (tempList[0] == 2)
                entityFactory.SpawnBush();
            else
                entityFactory.SpawnFlower();

            tempList.RemoveAt(0);
        }
    }
}
