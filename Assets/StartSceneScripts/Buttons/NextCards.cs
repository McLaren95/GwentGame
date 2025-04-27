using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;



public class NextCardButton : MonoBehaviour
{
    [SerializeField] private CardController card_controller;
    public Button button;


    public void OnButtonClick()
    {
        card_controller.next_cards();
    }

    void Start()
    {
        GameObject card_controller1 = GameObject.Find("CollectionCards");
        card_controller = card_controller1.GetComponent<CardController>();
        button.onClick.AddListener(OnButtonClick);


    }


}
