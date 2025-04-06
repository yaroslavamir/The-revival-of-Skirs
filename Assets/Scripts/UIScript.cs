
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIScript : MonoBehaviour
{
    public GameObject RecipePanel;
    public bool PanelActive = false;
    public void OpenBook()
   {
    if(PanelActive == false)
    {
    RecipePanel.SetActive(true);
    PanelActive = true;
    }
   }

   public void CloseBook()
   {
    RecipePanel.SetActive(false);
    PanelActive = false;
   }

   public void GoToKazan()
   {
    SceneManager.LoadScene("Kazan");
   }
   public void GoToReception()
   {
    SceneManager.LoadScene("Reception");
   }
    public void GoToKitchen()
   {
    SceneManager.LoadScene("Kitchen");
   }
}
