using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust the rotation speed as needed

    private Vector2 startTouchPosition;
    private bool isSwiping = false;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)) // Check if touch is not over a UI element
                    {
                        startTouchPosition = touch.position;
                        isSwiping = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        Vector2 direction = touch.position - startTouchPosition;
                        float rotationAmount = direction.x * rotationSpeed * Time.deltaTime;
                        transform.Rotate(Vector3.up, -rotationAmount);
                        startTouchPosition = touch.position; // Update start position for next frame
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }
}
