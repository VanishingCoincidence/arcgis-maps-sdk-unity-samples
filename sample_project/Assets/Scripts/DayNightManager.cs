using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Esri.ArcGISMapsSDK.Components;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] private DirectionalLight sunLight;
    //[SerializeField] private LightingPreset lightPreset;

    [Range(0f, 24f)]
    [SerializeField] private float timeOfDay;

    private ArcGISMapComponent mapComponent;


    private void Awake()
    {
        mapComponent = FindFirstObjectByType<ArcGISMapComponent>(); 
    }

    void Update()
    {
        
        RotateSky(System.DateTime.Now.Hour/ 24f);
        
    }

    private void RotateSky(float time)
    {
        var rotationCalculation = time * 360;

        if (time >= 24.0)
        {
            time = 0.0f;
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (float)rotationCalculation);
        }
    }
}
