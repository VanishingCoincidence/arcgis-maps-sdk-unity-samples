using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;
using Esri.HPFramework;
using Unity.Mathematics;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private ArcGISMapComponent mapComponent;

    private void Awake()
    {
        mapComponent = FindFirstObjectByType<ArcGISMapComponent>();
    }


    public void PrintCoordinates()
    {
        ArcGISPoint coordinates = mapComponent.View.WorldToGeographic(mapComponent.GetComponent<HPRoot>().InverseTransformPoint(new double3(transform.position)));
        Debug.Log($"Tree: {coordinates.X}, {coordinates.Y}");
    }
}