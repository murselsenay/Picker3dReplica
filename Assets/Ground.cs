using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 targetPosition;
    float t;
    float timeToReachTarget = 1f;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            if (transform.position == targetPosition)
            {
                Picker.instance.Go();
            }
        }

    }

  

    public void AnimateGround(Vector3 _targetPosition)
    {
        t = 0;
        targetPosition = _targetPosition;
        canMove = true;
    }


    public void DestroyItself()
    {
        Destroy(gameObject, 1f);
    }
}
