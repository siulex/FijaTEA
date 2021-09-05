using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingItem : MonoBehaviour
{
    private int _id;
    [SerializeField] Level2Controller controller;
    Vector3 startPos;
    private void Start()
    {
        startPos = gameObject.transform.position;
        //Animate();
    }

    private void Animate()
    {
        LeanTween.moveY(gameObject, startPos.y * 3.2f, Random.Range(0.7f, 2f)).setEaseLinear().setLoopPingPong();
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
    }
}
