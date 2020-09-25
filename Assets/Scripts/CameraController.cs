using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 targetPosition;
    Vector3 targetBackPosition;
    public GameObject picker;


    float t;
    float timeToReachTarget = 10f;
    internal bool canChangePosition = false;
    internal bool canChangePositionBack = false;

    public bool startMove = false;
    float targetYPos;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        targetBackPosition.y = 0.6f;
        targetYPos = startPosition.y - 2f;
    }

    // Update is called once per frame
    void Update()
    {

      
    }
    void LateUpdate()
    {
        ChangeCameraPosition();
        ChangeCameraPositionBack();
    }

    public IEnumerator MoveCamera()
    {
        t = 0;
        canChangePosition = true;
        canChangePositionBack = false;
        yield return new WaitForSeconds(1f);
        t = 0;
        canChangePosition = false;
        canChangePositionBack = true;
    }


    public void ChangeCameraPosition()
    {
        if (canChangePosition)
        {
            startPosition = transform.position;
            targetPosition = new Vector3(transform.position.x, targetYPos, transform.position.z);
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, picker.transform.position.z - 7f);
    }

    public void ChangeCameraPositionBack()
    {

        if (canChangePositionBack)
        {
            startPosition = transform.position;
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, targetBackPosition, t);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, picker.transform.position.z - 7f);
    }
}
