using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    // spoilers: not really a tree spawner :(

    private List<Tree> treeList;

    private void Awake()
    {
        // makes a list of Tree objects (but there's only one)
        treeList = FindObjectsByType<Tree>(FindObjectsSortMode.None).ToList();
    }

    private void Start()
    {
        SpawnTrees();
    }

    public void SpawnTrees()
    {
        // TODO: make tree be in different places (if you put more than one tree in, they end up in the same spot)
        foreach (Tree obj in treeList)
        {
            obj.PrintCoordinates();
        }
    }
}