using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    private List<Tree> treeList;

    private void Awake()
    {
        // Get a list of all the trees
        treeList = FindObjectsByType<Tree>(FindObjectsSortMode.None).ToList();
    }

    private void Start()
    {
        SpawnTrees();
    }

    public void SpawnTrees()
    {
        // Update the trees
        foreach (Tree obj in treeList)
        {
            obj.PrintCoordinates();
        }
    }
}