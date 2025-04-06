using UnityEngine;

public class DraggableIngredient : MonoBehaviour
{
    private Camera cam;              // Камера для визначення позиції
    private Vector3 offset;          // Зсув між об'єктом і мишкою
    private bool isDragging = false; // Перевірка, чи об'єкт перетягується

    private void Start()
    {
        cam = Camera.main; // Отримуємо основну камеру
    }

    private void OnMouseDown()
    {
        // Коли натискаємо на об'єкт, обчислюємо зсув від об'єкта до миші
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true; // Включаємо перетягування
    }

    private void OnMouseUp()
    {
        // Коли відпускаємо об'єкт, вимикаємо перетягування
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            // Переміщуємо об'єкт за курсором миші
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    // Метод для отримання позиції миші в світі
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.WorldToScreenPoint(transform.position).z; // Визначаємо глибину, щоб об'єкт не "випав" з екрану
        return cam.ScreenToWorldPoint(mousePos);
    }
}
