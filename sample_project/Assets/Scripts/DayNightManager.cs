using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Esri.ArcGISMapsSDK.Components;

public class DayNightManager : MonoBehaviour
{
    private Light sunLight;
    private ArcGISMapComponent mapComponent;


    private void Awake()
    {
        sunLight = FindFirstObjectByType<Light>();
        mapComponent = FindFirstObjectByType<ArcGISMapComponent>(); 
    }

    void Update()
    {
        RotateSky();
    }

    private void RotateSky()
    {
        float longitude = (float)mapComponent.OriginPosition.X;

        if (longitude < 0)
        {
            longitude += 360f;
        }

        sunLight.transform.localRotation = Quaternion.Euler(new Vector3(((System.DateTime.Now.Hour / 24f) * 360f) + (float)longitude - 90f, 0f, 0f));
    }
}
