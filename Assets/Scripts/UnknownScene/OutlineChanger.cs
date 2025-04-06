using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Додаємо бібліотеку для обробки подій

// Скрипт для зміни обводки UI-об'єкта (картинки) при наведенні та натисканні
public class OutlineChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,  IPointerClickHandler
{
    public Material defaultMaterial; // Стандартний матеріал (без обводки)
    public Material hoverMaterial;   // Матеріал при наведенні (біла обводка)
    public Material clickMaterial;   // Матеріал при натисканні (оранжева обводка)

    private Image image; // Компонент Image, який використовує матеріали

    private void Start()
    {
        // Отримуємо компонент Image із цього об'єкта
        image = GetComponent<Image>();
        
        // Перевіряємо, чи знайдено компонент Image
        if (image == null)
        {
            Debug.LogError("OutlineChanger: Image component not found!");
        }
    }

    // Викликається при наведенні курсора на об'єкт
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null) image.material = hoverMaterial;
        Debug.Log("Enter");
    }

    // Викликається, коли курсор виходить за межі об'єкта
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
    }

    // Викликається при натисканні на об'єкт
    public void OnPointerDown(PointerEventData eventData)
    {
        if (image != null) image.material = clickMaterial;
        Debug.Log("Down");
    }

    // Викликається, коли кнопка миші відпускається після натискання
    public void OnPointerUp(PointerEventData eventData)
    {
        if (image != null) image.material = hoverMaterial; // Повертаємо стан "наведення"
        Debug.Log("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }
}
