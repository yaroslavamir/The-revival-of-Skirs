using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Додаємо бібліотеку для обробки подій

// Скрипт для зміни обводки UI-об'єкта (картинки) при наведенні та натисканні
public class WorkShaders : MonoBehaviour
{
    // public Material defaultMaterial; // Стандартний матеріал (без обводки)
    // public Material hoverMaterial;   // Матеріал при наведенні (біла обводка)
    public Material clickMaterial;   // Матеріал при натисканні (оранжева обводка)

    private Image image; // Компонент Image, який використовує матеріали

    private void Start()
    {
        //Отримуємо компонент Image із цього об'єкта
        image = GetComponent<Image>();
        
        // Перевіряємо, чи знайдено компонент Image
        if (image == null)
        {
            Debug.LogError("OutlineChanger: Image component not found!");
        }
    }

    public void Click()
    {
        if (image != null) image.material = clickMaterial;
        Debug.Log("Down");
    }

    //   void OnMouseOver()
    // {
    //     //If your mouse hovers over the GameObject with the script attached, output this message
    //     Debug.Log("Mouse is over GameObject.");
    // }

    // void OnMouseExit()
    // {
    //     //The mouse is no longer hovering over the GameObject so output this message each frame
    //     Debug.Log("Mouse is no longer on GameObject.");
    // }

    // // Викликається при наведенні курсора на об'єкт
    // public void Hover()
    // {
    //     // if (image != null) image.material = hoverMaterial;
    //     Debug.Log("Enter");
    // }

    // // Викликається, коли курсор виходить за межі об'єкта
    // public void Unhover()
    // {
    //     Debug.Log("Exit");
    // }

    // Викликається при натисканні на об'єкт
    
}
