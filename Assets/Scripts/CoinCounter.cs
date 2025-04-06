using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coins; // Змінна для зберігання кількості монет
    public Text coinText; // UI Text для відображення кількості монет
    // Start is called before the first frame update
    void Awake()
    {
        coinText = GameObject.Find("CoinText").GetComponent<Text>(); // Отримуємо компонент Text з об'єкта CoinText
        PlayerPrefs.SetInt("Coins", 20); // Завантажуємо кількість монет 
        coins = PlayerPrefs.GetInt("Coins"); 
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = coins.ToString();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        PlayerPrefs.SetInt("Coins", coins); // Зберігаємо значення
        PlayerPrefs.Save();
        UpdateUI();
    }

    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();
            UpdateUI();
        }
        else {
            SceneManager.LoadScene("GameOver");
        }
    }
}
