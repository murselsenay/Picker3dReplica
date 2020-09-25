using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    public Canvas progressCanvas;
    GameObject progressBar;

    int lightStep = 0;
    int level = 0;
    Text currentText;
    Text nextText;
    Image currentImage;
    Image nextImage;
    GameObject[] lights;


    void Awake()
    {
        level = PlayerPrefs.GetInt("level", level);
    }

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        progressBar = progressCanvas.transform.GetChild(0).gameObject;
        lights = GameObject.FindGameObjectsWithTag("ProgressBarLight");

        currentImage = progressBar.transform.GetChild(3).GetComponent<Image>();
        nextImage = progressBar.transform.GetChild(4).GetComponent<Image>();

        currentText = progressBar.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        nextText = progressBar.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();

        currentImage.color = Color.yellow;
        nextImage.color = Color.yellow;

        foreach (var light in lights)
        {
            light.GetComponent<Image>().color = Color.white;
        }

        currentText.text = level.ToString();
        nextText.text = (level + 1).ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateLevel()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Image>().color = Color.white;
        }
        level++;
        currentText.text = level.ToString();
        nextText.text = (level + 1).ToString();
        


    }

    public void checkPointPass()
    {
        if (lightStep > 2)
        {
            lightStep = 0;
        }
        else
        {
            lights[lightStep].GetComponent<Image>().color = Color.yellow;
            lightStep++;
        }


    }


    private void OnApplicationQuit()
    {

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
    }
}
