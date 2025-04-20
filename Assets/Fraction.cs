using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Fraction : MonoBehaviour
{
    private string name_fraction;
    private PassiveSkillAbstract passive_skill;
    private LeaderAbstract leader;
    private StatsUserCards stats;

    private List<Card> cards_collection = new List<Card>();
    private List<Card> dec_cards = new List<Card>();
    private List<LeaderAbstract> cards_leaders = new List<LeaderAbstract>();

    
    public void sendCardToDecFromCollection(Card card) { return; }
    public void sendCardToCollectionFromDec(Card card) { return; }

    public void usePassiveSkill() { return; }

    public List<Card> returnDecCards() { return this.dec_cards; }


   public void initialization(string name, PassiveSkillAbstract skill, List<Card> cards, List<LeaderAbstract> leaders)
    {
        this.name_fraction = name;
        this.passive_skill = skill;
        this.cards_leaders = leaders;
        this.cards_collection = cards;
     
    }

}
