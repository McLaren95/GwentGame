using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Card commander_horn;
    public List<Card> cards;
    public TypeMillitary type;

    private int score;


    public void initialization(TypeMillitary type)
    {
        this.type = type;
        this.score = 0;
        this.cards = new List<Card>();
    }

    public void add_card(Card card)
    {
        cards.Add(card);
        this.score += card.get_strenght();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
