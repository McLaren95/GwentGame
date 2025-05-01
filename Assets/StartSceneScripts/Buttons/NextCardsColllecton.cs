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
        GameObject obj_fractions = GameObject.Find("CollectionCards");
        card_controller = obj_fractions.GetComponent<CardController>();
        button.onClick.AddListener(OnButtonClick);
    }

}
