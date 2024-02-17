using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour
{
    public Slider rotationSpeedSlider;
    public GameObject smokeFX;

    public TextMeshProUGUI textValueOfSlider;

    public SoundManager soundManager;

    void Update()
    {
        textValueOfSlider.text = rotationSpeedSlider.value.ToString();
        soundManager.audioSRC.volume = 0.001f * rotationSpeedSlider.value;
        soundManager.PlayTurbineSFX();

        if(rotationSpeedSlider.value > 0.4f * rotationSpeedSlider.maxValue)
        {
            smokeFX.SetActive(true);
        }
        else
        {
            smokeFX.SetActive(false);
        }
        transform.Rotate(rotationSpeedSlider.value * Vector3.up * Time.deltaTime);   
    }

}
