using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ARObjectPlacement : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] ARRaycastManager raycastManager;

    GameObject spawnedObject;
    bool objectSpawned = false;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Update()
    {
        if (objectSpawned)
        {
            // Check for rotate gesture
            if (Input.touchCount == 3)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    float rotationSpeed = 0.5f;
                    float deltaX = touch.deltaPosition.x * rotationSpeed;
                    if (spawnedObject != null)
                    {
                        spawnedObject.transform.Rotate(Vector3.up, -deltaX);
                    }
                }
            }
        }
        else
        {
            // Spawn object if not already spawned
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hitPose = hits[0].pose;
                        SpawnObject(hitPose.position);
                    }
                }
            }
        }
    }

    void SpawnObject(Vector3 position)
    {
        if (!objectSpawned)
        {
            spawnedObject = Instantiate(objectPrefab, position, Quaternion.identity);
            objectSpawned = true;
        }
    }
}
