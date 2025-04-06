using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderGame : MonoBehaviour
{
    public RectTransform blackLine;
    public RectTransform greenZone;
    public Text scoreText;
    public float speed = 3, defaultSpeed;
    public bool CanInteract = true;
    private float direction = 1f;
    [SerializeField] public int score = 0;
    [SerializeField] public GameObject PanelActivity;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private Sprite[] graphic;
    [SerializeField] private int[] widthGraphic;
    private float sliderWidth;
    [SerializeField] private int countGraphic = 0;
    public bool canSlise, slisedObj;

    void Start()
    {
        defaultSpeed = speed;
        sliderWidth = GetComponent<RectTransform>().rect.width;
        canSlise = false;
        slisedObj = false;
    }

    public void StartSlider()
    {
        if (canSlise)
        {
            score = 0;
            // Debug.Log("StartSlider: гра запущена, score = " + score);
            greenZone.GetComponent<Image>().sprite = graphic[countGraphic];
            UpdateGreenZone();
            gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (score >= 0)
        {
            MoveBlackLine();
            if (Input.GetKeyDown(KeyCode.Space))
                CheckHit();
        }
        else
        {
            scoreText.text = "Game Over";
            canSlise = false;
        }
    }

    void MoveBlackLine()
    {
        blackLine.anchoredPosition += new Vector2(direction * speed, 0);
        if (blackLine.anchoredPosition.x >= sliderWidth / 2 || blackLine.anchoredPosition.x <= -sliderWidth / 2)
            direction *= -1;
    }

    void CheckHit()
    {
        // Debug.Log("CheckHit: score перед перевіркою = " + score);

        if (score < 0)
        {
            // Debug.Log("CheckHit: score < 0, гра завершується");
            return;
        }

        float blackX = blackLine.anchoredPosition.x;
        float greenX = greenZone.anchoredPosition.x;
        float greenWidth = greenZone.rect.width;

        if (blackX >= greenX - greenWidth / 2 && blackX <= greenX + greenWidth / 2)
        {
            score++;
            speed += 0.5f;
            countGraphic++;
            // Debug.Log("CheckHit: успішний удар, новий score = " + score);
        }
        else
        {
            score--;
            speed -= 0.5f;
            // Debug.Log("CheckHit: промах, новий score = " + score);
        }

        if (score < 0)
        {
            // Debug.Log("CheckHit: score < 0 після промаху, гра завершується");
            scoreText.text = "Game Over";
            CanInteract = false;
            slisedObj = false;
            StartCoroutine(CloseAfterDelay(2f));
            return;
        }

        if (score >= 2)
        {
            // Debug.Log("CheckHit: score >= 2, перемога!");
            scoreText.text = "NICE COOK!";
            CanInteract = false;
            slisedObj = true;
 
            StartCoroutine(CloseAfterDelay(2f));
            return;
        }

        // Debug.Log("CheckHit: продовжуємо гру, score = " + score);
        scoreText.text = "CUTS: " + score;
        UpdateGreenZone();
    }


    void UpdateGreenZone()
    {
        float newPos = Random.Range(-sliderWidth / 4, sliderWidth / 4);
        greenZone.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthGraphic[countGraphic]);
        greenZone.GetComponent<Image>().sprite = graphic[countGraphic];
        greenZone.anchoredPosition = new Vector2(newPos, greenZone.anchoredPosition.y);
    }

    private IEnumerator CloseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReloadGame();
    }

   public void ReloadGame()
    {
        // Debug.Log("ReloadGame: гра скидається");
        score = 0;
        gameObject.SetActive(false);
        PanelActivity.GetComponent<MiniGameUI>().PanelActive = false;
        CanInteract = true;
        canSlise = false; 
        speed = defaultSpeed;
        scoreText.text = "CUTS: 0";
        blackLine.anchoredPosition = new Vector2(0, blackLine.anchoredPosition.y);
        sliderWidth = GetComponent<RectTransform>().rect.width;
        countGraphic = 0;
        greenZone.GetComponent<Image>().sprite = graphic[countGraphic];
        UpdateGreenZone();
        // Debug.Log("ReloadGame: значення скинуті, score = " + score);
    }



}