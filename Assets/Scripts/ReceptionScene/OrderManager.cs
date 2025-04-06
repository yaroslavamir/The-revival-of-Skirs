using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrderManager : MonoBehaviour
{
    public DishDatabase dishDatabase; // Підключення бази даних
    public Text orderText; // Відображення назви страви
    public GameObject OrderPanel; // Панель приготування
    public Image buttonImage; // UI Image кнопки
    [SerializeField] private Sprite[] sprites; // Масив спрайтів
    private int selectedIndex;

    private Dish currentOrder;

    void Start()
    {
        // Очищення PlayerPrefs для тестування
        PlayerPrefs.DeleteAll();

        // Перевірка довжини масиву спрайтів
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("❌ Масив спрайтів порожній або не заповнений!");
            return;
        }

        OrderPanel.SetActive(false);

        // Перевіряємо, чи збережений індекс уже існує
        if (!PlayerPrefs.HasKey("SavedIndex"))
        {
            // Ініціалізуємо рандомний генератор
            Random.InitState(System.DateTime.Now.Millisecond);

            // Генеруємо випадковий індекс
            selectedIndex = Random.Range(0, sprites.Length);
            PlayerPrefs.SetInt("SavedIndex", selectedIndex);
            PlayerPrefs.Save();
            Debug.Log("🆕 Перший запуск: згенерований рандомний індекс = " + selectedIndex);
        }
        else
        {
            // Завантажуємо збережений індекс
            selectedIndex = PlayerPrefs.GetInt("SavedIndex");
            Debug.Log("🔁 Збережений індекс: " + selectedIndex);
        }

        // Перевірка на допустимість індексу
        if (selectedIndex >= 0 && selectedIndex < sprites.Length)
        {
            buttonImage.sprite = sprites[selectedIndex];
            Debug.Log("✅ Встановлено спрайт: " + selectedIndex);
        }
        else
        {
            Debug.LogWarning("⚠️ Індекс за межами масиву спрайтів!");
        }
    }

    public void GenerateRandomOrder()
    {
        if (dishDatabase.dishes.Count == 0) return;
        if (OrderPanel.activeSelf == false)
        {
            int randomIndex = Random.Range(0, dishDatabase.dishes.Count);
            currentOrder = dishDatabase.dishes[randomIndex];

            orderText.text = "Замовлення: " + currentOrder.name;
            OrderPanel.SetActive(true);
            Debug.Log("🍽 Згенеровано замовлення: " + currentOrder.name);
        }
        else
        {
            OrderPanel.SetActive(false);
            Debug.Log("❌ Панель прихована");
        }
    }
}