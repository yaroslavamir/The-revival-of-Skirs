using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Швидкість руху камери
    [SerializeField] public GameObject PanelActivity;
    // Межі руху камери (налаштовуй у інспекторі)
    public float minX = -10f, maxX = 10f; // Межі по X

    void Update()
    {
        if(PanelActivity.GetComponent<UIScript>().PanelActive == false)
        {
        // Отримуємо введення (натискання стрілочок або WASD)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Рахуємо нову позицію
        Vector3 newPosition = transform.position + new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime;

        // Обмежуємо рух камери у вказаних межах
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Присвоюємо нову позицію камері
        transform.position = newPosition;
        }
    }
}

