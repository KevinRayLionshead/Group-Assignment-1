using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    void Execute();
}

public class SpawnPlayer : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnPlayer();
    }
}
public class SpawnPlane : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnPlane();
    }
}
public class SpawnCube : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnCube();
    }
}
public class SpawnSphere : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnSphere();
    }
}


public class Undo : Command
{
    public void Execute()
    {
        EntityFactory entityFactory = EntityFactory.GetInstance;
        GameObject gameObject = entityFactory.objectList[entityFactory.objectList.Count - 1];

        entityFactory.undoObjectList.Add(gameObject);
        entityFactory.undoTypeObjectList.Add(entityFactory.objectTypeList[entityFactory.objectList.Count - 1]);

        entityFactory.objectList.RemoveAt(entityFactory.objectList.Count - 1);
        entityFactory.objectTypeList.RemoveAt(entityFactory.objectTypeList.Count - 1);
        gameObject.SetActive(false);

    }
}
public class Redo : Command
{
    public void Execute()
    {
        EntityFactory entityFactory = EntityFactory.GetInstance;

        entityFactory.objectList.Add(entityFactory.undoObjectList[entityFactory.undoObjectList.Count-1]);
        entityFactory.objectTypeList.Add(entityFactory.undoTypeObjectList[entityFactory.undoObjectList.Count-1]);

        GameObject gameObject = entityFactory.objectList[entityFactory.objectList.Count - 1];

        gameObject.SetActive(true);

        entityFactory.undoObjectList.RemoveAt(entityFactory.undoObjectList.Count-1);
        entityFactory.undoTypeObjectList.RemoveAt(entityFactory.undoTypeObjectList.Count-1);
    }
}

