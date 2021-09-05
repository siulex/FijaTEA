using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlBarraCarga : MonoBehaviour
{
    public Slider slider;
    private float value = 0f;

   private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        value += 0.01f;
        slider.value += value;

        if (value >= 1f)
        {
            SceneManager.LoadScene("Cara1");

        }
    }
}
