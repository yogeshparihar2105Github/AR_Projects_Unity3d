using UnityEngine;

public class Explode : MonoBehaviour
{
    public Animator animator;

    public bool isExploded = false;

    public GameObject joinText;
    public GameObject seperateText;

    private void Awake()
    {
        seperateText.SetActive(true);
        joinText.SetActive(false);
    }

    public void ToggleExplode_Join()
    {
        if(isExploded)
        {
            joinText.SetActive(false);
            JoinsAnimation();
            isExploded = false;
            seperateText.SetActive(true);
        }
        else
        {
            seperateText.SetActive(false);
            ExplodeAnimation();
            isExploded = true;
            joinText.SetActive(true);
        }
    }

    private void ExplodeAnimation()
    {   
        animator.Play("turbineSeperate"); 
    }
    private void JoinsAnimation()
    {
        animator.Play("turbineJoin");
    }

}
