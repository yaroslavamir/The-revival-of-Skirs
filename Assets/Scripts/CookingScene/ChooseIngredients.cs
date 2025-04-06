using UnityEngine;

public class ChooseIngredients : MonoBehaviour
{
    private GameObject selectedObject;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Натискання ЛКМ
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Ingredients"))
            {
                selectedObject = hit.collider.gameObject;
                offset = selectedObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButton(0) && selectedObject != null) // Переміщення об'єкта
        {
            selectedObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

        if (Input.GetMouseButtonUp(0)) // Відпускання об'єкта
        {
            selectedObject = null;
        }
    }
}
