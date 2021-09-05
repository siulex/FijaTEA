using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Level4Controller : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private SelectableElement originalFruit;
    [SerializeField] private GameObject header;
    [SerializeField] private TextMeshProUGUI scoreBoard;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject endScreen;

    public string nextScene = "Menu";

    private int targetFruit = 0;
    public int allowedMistakes = 3;
    private int mistakes = 0;
    private int score = 0;
    private bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        //Updating Scoreboard and mistakes
        score = PlayerPrefs.GetInt("Score");
        UpdateScore(score);

        mistakes = PlayerPrefs.GetInt("Mistakes");
        UpdateMistakes(mistakes);

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
        Vector3 startPos = originalFruit.transform.position;

        
        for (int i = 0; i < 3; i++)
        {
            numbers = ShuffleArray(numbers);

            for (int j =0; j< images.Length; j++)
            {
                SelectableElement obj;
                if (j == 0 && i == 0)
                {
                    obj = originalFruit;
                }
                else
                {
                    obj = Instantiate(originalFruit) as SelectableElement; //Original element clonation

                    obj.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
                }

                int id = numbers[j];
                obj.ChangeSprite(id, images[id]);

                float posX = (startPos.x * j * PositionMultiplicator(images.Length)) + startPos.x;
                float posY = (startPos.y * i * 1.1f) + startPos.y;

                obj.transform.position = new Vector3(posX, posY, startPos.z);

            }
        }


        //Starting header animation
        StartCoroutine(HeaderAnimationIn());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ElementPress(targetFruit);
            ElementPress(targetFruit);
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
            
            UpdateScore(score +1);

            if ((score % 3) == 0) {

                int iteration = PlayerPrefs.GetInt("Iteration") + 1;
                PlayerPrefs.SetInt("Iteration", iteration);

                StartCoroutine(HeaderAnimationOut());
            }
        }
        else{
            UpdateMistakes(mistakes + 1);

            if (mistakes >= allowedMistakes)
            {
                if (mistakes > 100)
                {
                   StartCoroutine(EndScreen("Se ha acabado el tiempo"));
                }
                else
                {
                    StartCoroutine(EndScreen("Demasiados errores"));
                }
               

            }
        }
    }

    IEnumerator HeaderAnimationIn()
    {
        int iteration = PlayerPrefs.GetInt("Iteration") + 1;

        yield return new WaitForSeconds(0.75f + (0.75f/iteration));
        header.transform.Find("HeaderMargin").gameObject.SetActive(false); //Turn off the margin
        LeanTween.scale(header, new Vector3(1f, 1f, 1f), 0.75f + (0.75f / iteration)).setEaseLinear();

        yield return new WaitForSeconds(0.75f + (0.75f / iteration));//After animation  timer is started
        StartTimer();
    }

    IEnumerator HeaderAnimationOut()
    {
        finish = true;
        int iteration = PlayerPrefs.GetInt("Iteration") + 1;
        yield return new WaitForSeconds(0.2f);

        GameObject background = header.transform.Find("HeaderMargin").gameObject;
        background.SetActive(true);//Turn on the margin

        LeanTween.scale(background, new Vector3(2.36f, 2.7f, 1f), 0.001f);
        LeanTween.scale(header, new Vector3(2.36f, 2.7f, 1f), 0.75f + (0.75f / iteration) ).setEaseLinear();

        yield return new WaitForSeconds(1f + (1f / iteration));
        SceneManager.LoadScene("FruitFind");
    }


    private void UpdateMistakes(int mistakesTotal)
    {
        mistakes = mistakesTotal;
        PlayerPrefs.SetInt("Mistakes", mistakes);
  
    }

    private void UpdateScore(int newScore)
    {
        score = newScore;
        PlayerPrefs.SetInt("Score", score);
        scoreBoard.text = score.ToString();
    }

    public void StartTimer()
    {
        int iteration = PlayerPrefs.GetInt("Iteration") + 1;

        timer.StartCountdown( CalculateTime(iteration));
    }

    private float CalculateTime(int iteration)
    {
        if (iteration < 3)
        {
            return (60f/iteration);
        }else if (iteration < 6)
        {
            return 15f / (iteration- 2);
        }

        return 10f / (iteration -3); 
    }

    public void TimeOut()
    {
        if (!finish)
        {
            Debug.Log("Time Out");
            UpdateMistakes(999);
            ElementPress(-1);
        }

    }

    IEnumerator EndScreen(string cause)
    {
        endScreen.SetActive(true);
        endScreen.transform.Find("FailureExplanation").gameObject.GetComponent<TextMeshProUGUI>().text = cause;
        endScreen.transform.Find("FinalScore").gameObject.transform.Find("Score").gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();

        PlayerPrefs.SetInt("Mistakes", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Iteration", 0);

        PlayerPrefs.SetInt("Current floor", 5);
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(nextScene);
    }


}
