using UnityEngine;
using System.Collections.Generic;

public class CardsGame : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardParent;
    public Vector2 spawnAreaMin = new Vector2(-5f, -3f); // Мінімальні координати спавну
    public Vector2 spawnAreaMax = new Vector2(5f, 3f);    // Максимальні координати спавну

    private List<Card> cards = new List<Card>();
    private Card firstSelected;
    private Card secondSelected;
    public GameObject escBtn;
    public int countCard = 0;

    void Start()
    {
        SetupCards();
    }

    void SetupCards()
    {
        List<string> values = new List<string>();

        values.Add("Y");
        values.Add("Y");
        for (int i = 0; i < 12; i++) values.Add("X");

        values.Sort((a, b) => Random.Range(-1, 2));

        foreach (string value in values)
        {
            GameObject newCard = Instantiate(cardPrefab, cardParent);
            Card cardComponent = newCard.GetComponent<Card>();

            // Якщо карта з текстом "Y", то спавн випадковий
            if (value == "Y")
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    0f
                );
                newCard.transform.localPosition = randomPosition;
            }
            else
            {
                // Встановлюємо позицію в контейнері (по замовчуванню)
                newCard.transform.localPosition = Vector3.zero;
            }

            cardComponent.Setup(value, this);
            cards.Add(cardComponent);
        }
    }

    public void CardSelected(Card card)
    {
        if (firstSelected == null)
        {
            firstSelected = card;
        }
        else if (secondSelected == null)
        {
            secondSelected = card;
            StartCoroutine(CheckMatch());
        }
    }

    private System.Collections.IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstSelected.GetValue() == "Y" && secondSelected.GetValue() == "Y")
        {
            Debug.Log("Nice!");
            escBtn.SetActive(true);
            firstSelected.HideCard();
            secondSelected.HideCard();
        }
        else
        {
            firstSelected.HideCard();
            secondSelected.HideCard();
            countCard = 0;
        }

        firstSelected = null;
        secondSelected = null;
    }
}
