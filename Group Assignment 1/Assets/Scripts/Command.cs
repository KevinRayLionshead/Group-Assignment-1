using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Command
{
    void Execute();
}

public class SpawnPlayer : Command
{
    EntityFactory entityFactory = EntityFactory.instance;

    public void Execute()
    {
        entityFactory.SpawnPlayer();
    }
}
public class SpawnPlane : Command
{
    EntityFactory entityFactory = EntityFactory.instance;

    public void Execute()
    {
        entityFactory.SpawnPlane();
    }
}
public class SpawnCube : Command
{
    EntityFactory entityFactory = EntityFactory.instance;

    public void Execute()
    {
        entityFactory.SpawnCube();
    }
}
public class SpawnSphere : Command
{
    EntityFactory entityFactory = EntityFactory.instance;

    public void Execute()
    {
        entityFactory.SpawnSphere();
    }
}


public class Undo : Command
{
    EntityFactory entityFactory = EntityFactory.instance;
    public void Execute()
    {
        entityFactory.undoObjectList.Add(entityFactory.objectList[entityFactory.objectList.Count]);
        entityFactory.objectList.RemoveAt(entityFactory.objectList.Count);
    }
}
public class Redo : Command
{
    EntityFactory entityFactory = EntityFactory.instance;
    public void Execute()
    {
        entityFactory.objectList.Add(entityFactory.undoObjectList[entityFactory.undoObjectList.Count]);
        entityFactory.undoObjectList.RemoveAt(entityFactory.undoObjectList.Count);
    }
}

