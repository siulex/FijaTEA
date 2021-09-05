using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Level4Controller controller;
    [SerializeField] private Color32 halfTimeColor;
    [SerializeField] private Color32 warningColor;

    private GameObject parent;

    public void StartCountdown( float totalSeconds)
    {
        parent = gameObject.transform.parent.gameObject;

        Debug.Log("Comienza cuenta atras " + totalSeconds + " seg.");
        StartCoroutine(TimerLogic(totalSeconds));
        //The timer starts to move
        LeanTween.value(parent, 1f, 0f, totalSeconds).setOnUpdate((value) =>
        {
            Image image = parent.GetComponent<Image>();
            image.fillAmount = value;

        });
    }

    IEnumerator TimerLogic(float totalSeconds)
    {
        yield return new WaitForSeconds(totalSeconds / 2);
        parent.GetComponent<Image>().color = halfTimeColor;

       yield return new WaitForSeconds(totalSeconds / 4);
        parent.GetComponent<Image>().color = warningColor;

        yield return new WaitForSeconds(totalSeconds / 4);
        controller.TimeOut();

    }

}
