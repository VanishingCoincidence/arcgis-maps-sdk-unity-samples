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

        // used the example but made it use the system clock
        float rotationCalculation = System.DateTime.Now.Hour / 24f * 360f - 90f;

        // finds where the light should be pointing depending on time according to the system and location
        sunLight.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotationCalculation + longitude); 
    }
}
