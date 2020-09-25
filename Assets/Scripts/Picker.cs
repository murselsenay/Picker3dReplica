using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    public static Picker instance;
    float speed = 3f;
    float _speed = 3f;
    Rigidbody pickerBody;
    public Camera pickerCamera;


    internal float offsetX;
    private Touch touch;
    private float speedModifier;
    bool canCheckFinish = true;
    bool canCheckPointPass = true;

        // Start is called before the first frame update
    void Awake()
    {
        pickerBody = gameObject.GetComponent<Rigidbody>();
        Stop();
        speedModifier = 0.0005f;
    }
    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        instance = this;

        var moveOnZ = Time.fixedDeltaTime * speed;
        var move = transform.position + new Vector3(0f, 0f, moveOnZ);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, move.z);
            }

        }
        

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            move.x += -0.02f;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            move.x += 0.02f;
        }
        pickerBody.MovePosition(move);


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.8f, 1.8f), transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stopper")
        {
            Stop();

            if (canCheckPointPass)
            {
               
                canCheckPointPass = false;
            }
        }

        
        if (other.gameObject.tag == "Tunnel")
        {
            _speed = 3f;
            StartCoroutine(pickerCamera.GetComponent<CameraController>().MoveCamera());
            GameManager.instance.CreatePlatforms();

            other.gameObject.tag = "Untagged";
            Destroy(other.gameObject, 2f);
        }
        if (other.gameObject.tag == "Finish" && canCheckFinish)
        {
            CanvasController.instance.UpdateLevel();

            canCheckFinish = false;
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickerChecker")
        {
            other.gameObject.transform.parent.GetComponent<Ground>().DestroyItself();
        }
        if (other.gameObject.tag == "Finish")
        {
            canCheckFinish = true;
            _speed = 10f;

        }
        if (other.gameObject.tag == "Stopper")
        {
            canCheckPointPass = true;

        }

    }
    private void OnMouseDown()
    {
        Go();
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(GameObject.FindGameObjectWithTag("DragText"));
    }

    public void Stop()
    {
        speed = 0f;
    }
    public void Go()
    {
        speed = _speed;
    }
}
