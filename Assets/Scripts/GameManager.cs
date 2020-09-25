using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject checkPoint;
    public GameObject finish;
    public Transform targetPosition;
    public int checkPointCount = 3;
    Vector3 tempPos;
    public GameObject tryAgainMenu;


    void Awake()
    {
        Time.timeScale = 1;
      
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CreatePlatforms();

    }


    public void CreatePlatforms()
    {
        
            LevelManager.instance.CreateLevel();

        for (int i = 0; i < checkPointCount; i++)
        {
            tempPos = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z + checkPoint.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z * 5 * i);
            Instantiate(checkPoint, tempPos, Quaternion.identity);
        }
        Instantiate(finish, new Vector3(targetPosition.position.x, targetPosition.position.y, tempPos.z + (checkPoint.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z) * 5), Quaternion.identity);

        targetPosition.position = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z + checkPoint.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z * (5 * checkPointCount + 3));

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTryAgainMenu()
    {
        GameObject insTryAgainMenu=Instantiate(tryAgainMenu, new Vector3(0f,0f,0f),Quaternion.identity );

        insTryAgainMenu.transform.SetParent(GameObject.FindGameObjectWithTag("CameraCanvas").transform);
        insTryAgainMenu.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);


    }

}
