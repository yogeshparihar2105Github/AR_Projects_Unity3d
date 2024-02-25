using TMPro;
using UnityEngine;

public class BasketballController : MonoBehaviour
{
    public float swipeMinLength = 300f; // Minimum length of swipe to be considered
    public float swipeMinVelocity = 200f; // Minimum velocity of swipe to be considered
    public float maxSwipeVelocity = 1000f; // Maximum velocity to consider for max force
    public float maxShootForce = 0.1f; // Maximum shoot force when swiping quickly
    public float minShootForce = 0.02f; // Minimum shoot force when swiping normally
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource;
    public AudioClip goalSFX;

    private Vector2 startPos;
    private Vector2 endPos;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;
                Vector2 swipeDirection = endPos - startPos;
                float swipeSpeed = swipeDirection.magnitude;

                if (swipeDirection.y > swipeMinLength && swipeSpeed > swipeMinVelocity)
                {
                    float forcePercentage = Mathf.Clamp01(swipeSpeed / maxSwipeVelocity);
                    float shootForce = Mathf.Lerp(minShootForce, maxShootForce, forcePercentage);
                    Debug.Log("Swipe Speed: " + swipeSpeed);
                    Debug.Log("Shoot Force: " + shootForce);
                    Shoot(shootForce);
                }
            }
        }

        if(transform.position.y < -1.5f)
        {
            ResetBallPos();
        }
    }

    void Shoot(float shootForce)
    {
        Vector3 shootDirection = new Vector3(0f, 1f, -1f); // Shooting direction (upwards and forwards)
        rb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        rb.useGravity = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hoop")
        {
            Debug.Log("Scored!");
            ScoreManager.IncreaseScore(1);
            audioSource.PlayOneShot(goalSFX);
            scoreText.text = ScoreManager.GetScore().ToString();
            
        }
    }

    public void ResetBallPos()
    {
        rb.velocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        transform.position = new Vector3(0, -0.3f, 1); 
    }
}
