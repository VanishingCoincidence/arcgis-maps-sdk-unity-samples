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

        if (longitude < 0f)
        {
            longitude += 360f;
        }

        // finds where the light should be pointing depending on time according to the system and location
        sunLight.transform.localRotation = Quaternion.Euler(new Vector3(((System.DateTime.Now.Hour / 24f) * 360f) + longitude - 90f, 0f, 0f));
    }
}
