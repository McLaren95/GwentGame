using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class NextCardsColllecton : MonoBehaviour
{
    [SerializeField] private CardController card_controller;
    public Button button;

    public void OnButtonClick()
    {
        if (card_controller != null)
        {
            card_controller.next_cards();
        }
    }

    void Start()
    {

        button.onClick.AddListener(OnButtonClick);
    }

}
