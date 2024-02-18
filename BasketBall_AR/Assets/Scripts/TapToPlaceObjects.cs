using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceObjects : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedGameobject;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> arRaycastHitList = new List<ARRaycastHit>();

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }


    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (arRaycastManager.Raycast(touchPosition, arRaycastHitList, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitPose = arRaycastHitList[0].pose;


            if (spawnedGameobject == null)
            {
                spawnedGameobject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedGameobject.transform.position = hitPose.position;
            }
        }
    }

}
