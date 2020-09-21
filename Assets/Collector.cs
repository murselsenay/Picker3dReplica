using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform targetPosition;
    public Text collectorText;
    public GameObject[] barriers;

    int sphereCount = 0;
    int targetCount = 10;
    bool checkSphereCount = true;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCollectorText(0);
        // Invoke("SpawnGround", 1f);

    }

    // Update is called once per frame
    void Update()
    {

        if (sphereCount >= targetCount && checkSphereCount)
        {
            Invoke("SpawnGround", 2f);
            checkSphereCount = false;
        }
    }

    public void SpawnGround()
    {
        GameObject instantiatedGround = Instantiate(groundPrefab, new Vector3(transform.position.x, transform.position.y - 5f, transform.position.z), Quaternion.identity);
        instantiatedGround.GetComponent<Ground>().AnimateGround(targetPosition.position);
        foreach (var barrier in barriers)
        {
            barrier.GetComponent<Barrier>().canMove = true;
        }
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sphere")
        {

            other.gameObject.tag = "Untagged";
            sphereCount++;
            UpdateCollectorText(sphereCount);
            Destroy(other.gameObject, 1f);
        }
    }


    void UpdateCollectorText(int collectedSphereCount)
    {
        collectorText.text = collectedSphereCount + "/" + targetCount.ToString();

    }
}
