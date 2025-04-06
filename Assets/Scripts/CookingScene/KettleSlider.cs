using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KettleSlider : MonoBehaviour
{
    public Slider slider;
    public Button kettleButton; 
    public float timeToBoil = 60f;
    public float timeOffKettle = 10f;
    public Image kettleSprite;
    public Color normalColor = Color.white;
    public Color boiledColor = Color.red;

    private bool waterBoiled = false;
    private bool isCoolingDown = false;
    private bool isBoiling = false;
    private bool userInteracted = false;

    private void Start()
    {
        slider.value = 0;
        
    }

    public void OnKettleClick()
    {
        // Debug.Log("Кнопка натиснута!");

        if (isCoolingDown)
        {
            userInteracted = true;
            // Debug.Log("win");
            GameObject.Find("GameManager").GetComponent<MiniGameUI>().KettleSlider.SetActive(false);
            ResetKettle();
            return;
        }

        if (!isBoiling)
        {
            // Debug.Log("Запускається BoilWater()");
            isBoiling = true;
            StartCoroutine(BoilWater());
            GameObject.Find("GameManager").GetComponent<CoinCounter>().SpendCoins(1);
        }
    }

    private IEnumerator BoilWater()
    {
        float elapsedTime = 0f;
        while (elapsedTime < timeToBoil)
        {
            slider.value = Mathf.Lerp(0, 1, elapsedTime / timeToBoil);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = 1;
        waterBoiled = true;
        kettleSprite.color = boiledColor;
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(timeOffKettle);

        if (!userInteracted)
        {
            Debug.Log("lose");
            GameObject.Find("GameManager").GetComponent<MiniGameUI>().KettleSlider.SetActive(false);
        }

        ResetKettle();
    }

    private void ResetKettle()
    {
        isBoiling = false;
        waterBoiled = false;
        isCoolingDown = false;
        userInteracted = false;
        slider.value = 0;
        kettleSprite.color = normalColor;
    }
}
