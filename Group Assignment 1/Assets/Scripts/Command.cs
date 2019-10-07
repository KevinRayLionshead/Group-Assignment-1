using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    void Execute();
}

public class SpawnRock : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnRock();
    }
}
public class SpawnTree : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnTree();
    }
}
public class SpawnBush : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnBush();
    }
}
public class SpawnFlower : Command
{
    public void Execute()
    {
        EntityFactory.GetInstance.SpawnFlower();
    }
}


public class Undo : Command
{
    public void Execute()
    {
        EntityFactory entityFactory = EntityFactory.GetInstance;
        GameObject gameObject = entityFactory.objectList[entityFactory.objectList.Count - 1];

        //adds the object and its type to the undone list
        entityFactory.undoObjectList.Add(gameObject);
        entityFactory.undoTypeObjectList.Add(entityFactory.objectTypeList[entityFactory.objectList.Count - 1]);

        entityFactory.objectList.RemoveAt(entityFactory.objectList.Count - 1);
        entityFactory.objectTypeList.RemoveAt(entityFactory.objectTypeList.Count - 1);
        //hides the undone object so that it can be brought back
        gameObject.SetActive(false);

    }
}
public class Redo : Command
{
    public void Execute()
    {
        EntityFactory entityFactory = EntityFactory.GetInstance;
        //re adds the objects to the object list
        entityFactory.objectList.Add(entityFactory.undoObjectList[entityFactory.undoObjectList.Count-1]);
        entityFactory.objectTypeList.Add(entityFactory.undoTypeObjectList[entityFactory.undoObjectList.Count-1]);

        GameObject gameObject = entityFactory.objectList[entityFactory.objectList.Count - 1];
        //unhides the objects
        gameObject.SetActive(true);

        entityFactory.undoObjectList.RemoveAt(entityFactory.undoObjectList.Count-1);
        entityFactory.undoTypeObjectList.RemoveAt(entityFactory.undoTypeObjectList.Count-1);
    }
}

