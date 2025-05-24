using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Card commander_horn;
    public List<Card> cards;
    public TypeMillitary type;

    public int score;


    public void recalc_score_line()
    {
        this.score = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            this.score += cards[i].get_strenght();
        }
    }

    public void update_score_lines()
    {
        GameObject obj_panel = GameObject.Find("RowPointsPanel");
        RowPointsPanel panel = obj_panel.GetComponent<RowPointsPanel>();

        panel.update_score();
    }

    public void initialization(TypeMillitary type)
    {
        this.type = type;
        this.score = 0;
        this.cards = new List<Card>();
    }

    private void check_ability_axe(Card card)
    {
        if (card.ability is AbilityAxe)
        {
            card.ability.set_owner(card.owner);
        }
    }

    private void set_ability_owner_card(Card card)
    {
        if (card.ability is AbilitySpy)
        {
            card.ability.set_owner_card(card);
            card.ability.set_owner(card.owner);
        }
    }

    private void check_ability_double(Card card)
    {
        if (card.ability is AbilityDouble)
        {
            card.ability.set_owner(card.owner);
        }
    }

    public void add_card(Card card)
    {
        cards.Add(card);
        this.score += card.get_strenght();

        this.check_ability_axe(card);
        this.set_ability_owner_card(card);
        this.check_ability_double(card);

        card.set_leader_line(this);
        card.use_ability();

        this.update_score_lines();
    }

    public int get_score()
    {
        return this.score;
    }

    public void set_score(int score)
    {
        this.score = score;
    }

    public void del_card_to_line(Card card) 
    { 
        this.cards.Remove(card);
    }
}
