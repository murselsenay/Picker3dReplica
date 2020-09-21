using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject checkPoint;
    public GameObject finish;
    public Transform targetPosition;
    public int checkPointCount = 3;
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(checkPoint.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size);
        for (int i = 0; i < checkPointCount; i++)
        {
            tempPos = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z + checkPoint.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z * 5 * i);
            Instantiate(checkPoint, tempPos, Quaternion.identity);
        }
        Instantiate(finish, new Vector3(9.593843f, 0.0893259f, tempPos.z + (checkPoint.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z) * 2.1f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
