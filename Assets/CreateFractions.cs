using System.Collections.Generic;
using UnityEngine;


public class CreateFractions : MonoBehaviour
{
    private Fraction fraction;
    [SerializeField] private CreateCards create_cards; 
    private List<Fraction> fractions = new List<Fraction>(); 



    private Fraction createFraction(string name, PassiveSkillAbstract skill, List<Card> cards, List<LeaderAbstract> leaders)
    {
        GameObject fractionObj = new GameObject(name);
        var fraction = fractionObj.AddComponent<Fraction>();
        fraction.initialization(name, skill, cards, leaders);
        fraction.transform.SetParent(transform);
        return fraction;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        create_cards = new GameObject("createCards").AddComponent<CreateCards>();
        var skill_kingdom = ScriptableObject.CreateInstance<PassiveSkillKingdomOfTheNorth>();
        var skill_nilfgaard = ScriptableObject.CreateInstance<PassiveSkillNilfgaard>();
        var skill_monsters = ScriptableObject.CreateInstance<PassiveSkillMonsters>();
        var skill_scoiatael = ScriptableObject.CreateInstance<PassiveSkillScoiatael>();

        List<LeaderAbstract> lead = new List<LeaderAbstract>();
        var card = create_cards.getNeutralCards();

        fractions.Add(
            createFraction(
                "Королевства Севера",
                ScriptableObject.CreateInstance<PassiveSkillKingdomOfTheNorth>(), 
                create_cards.createCardKingdom(), 
                create_cards.getLeadersKingdomOfTheNorth())
            );

        fractions.Add(
            createFraction(
                "Нильфгаард",
                ScriptableObject.CreateInstance<PassiveSkillNilfgaard>(), 
                create_cards.createCardNilfgaard(), 
                create_cards.getLeadersNilfgaard())
            );

        fractions.Add(
            createFraction(
                "Чудовища",
                ScriptableObject.CreateInstance<PassiveSkillMonsters>(), 
                create_cards.createCardMonsters(), 
                create_cards.getLeadersMonsters())
            );

        fractions.Add(
            createFraction(
                "Скоя'таэли",
                ScriptableObject.CreateInstance<PassiveSkillScoiatael>(), 
                create_cards.createCardScoiatael(), 
                create_cards.getLeadersScoiatael())
            );

    }

}
