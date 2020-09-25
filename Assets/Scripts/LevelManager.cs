using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject[] objects;
    public Transform targetPosition;

    Vector3 startPosition;
    float[] posX = { 0, 0, 0 };
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

     

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateLevel()
    {
        startPosition = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z - 6f);
        posX[0] = startPosition.x - 1f;
        posX[1] = startPosition.x;
        posX[2] = startPosition.x + 1f;
        float offsetZ = 0.5f;
        for (int k = 0; k < GameManager.instance.checkPointCount; k++)
        {
            for (int i = 0; i < 5; i++)
            {
                int rnd = Random.Range(0, 3);
                GameObject spawnObject = objects[Random.Range(0, 2)];
                for (int j = 0; j < 5; j++)
                {

                    Instantiate(spawnObject, new Vector3(posX[rnd], startPosition.y, startPosition.z + offsetZ), Quaternion.identity);
                    offsetZ += 0.5f;
                }

            }
            
            offsetZ += 12f;
        }


    }
}
