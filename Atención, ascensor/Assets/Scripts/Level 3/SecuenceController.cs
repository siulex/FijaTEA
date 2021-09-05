using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SecuenceController : MonoBehaviour
{
    [SerializeField] private GameObject[] options;
    [SerializeField] private GameObject header;
    [SerializeField] private GameObject secuence;

    public int correctOption = 1;
    public string nextScene = "Menu";

    private bool selected = false;
    private float startTime; //Saves time in seconds with milisecond decimals

    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.FindGameObjectsWithTag("Option");
        
        StartCoroutine( StartAnimation());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (correctOption)
            {
                case 1:
                    Option1();
                    break;
                case 2:
                    Option2();
                    break;
                case 3:
                    Option3();
                    break;
                default:
                    Debug.Log("Error, mising correct button");
                    break;
            }

        }

    }



    public void Option1()
    {
        if (!selected) {
            selected = true;
            if (correctOption == 1) //checks if selected option is correct
            {
                options[0].GetComponent<Image>().color = new Color32(184, 213, 195, 255); //Pale green
                StartCoroutine(EndScene(1f, true));
            }
            else
            {
                options[0].GetComponent<Image>().color = new Color32(238, 194, 163, 255); //Pale orange
                StartCoroutine(EndScene(2f, false));
            }
        }

    }

    public void Option2()
    {
        if (!selected)
        {
            selected = true;
            if (correctOption == 2) //checks if selected option is correct
            {
                options[1].GetComponent<Image>().color = new Color32(184, 213, 195, 255); //Pale green
                StartCoroutine(EndScene(1f, true));
            }
            else
            {
                options[1].GetComponent<Image>().color = new Color32(238, 194, 163, 255); //Pale orange
                StartCoroutine(EndScene(2f, false));
            }
        }
    }
    public void Option3()
    {
        if (!selected)
        {
            selected = true;
            if (correctOption == 3) //checks if selected option is correct
            {
                options[2].GetComponent<Image>().color = new Color32(184, 213, 195, 255); //Pale green
                StartCoroutine(EndScene(1f, true));
            }
            else
            {
                options[2].GetComponent<Image>().color = new Color32(238, 194, 163, 255); //Pale orange
                StartCoroutine(EndScene(2f, false));
            }
        }
    }

    IEnumerator StartAnimation()
    {
        Image image = secuence.GetComponent<Image>();
        Color c = image.color;
        c.a = 0;
        image.color = c;

        /*foreach (GameObject option in options)
        {
            option.SetActive(false);
        }*/

        yield return new WaitForSeconds(2f);



        LeanTween.scale(header, new Vector3(1f, 1f, 1f), 1f);
        LeanTween.scale(header.transform.Find("Animation element").gameObject, new Vector3(6.5f, 1f, 1f), 1f);
        yield return new WaitForSeconds(1.5f);


        LeanTween.scale(header, new Vector3(1f,1f,1f), 1f);


        LeanTween.value(gameObject, 0, 1, 1).setOnUpdate((float value) =>
        {
            
            c = image.color;
            c.a = value;
            image.color = c;
        });


        startTime = Time.time;
    }

    private void FinnishTime()
    {
        float finalTime = Time.time - startTime;
        
    }

    IEnumerator EndScene(float waitTime, bool success )
    {
        FinnishTime();

  

        if (!success)
        {
            options[correctOption - 1].GetComponent<Image>().color = new Color32(184, 213, 195, 255); //Pale green
            nextScene = "Menu";
        }else
        {
            PlayerPrefs.SetInt("Current floor", 4);
        }

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextScene);
    }


}
