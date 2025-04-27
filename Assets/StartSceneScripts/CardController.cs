using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CreateFractions fraction;
    public string side;
    private int size_ñ;
    private int size_d;
    private int index;

    private List<int> x = new List<int> { 520, 355, 190 };
    private List<int> y = new List<int> { 120, -180 };


    private void set_card_to(float x, float y, float z)
    {
        fraction.selected_fraction.cards_collection[index].set_pos(x, y, z);
    }


    public void initialization(string side)
    {
        this.side = side;
        this.index = 0;
    }


    public void set_cards_to_pos()
    {
        this.size_ñ = fraction.selected_fraction.cards_collection.Count;
        this.size_d = fraction.selected_fraction.dec_cards.Count;

            
            for (int i = 0; i < size_ñ; i++)
            {
                fraction.selected_fraction.cards_collection[i].set_pos(
                    side == "left" ? x[i % 3] : -x[i % 3], 
                    y[i % 6 > 2 ? 1 : 0], 
                    i < 6 ? -300 : 0);
            }
        index = 6;
    }


    public void next_cards()
    {
        int size = side == "left" ? size_ñ - index : size_d - index;
        int iterations = 0;
        if (size < 6)
        {
            iterations = size;
        } 
        else
        {
            iterations = 6;
        }

        for (int i = 0; i < iterations; i++)
        {
            fraction.selected_fraction.cards_collection[index].set_pos(
                side == "left" ? x[index % 3] : -x[index % 3],
                y[i % 6 > 2 ? 1 : 0],
                -300);

            fraction.selected_fraction.cards_collection[index - i - 1].set_pos(
                side == "left" ? x[index % 3] : -x[index % 3],
                y[i % 6 > 2 ? 1 : 0],
                0);

            index++;
        }
    }


    void Start()
    {
        GameObject obj_fractions = GameObject.Find("CreateFractions");
        fraction = obj_fractions.GetComponent<CreateFractions>();
        index = 0;

        //this.size_ñ = fraction.selected_fraction.cards_collection.Count;
        //this.size_d = fraction.selected_fraction.dec_cards.Count;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
