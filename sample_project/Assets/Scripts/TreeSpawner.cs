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
        treeList = FindObjectsByType<Tree>(FindObjectsSortMode.None).ToList();
    }

    private void Start()
    {
        SpawnTrees();
    }

    public void SpawnTrees()
    {
        // TODO: make tree be in different places
        foreach (Tree obj in treeList)
        {
            obj.PrintCoordinates();
        }
    }
}