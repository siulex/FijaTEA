using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raton : MonoBehaviour
{
    public GameObject raton;
    private Vector3 origen;
    private GameObject hijo;
    // Start is called before the first frame update
    void Start()
    {
        origen = raton.transform.position;
        hijo = raton.transform.GetChild(0).gameObject;
        StartCoroutine(DoMoving());

    }

    IEnumerator DoMoving()
    {
        yield return new WaitForSeconds(1.5f);
        LeanTween.moveLocalY(raton, -2.4f, 2f);
        yield return new WaitForSeconds(2.5f);
        
        hijo.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hijo.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        reiniciar();

    }

    private void reiniciar()
    {
        raton.transform.position = origen;

        StartCoroutine(DoMoving());
    }
}
