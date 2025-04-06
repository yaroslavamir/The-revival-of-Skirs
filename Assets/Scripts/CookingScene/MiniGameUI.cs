
using UnityEngine;


public class MiniGameUI : MonoBehaviour
{
    public GameObject SliderPanelBoard, KettleSlider, SliderPanelToaster,  Ingridients, EquipmentBtn, CardsParent;
    public bool PanelActive = false;

    void Start()
    {
        SliderPanelBoard.SetActive(false);
        SliderPanelToaster.SetActive(false);
    }

    public void CardsGameBtn()
    {
        if(PanelActive == false)
        {
            EquipmentBtn.SetActive(false);
            Ingridients.SetActive(false);
            CardsParent.SetActive(true);
            PanelActive = true;
        }
    }
    public void EscCardsGameBtn()
    {
            EquipmentBtn.SetActive(true);
            Ingridients.SetActive(true);
            CardsParent.SetActive(false);
            PanelActive = false;
            GameObject.Find("EscCardsGameBtn").SetActive(false);
    }
// -------------------------------------------
// Kitchen Board
    public void SliderBoardBtn()
    {
        if (!PanelActive)
        {
            // Debug.Log("SliderBtn: Натиснуто кнопку ножа");
            SliderPanelBoard.SetActive(true);
            SliderGame sliderBoardGame = SliderPanelBoard.GetComponent<SliderGame>();
            if (sliderBoardGame == null)
            {
                // Debug.LogError("SliderBtn: НЕ знайдено sliderBoardGame на SliderPanel!");
                return;
            }
            sliderBoardGame.canSlise = true;
            // Debug.Log("SliderBtn: Викликаємо StartSlider()");
            sliderBoardGame.StartSlider();

            if (sliderBoardGame.canSlise)
            {
                PanelActive = true;
            }
            else
            {
                // Debug.Log("SliderBtn: canSlise = false, закриваємо панель");
                SliderPanelBoard.SetActive(false);
            }
        }
    }


   public void EscSliderBoardBtn()
   {
        if(SliderPanelBoard.GetComponent<SliderGame>().CanInteract == true)
        {
        SliderPanelBoard.SetActive(false);
        PanelActive = false;
        }
   }
// -----------------------------------------
// Toaster
   public void SliderToasterBtn()
    {
        if (!PanelActive)
        {
            Debug.Log("SliderToasterBtn: Натиснуто кнопку тостеру");
            SliderPanelToaster.SetActive(true);
            ToasterGame sliderToasterGame = SliderPanelToaster.GetComponent<ToasterGame>();
            if (sliderToasterGame == null)
            {
                // Debug.LogError("SliderToasterBtn: НЕ знайдено SliderPanelToaster на SliderPanel!");
                return;
            }
            sliderToasterGame.canSlise = true;
            // Debug.Log("SliderToasterBtn: Викликаємо StartSlider()");
            sliderToasterGame.StartSlider();

            if (sliderToasterGame.canSlise)
            {
                PanelActive = true;
            }
            else
            {
                // Debug.Log("SliderBtn: canSlise = false, закриваємо панель");
                SliderPanelToaster.SetActive(false);
            }
        }
    }


   public void EscSliderToasterBtn()
   {
        if(SliderPanelToaster.GetComponent<SliderGame>().CanInteract == true)
        {
        SliderPanelToaster.SetActive(false);
        PanelActive = false;
        }
   }
//    ------------------------------------------
   public void KettleBtn()
   {
        if(PanelActive == false)
        {
            KettleSlider.SetActive(true);
        }
   }
}
