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

        fractions.Add(createFraction("Королевства Севера", skill_kingdom, 
            create_cards.createCardKingdom(), create_cards.getLeadersKingdomOfTheNorth()));
        fractions.Add(createFraction("Нильфгаард", skill_nilfgaard, card, lead));
        fractions.Add(createFraction("Чудовища", skill_monsters, card, lead));
        fractions.Add(createFraction("Скоя'таэли", skill_scoiatael, card, lead));
    }

}
