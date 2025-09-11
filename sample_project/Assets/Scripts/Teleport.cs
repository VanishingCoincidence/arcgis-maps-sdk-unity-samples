using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Geometry;


public class Teleport : MonoBehaviour
{
    private ArcGISMapComponent mapComponent;
    private ArcGISCameraComponent cameraComponent;
    private ArcGISPoint montrealLocation = new ArcGISPoint(-73.5674, 45.5019, 0, ArcGISSpatialReference.WGS84());
    private ArcGISPoint bostonLocation = new ArcGISPoint(-71.0565, 42.3555, 0, ArcGISSpatialReference.WGS84());
    private ArcGISPoint nycLocation = new ArcGISPoint(-74.0060, 40.7128, 0, ArcGISSpatialReference.WGS84());
    public ArcGISPoint currentLocation;
    private TeleportAction teleportAction;
    private TreeSpawner treeSpawner;

    private void Awake()
    {
        mapComponent = FindFirstObjectByType<ArcGISMapComponent>();
        cameraComponent = mapComponent.GetComponentInChildren<ArcGISCameraComponent>();
        teleportAction = new TeleportAction();
        currentLocation = nycLocation;
        treeSpawner = FindFirstObjectByType<TreeSpawner>();
    }

    private void OnEnable()
    {
        teleportAction.Enable();
        teleportAction.Teleport.Teleport1.started += ToLocation1;
        teleportAction.Teleport.Teleport2.started += ToLocation2;
        teleportAction.Teleport.Teleport3.started += ToLocation3;
    }

    private void OnDisable()
    {
        teleportAction.Disable();
        teleportAction.Teleport.Teleport1.started -= ToLocation1;
        teleportAction.Teleport.Teleport2.started -= ToLocation2;
        teleportAction.Teleport.Teleport3.started -= ToLocation3;
    }


    /// <summary>
    /// takes you straight to Montreal, Canada. same code as two other methods below. wish i had the time to consoloate
    /// </summary>
    /// <param name="ctx"></param>
    private void ToLocation1(InputAction.CallbackContext ctx)
    {
        Debug.Log("To Montreal");
        mapComponent.OriginPosition = montrealLocation;
        mapComponent.UpdateHPRoot();
        currentLocation = montrealLocation;
        treeSpawner.SpawnTrees();
        cameraComponent.GetComponent<ArcGISLocationComponent>().Position = new ArcGISPoint(-73.5674, 45.5019, 2000, ArcGISSpatialReference.WGS84());
    }

    private void ToLocation2(InputAction.CallbackContext ctx)
    {
        Debug.Log("To Boston");
        mapComponent.OriginPosition = bostonLocation;
        mapComponent.UpdateHPRoot();
        currentLocation = bostonLocation;
        treeSpawner.SpawnTrees();
        cameraComponent.GetComponent<ArcGISLocationComponent>().Position = new ArcGISPoint(-71.0565, 42.3555, 2000, ArcGISSpatialReference.WGS84());
    }

    private void ToLocation3(InputAction.CallbackContext ctx)
    {
        Debug.Log("To NYC");
        mapComponent.OriginPosition = nycLocation;
        mapComponent.UpdateHPRoot();
        currentLocation = nycLocation;
        treeSpawner.SpawnTrees();
        cameraComponent.GetComponent<ArcGISLocationComponent>().Position = new ArcGISPoint(-74.0060, 40.7128, 2000, ArcGISSpatialReference.WGS84());
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press 1, 2, or 3 to move locations");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
