using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    public static Picker instance;
    float speed = 3f;
    Rigidbody pickerBody;
    // Start is called before the first frame update
    void Awake()
    {
        pickerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        instance = this;
        var moveOnZ = Time.fixedDeltaTime * speed;
        var move = transform.position + new Vector3(0f, 0f, moveOnZ);

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            move.x += -0.02f;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            move.x += 0.02f;
        }
        pickerBody.MovePosition(move);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stopper")
        {
            Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickerChecker")
        {
            other.gameObject.transform.parent.GetComponent<Ground>().DestroyItself();
        }

    }

    public void Stop()
    {
        speed = 0f;
    }
    public void Go()
    {
        speed = 3f;
    }
}
