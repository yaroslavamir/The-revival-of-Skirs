using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class CookingPot : MonoBehaviour
{
    public Image fireImage;

    private List<string> currentIngredients = new List<string>();
    private const int maxIngredients = 5;
    private Dictionary<string, List<string>> recipes;
    private Text dishText;

    private void Awake()
    {
        dishText = GameObject.Find("DishText").GetComponent<Text>();
    }
    void Start()
    {
        recipes = GameObject.Find("GameManager").GetComponent<AllLists>().recipes; // Отримуємо список інгредієнтів
        dishText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient"))
        {
            // Debug.Log("Інгредієнт торкнувся казана: " + collision.gameObject.name);

            if (currentIngredients.Count < maxIngredients)
            {
                currentIngredients.Add(collision.gameObject.name);
                // Debug.Log("Додано: " + collision.gameObject.name);
                GameObject temp = Instantiate(collision.gameObject, new Vector3(8, -3, 0), Quaternion.identity);
                Destroy(collision.gameObject);
                temp.name = collision.gameObject.name;
            }
            else 
            {
                // Debug.Log("Казан переповнений! Не можна додати більше інгредієнтів.");
                dishText.gameObject.SetActive(true);
                ActivateText();
                dishText.color = Color.red;
                dishText.text = "Казан переповнений! Не можна додати більше інгредієнтів.";
                currentIngredients.Clear(); // Очищаємо список інгредієнтів, якщо казан переповнений
            }
        }
    }
     public void ActivateText()
    {
        dishText.gameObject.SetActive(true);
        StartCoroutine(DeactivateTextAfterTime(3f));
    }

    private IEnumerator DeactivateTextAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        dishText.gameObject.SetActive(false);
    }
    public void StartCooking()
    {
        if (PlayerPrefs.GetInt("Coins") >= 10)
        {
            GameObject.Find("GameManager").GetComponent<CoinCounter>().SpendCoins(10); // Витрачаємо 10 монет
            if (currentIngredients.Count == 0)
            {
                ActivateText();
                dishText.color = Color.red;
                dishText.text = "Вам потрібно додати інгредієнти!";
                return;
            }
            else
            {
                // Сортуємо поточні інгредієнти
                currentIngredients.Sort();

                Debug.Log("Склад: " + string.Join(", ", currentIngredients));

                bool recipeFound = false;

                foreach (var recipe in recipes)
                {
                    // Копіюємо список інгредієнтів із рецепта та сортуємо
                    List<string> sortedRecipeIngredients = new List<string>(recipe.Value);
                    sortedRecipeIngredients.Sort();

                    // Порівнюємо списки
                    if (currentIngredients.SequenceEqual(sortedRecipeIngredients))
                    {
                        ActivateText();
                        dishText.color = Color.green;
                        dishText.text = $"ОК! Ви приготували: {recipe.Key}";
                        recipeFound = true;
                        fireImage.gameObject.SetActive(true);
                        break;
                    }
                }

                if (!recipeFound)
                {
                    ActivateText();
                    dishText.color = Color.red;
                    dishText.text = "Не вгадали! Спробуйте інші інгредієнти.";
                }

                // Очищаємо список для наступного приготування
                currentIngredients.Clear();
            }
        }
        else
        {
            ActivateText();
            dishText.color = Color.red;
            dishText.text = "Недостатньо монет!";
        }
    }
}