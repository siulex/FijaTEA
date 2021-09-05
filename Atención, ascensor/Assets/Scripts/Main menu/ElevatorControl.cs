using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ElevatorControl : MonoBehaviour
{
    private int scene;
    [SerializeField] private TextMeshProUGUI currentFloorText;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject[] numberButtons;

    public string endText = "Fin";

    void Start()
    {

        scene = PlayerPrefs.GetInt("Current floor");
        UpdateFloor(scene);

        ColourButtons();

    }

    private string GetSceneName(int scene)
    {
        switch (scene){
            case 1:
                return "Spinner";
               
            case 2:
                return "FollowItem";
              
            case 3:
                return "Secuence 1";
              
            case 4:
                return "FruitFind";

            default:
                return "Error";
            
        }
    }

    public void UpdateFloor(int floor)
    {

        scene = floor;
        string floorText = scene.ToString();

        if (scene >4)
        {
            floorText = endText;

        }

        PlayerPrefs.SetInt("Current floor", floor);
        currentFloorText.text = floorText;
    }


    public void NextScene()
    {
            if (scene <= 4)
            {
                UpdateFloor(scene + 1);
            }

            StartCoroutine(Transition(GetSceneName(scene), 1.5f));
            OpenDoors();
    }


    public void GoToScene(int sceneNumber)
    {
        UpdateFloor(sceneNumber);
        StartCoroutine(Transition(GetSceneName(sceneNumber),1.5f));
        OpenDoors();

    }

    IEnumerator Transition(string targetScene, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(targetScene);
    }

    private void OpenDoors()
    {

        //Doors opening

        LeanTween.value(leftDoor, 1f,0.1f ,1f).setOnUpdate( (value) =>
        {
           Image image = leftDoor.GetComponent<Image>();

            image.fillAmount = value;
        });


        LeanTween.value(rightDoor, 1f, 0.1f, 1f).setOnUpdate((value) =>
        {
            Image image = rightDoor.GetComponent<Image>();

            image.fillAmount = value;
        });

    }
    
    private void ColourButtons()
    {
        int i = 0;
        foreach (GameObject button in numberButtons)
        {

            if (i< scene)
              button.GetComponent<Image>().color = new Color32(184, 213, 195, 255); ;
            i++;
        }
    }

}
