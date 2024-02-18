using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{

    public bool isActive = true;

    public void Toggle_Visibility()
    {
        if(isActive)
        {
            transform.gameObject.SetActive(false);
            isActive = false;
        }
        else
        {
            transform.gameObject.SetActive(true);
            isActive = true;
        }
    }
}
