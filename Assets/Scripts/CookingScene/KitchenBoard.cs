
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenBoard : MonoBehaviour
{
    private GameObject lastIngredient;
    public bool startSlise = false;
    private Dictionary<string, List<string>> ingredients;
    private Dictionary<string, int> prices;
    private List<string> keysToRemove = new List<string>();
    private SliderGame sliderGame;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        ingredients = gameManager.GetComponent<AllLists>().ingredients; // Отримуємо список інгредієнтів
        prices = gameManager.GetComponent<AllLists>().prices; // Отримуємо список цін

        // Видаляємо всі інгредієнти, які не містять "Slise"
        foreach (KeyValuePair<string, List<string>> entry in ingredients)
        {
            if (!entry.Value.Contains("Slise"))
            {
                keysToRemove.Add(entry.Key);
            }
        }

        foreach (string key in keysToRemove)
        {
            ingredients.Remove(key);
        }

        // foreach (var entry in ingredients)
        // {
        //     Debug.Log($"Інгредієнт: {entry.Key}, Властивості: {string.Join(", ", entry.Value)}");
        // }
    }

    void Awake()
    {
        sliderGame = GameObject.Find("SliderPanelBoard").GetComponent<SliderGame>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string ingredientName = other.gameObject.name;
        bool found = false;

        foreach (var entry in ingredients)
        {
            if (entry.Value.Count > 1 && entry.Value[1] == ingredientName)
            {
                Debug.Log("Знайдено за значенням: " + ingredientName + " у страві: " + entry.Key);
                found = true;

                if (lastIngredient != null)
                {
                    lastIngredient.transform.position = new Vector3(0, -4, 0);
                }

                lastIngredient = other.gameObject;
                sliderGame.canSlise = true;
                gameManager.GetComponent<CoinCounter>().SpendCoins(prices[lastIngredient.name]);
                break;
            }
        }

        if (!found)
        {
            // Debug.Log("Не знайдено: " + ingredientName);
            other.transform.position = new Vector3(0, -4, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (lastIngredient == other.gameObject)
        {
            sliderGame.canSlise = false;
            startSlise = false;
            // lastIngredient = null;
        }
    }

    void Update()
    {
        if (startSlise)
        {
            if (lastIngredient != null)
            {
                lastIngredient.transform.position = new Vector3(20, -1, 0);
            }
        
        }

        if (sliderGame.slisedObj)
        {
            if (lastIngredient != null)
            {
                string ingredientName = lastIngredient.name;
               
                // Debug.Log("Coins: " + gameManager.GetComponent<CoinCounter>().coins);
                // Debug.Log("Спроба знайти відповідний ключ для: " + ingredientName);

                string foundKey = null;
                
                foreach (var entry in ingredients)
                {
                    if (entry.Value.Count > 1 && entry.Value[1] == ingredientName)
                    {
                        foundKey = entry.Key;
                        break;
                    }
                }

                if (foundKey != null)
                {
                    // Debug.Log("Знайдено ключ: " + foundKey);

                    // Завантажуємо префаб за правильним ключем
                    GameObject prefab = Resources.Load<GameObject>(foundKey);
                    
                    if (prefab != null)
                    {
                        // Debug.Log("Створюємо копію об'єкта: " + foundKey);
                        Instantiate(prefab, lastIngredient.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Debug.LogError("Помилка при завантаженні префаба: " + foundKey);
                    }
                }
                else
                {
                    Debug.LogError("Не знайдено відповідного ключа для: " + ingredientName);
                }

                lastIngredient.transform.position = new Vector3(10, -1, 0); // Переміщуємо оригінал
                lastIngredient = null; // Очищаємо змінну
                sliderGame.canSlise = false; // Забороняємо різати
                sliderGame.slisedObj = false; // Скидаємо стан порізаного об'єкта
            }
            else
            {
                Debug.LogError("lastIngredient == null");
            }

        }
    }
}
