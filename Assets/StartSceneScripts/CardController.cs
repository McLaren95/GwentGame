using System;
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


    public void set_cards_to_pos(int pos=-300)
    {
        this.size_ñ = fraction.selected_fraction.cards_collection.Count;
        this.size_d = fraction.selected_fraction.dec_cards.Count;

        int size_type_collection = side == "left" ? this.size_ñ : this.size_d;
        for (int i = 0; i < size_type_collection; i++)
        {
            if (side == "left")
            {
                fraction.selected_fraction.cards_collection[i].set_pos(
                    -x[i % 3],
                    y[i % 6 > 2 ? 1 : 0],
                    i < 6 ? pos : 0);
            }
            else
            {
                fraction.selected_fraction.dec_cards[i].set_pos(
                    x[i % 3],
                    y[i % 6 > 2 ? 1 : 0],
                    i < 6 ? pos : 0);
            }
        }
        index = size_type_collection > 5 ? 6 : size_type_collection;
    }


    public void next_cards()
    {
        int size = side == "left" ? this.size_ñ : this.size_d;
        size -= index;

        if (index >= 6)
        {
            for (int i = index - 6; i <= index && i < size; i++)
            {
                if (side == "left")
                {
                    fraction.selected_fraction.cards_collection[i].set_pos(
                        -x[i % 3],
                        y[i % 6 > 2 ? 1 : 0],
                        1);
                }
                else
                {
                    fraction.selected_fraction.dec_cards[i].set_pos(
                        x[i % 3],
                        y[i % 6 > 2 ? 1 : 0],
                        1);
                }
            }
        }

        int iterations = 6;
        if (size < 5)
            iterations = size;

        for (int i = index; i <= index + iterations && i < size; i++)
        {
            if (side == "left")
            {
                fraction.selected_fraction.cards_collection[i].set_pos(
                    -x[i % 3],
                    y[i % 6 > 2 ? 1 : 0],
                    -300);
            }
            else
            {
                fraction.selected_fraction.dec_cards[i].set_pos(
                    x[i % 3],
                    y[i % 6 > 2 ? 1 : 0],
                    -300);
            }
        }

        index += 6;

    }


    public void back_cards()
    {
        int size = side == "left" ? this.size_ñ : this.size_d;
        int _size = index - size;

        if (index > 6)
        {
            for (int i = 0; i < size; i++)
            {
                if (side == "left")
                {
                    fraction.selected_fraction.cards_collection[i].set_pos(
                        -x[i % 3],
                        y[i % 6 > 2 ? 1 : 0],
                        1);
                }
                else
                {
                    fraction.selected_fraction.dec_cards[i].set_pos(
                        x[i % 3],
                        y[i % 6 > 2 ? 1 : 0],
                        1);
                }
            }
        }

        int iterations = 6;
        if (index < 6)
        {
            iterations = index;
        }

        for (int i = index; i > index - iterations && i > -1; i--)
        {
            if (side == "left")
            {
                fraction.selected_fraction.cards_collection[i].set_pos(
                    -x[i % 3],
                    y[i % 6 > 2 ? 1 : 0],
                    -300);
            }
            else
            {
                fraction.selected_fraction.dec_cards[i].set_pos(
                    x[i % 3],
                    y[i % 6 > 2 ? 1 : 0],
                    -300);
            }
        }

        index -= 6;
    }


    void Start()
    {
        GameObject obj_fractions = GameObject.Find("CreateFractions");
        fraction = obj_fractions.GetComponent<CreateFractions>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

