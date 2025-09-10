using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;
using Esri.HPFramework;
using Unity.Mathematics;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private ArcGISMapComponent arcGISMapComponent;

    public void PrintCoordinates()
    {
        // convert Unity location to irl coordinates
        ArcGISPoint coordinates = arcGISMapComponent.View.WorldToGeographic(arcGISMapComponent.GetComponent<HPRoot>().InverseTransformPoint(new double3(transform.position)));
        Debug.Log($"{name} is at ({coordinates.X}, {coordinates.Y})");
    }
}