using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Card commander_horn;
    public List<Card> cards;
    public TypeMillitary type;

    public int score;


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

    void Start()
    {
        this.score = 0;
    }

    void Update()
    {
        
    }
}
