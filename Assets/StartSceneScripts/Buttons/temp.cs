using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class temp : MonoBehaviour
{
    [SerializeField] private CardController create_fractions;
    public Button button;

    public void OnButtonClick()
    {
        if (create_fractions != null)
        {
            create_fractions.set_cards_to_pos();
        }
    }

    void Start()
    {
        GameObject obj_fractions = GameObject.Find("CollectionCards");
        create_fractions = obj_fractions.GetComponent<CardController>();
        button.onClick.AddListener(OnButtonClick);
    }

}
