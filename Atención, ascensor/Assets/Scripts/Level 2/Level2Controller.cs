using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private MovingItem originalElement;
    [SerializeField] private GameObject header;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject feedbackSuccess;
    [SerializeField] private ParticleSystem particles;

    private int targetFruit = 0;
    public int allowedMistakes = 3;
    private int mistakes = 0;

    public string nextScene = " ";

    // Start is called before the first frame update
    void Start()
    {
        feedbackSuccess.SetActive(false);


        //Random target
        targetFruit = Random.Range(0, images.Length);
        GameObject target = GameObject.FindGameObjectWithTag("Target");
        target.GetComponent<Image>().sprite = images[targetFruit];

        //Random order of elements
        int[] numbers = new int[images.Length];

        for (int i = 0; i < images.Length; i++)
        {
            numbers[i] = i;
        }

        numbers = ShuffleArray(numbers);

        //Setting the images in the elements and placing on scene
        Vector3 startPos = originalElement.transform.position;

        for (int i = 0; i < images.Length; i++)
        {
            MovingItem obj;
            if (i == 0)
            {
                obj = originalElement;
            }
            else
            {
                obj = Instantiate(originalElement) as MovingItem; //Original element clonation

                obj.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
            }

            int id = numbers[i];
            obj.ChangeSprite(id, images[id]);

            float posX = (startPos.x * i * PositionMultiplicator(images.Length)) + startPos.x;

            obj.transform.position = new Vector3(posX, startPos.y, startPos.z);

        }

        //Starting header animation
        StartCoroutine(HeaderAnimation());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ElementPress(targetFruit);

        }
    }

    //Obtains the position multiplicator relative to the first fixed element
    private float PositionMultiplicator(int numElements)
    {
        switch (numElements)
        {
            case 2:
                return 8.6f / numElements;
            case 3:
                return 6.5f / numElements;
            case 4:
                return 5.85f / numElements;
            case 5: 
                return 5.5f / numElements;
            case 6:
                return 5.15f / numElements;
            case 7:
                return 5f / numElements;
            default:
                return 4.5f / numElements;
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public void ElementPress (int id){
        if (id == targetFruit)
        {
            PlayerPrefs.SetInt("Current floor", 3);
            StartCoroutine(SuccessAnimation());
        }
        else{
            mistakes++;
            if (mistakes >= allowedMistakes)
            {
              
                SceneManager.LoadScene("Menu");
            }
        }
    }

    IEnumerator HeaderAnimation()
    {

        yield return new WaitForSeconds(2f);
        header.transform.Find("HeaderMargin").gameObject.SetActive(false); //Turn off the margin
        LeanTween.scale(header, new Vector3(1f, 1f, 1f), 1.5f).setEaseLinear();
    }

    IEnumerator SuccessAnimation()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false); //Fruits deactivation
        background.SetActive(false);
        header.SetActive(false);

        //Activating image and particles
        feedbackSuccess.SetActive(true);
        LeanTween.scale(feedbackSuccess, new Vector3(3.4f, 3.4f, 1f), 1.5f).setEaseOutBounce(); ;
        particles.Play();
        
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(nextScene);

    }


}
