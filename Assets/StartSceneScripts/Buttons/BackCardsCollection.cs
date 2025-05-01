using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class BackCardsCollection : MonoBehaviour
{
    [SerializeField] private CardController card_controller;
    public Button button;

    public void OnButtonClick()
    {
        if (card_controller != null)
        {
            card_controller.back_cards();
        }
    }

    void Start()
    {
       
        button.onClick.AddListener(OnButtonClick);
    }

}
