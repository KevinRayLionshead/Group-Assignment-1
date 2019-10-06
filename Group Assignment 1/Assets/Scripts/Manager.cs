using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    SpawnRock rock = new SpawnRock();
    SpawnTree tree = new SpawnTree();
    SpawnBush bush = new SpawnBush();
    SpawnFlower flower = new SpawnFlower();

    Undo undo = new Undo();
    Redo redo = new Redo();

    private void Start()
    {
        EntityFactory entityFactory = EntityFactory.GetInstance;
    }
    public void SpawnRock()
    {
        rock.Execute();
    }
    public void SpawnTree()
    {
        tree.Execute();
    }
    public void SpawnBush()
    {
        bush.Execute();
    }
    public void SpawnFlower()
    {
        flower.Execute();
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
