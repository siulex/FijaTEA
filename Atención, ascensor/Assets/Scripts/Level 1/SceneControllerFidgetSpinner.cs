using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerFidgetSpinner : MonoBehaviour
{
    [SerializeField] private GameObject[] fidgetSpinners;

    [SerializeField] private GameObject feedbackSuccess;
    [SerializeField] private ParticleSystem particles;
    public float secondsBetween = 2f;

    public string nextScene = "";
    // Start is called before the first frame update
    void Start()
    {
        feedbackSuccess.SetActive(false);
        fidgetSpinners = GameObject.FindGameObjectsWithTag("Fidget spinner");
 
        HideElements();
        DisplayElements();
        StartCoroutine(NextScene());
    }


    private void HideElements()
    {
        foreach (GameObject spinner in fidgetSpinners)
        {
            spinner.SetActive(false);
        }
    }

    private void DisplayElements()
    {

        float i = 0f;
        foreach (GameObject spinner in fidgetSpinners)
        {
            StartCoroutine(Activate(i ,spinner));
            i += secondsBetween;
        }
    }

    IEnumerator Activate (float time, GameObject elemento)
    {
        yield return new WaitForSeconds(time);
        elemento.SetActive(true);
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(12f);

        feedbackSuccess.SetActive(true);
        LeanTween.scale(feedbackSuccess, new Vector3(3.5f, 3.5f, 1f), 1.5f).setEaseOutBounce(); 

        particles.Play();

        PlayerPrefs.SetInt("Current floor", 2);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextScene);
    }


}
