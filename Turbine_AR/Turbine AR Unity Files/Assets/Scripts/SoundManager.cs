using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSRC;
    public AudioClip turbineSFX;

    public void PlayTurbineSFX()
    {
        audioSRC.PlayOneShot(turbineSFX);
    }
}
