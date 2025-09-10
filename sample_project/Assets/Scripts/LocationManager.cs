using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapLocationController : MonoBehaviour
{

    private List<Tree> treeList;

    private void Awake()
    {
        // Get a list of all the trees
        treeList = FindObjectsByType<Tree>(FindObjectsSortMode.None).ToList();
    }

    private void SetLocationFromIndex()
    {
        // Update the trees
        foreach (Tree obj in treeList)
        {
            obj.PrintCoordinates();
        }
    }
}