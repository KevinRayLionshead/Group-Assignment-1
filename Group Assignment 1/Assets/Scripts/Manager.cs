using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    SpawnPlayer player = new SpawnPlayer();
    SpawnPlane plane = new SpawnPlane();
    SpawnCube cube = new SpawnCube();
    SpawnSphere sphere = new SpawnSphere();

    Undo undo = new Undo();
    Redo redo = new Redo();

    private void Start()
    {
        EntityFactory entityFactory = EntityFactory.GetInstance;
    }
    public void SpawnPlayer()
    {
        player.Execute();
    }
    public void SpawnPlane()
    {
        plane.Execute();
    }
    public void SpawnCube()
    {
        cube.Execute();
    }
    public void SpawnSphere()
    {
        sphere.Execute();
    }

    public void Undo()
    {
        undo.Execute();
    }
    public void Redo()
    {
        redo.Execute();
    }
}
