using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI text;
    private string value;
    private bool isFlipped = false;
    private CardsGame cardsGame;

    public void Setup(string cardValue, CardsGame cards)
    {
        value = cardValue;
        cardsGame = cards;
        text.text = "?";

        // Перевірка на наявність кнопки та підписка на клік
        if (button == null)
        {
            button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Компонент Button не знайдено на карті!");
                return;
            }
        }

        button.onClick.RemoveAllListeners(); // Очищаємо попередні
        button.onClick.AddListener(OnCardClick); // Додаємо новий
    }

    public void OnCardClick()
    {
        if (isFlipped) return;
        if (cardsGame.countCard < 2)
        {
            isFlipped = true;
            text.text = value;
            cardsGame.CardSelected(this);
            cardsGame.countCard++;
        }

    }

    public void HideCard()
    {
        isFlipped = false;
        text.text = "?";
    }

    public string GetValue() => value;
}
