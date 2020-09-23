using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 targetPosition;

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
        targetYPos = startPosition.y - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCameraPosition();
        ChangeCameraPositionBack();
    }

    public IEnumerator MoveCamera()
    {
        t = 0;
        canChangePosition = true;
        canChangePositionBack = false;
        yield return new WaitForSeconds(2f);
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

    }

    public void ChangeCameraPositionBack()
    {

        if (canChangePositionBack)
        {
            startPosition = transform.position;
            targetPosition = new Vector3(transform.position.x, targetYPos + 2f, transform.position.z);
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }
    }
}
