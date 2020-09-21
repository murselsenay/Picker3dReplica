using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    internal bool canMove = false;
    public bool left = false;
    public bool right = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove)
        {
            if (right)
            {
                if (transform.eulerAngles.x < 355)
                {
                    transform.Rotate(Vector3.up * (100f * Time.deltaTime));
                }
            }
            else if (left)
            {
                if (transform.eulerAngles.x > 5)
                {
                    transform.Rotate(Vector3.down * (100f * Time.deltaTime));
                }
            }

        }
    }
}
