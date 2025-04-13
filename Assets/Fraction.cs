using UnityEngine;
using System.Collections.Generic;

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

    private void createFraction(string name, PassiveSkillAbstract skill, List<Card> cards, List<LeaderAbstract> leaders)
    {
        GameObject _fraction = new GameObject(name);
        _fraction.transform.SetParent(this.transform);

        Fraction fraction = _fraction.GetComponent<Fraction>();

        fraction.name_fraction = name;
        fraction.passive_skill = skill;
        fraction.cards_collection = cards;
        fraction.cards_leaders = leaders;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PassiveSkillKingdomOfTheNorth skill_kingdom = new GameObject("PassiveKingdom").AddComponent<PassiveSkillKingdomOfTheNorth>();
        PassiveSkillNilfgaard skill_nilfgaard = new GameObject("PassiveNilfgaard").AddComponent<PassiveSkillNilfgaard>();
        PassiveSkillMonsters skill_monsters = new GameObject("PassiveMonsters").AddComponent<PassiveSkillMonsters>();
        PassiveSkillScoiatael skill_scoiatael = new GameObject("PassiveScoiatael").AddComponent<PassiveSkillScoiatael>();

        List<Card> card = new List<Card>();
        List<LeaderAbstract> lead = new List<LeaderAbstract>();

        createFraction("Королевства Севера", skill_kingdom, card, lead);
        createFraction("Нильфгаард", skill_nilfgaard, card, lead);
        createFraction("Чудовища", skill_monsters, card, lead);
        createFraction("Скоя'таэли", skill_scoiatael, card, lead);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
