using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject potatoPrefab;
    public GameObject goldPrefab;

    public Transform potatoSpawnPos;
    public Transform goldSpawnPos;

    public AudioSource audioSourceMachine;
    public AudioClip machineSFX;


    void Update()
    {
        if (Input.touchCount > 0)
        { 
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                GameObject potatoInstance = Instantiate(potatoPrefab, potatoSpawnPos.position, Quaternion.identity);
                AddForce(potatoInstance, -1f);

                Destroy(potatoInstance, 1f);

                audioSourceMachine.PlayOneShot(machineSFX);

                //After 3 sec gold will be instantiated
                StartCoroutine(SpawnGold(goldSpawnPos.position));
            }
        }
    }

    IEnumerator SpawnGold(Vector3 posToSpawn)
    {
        yield return new WaitForSeconds(4f);
        GameObject goldInstance = Instantiate(goldPrefab, posToSpawn, Quaternion.identity);
        AddForce(goldInstance, 1.5f);

        Destroy(goldInstance, 50f);
    }

    private static void AddForce(GameObject goldInstance, float force)
    {
        Rigidbody goldRigidbody = goldInstance.GetComponent<Rigidbody>();

        if (goldRigidbody != null)
        {
            float forceMagnitude = force; 
            goldRigidbody.AddForce(Vector3.forward * forceMagnitude, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Gold prefab does not have a Rigidbody component!");
        }
    }
}
