using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{

    public static Collector instance;
    public GameObject groundPrefab;
    public Transform targetPosition;
    public Text collectorText;
    public GameObject[] barriers;
    public bool isGameOver = false;


    int sphereCount = 0;
    int targetCount = 10;
    bool checkSphereCount = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateCollectorText(0);
        // Invoke("SpawnGround", 1f);

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void CheckIfIsGameOver()
    {

        if (sphereCount >= targetCount && checkSphereCount)
        {
            Invoke("SpawnGround", 2f);
            CanvasController.instance.checkPointPass();
            checkSphereCount = false;
        }
        else if (sphereCount < targetCount && checkSphereCount)
        {
            GameManager.instance.SpawnTryAgainMenu();
            Time.timeScale = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Picker")
        {
            Invoke("CheckIfIsGameOver", 1.5f);
        }
    }
    void UpdateCollectorText(int collectedSphereCount)
    {
        collectorText.text = collectedSphereCount + "/" + targetCount.ToString();

    }
}
