using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableElement : MonoBehaviour
{
    private int _id;
    [SerializeField] Level4Controller controller;
    Vector3 startPos;

    private void Start()
    {
        startPos = gameObject.transform.position;
        
    }

    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<Image>().sprite = image;
    }

    

    public void OnClick()
    {
        controller.ElementPress(_id);
        gameObject.SetActive(false);
    }
}
