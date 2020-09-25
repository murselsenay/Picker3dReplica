using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    public static SwipeDetector instance;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    public Text text;
    public float SWIPE_THRESHOLD = 20f;
    internal bool canSwipe = false;

    // Update is called once per frame
    void Update()
    {
        instance = this;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSwipeDown();
        }
       
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
               
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
               
                fingerDown = touch.position;
                checkSwipe();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSwipeDown();
        }

    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void OnSwipeUp()
    {

    }

    void OnSwipeDown()
    {
      
          
    }

    void OnSwipeLeft()
    {
        Picker.instance.offsetX = -0.2f;
    }

    void OnSwipeRight()
    {
        Picker.instance.offsetX = +0.2f;
    }


}
