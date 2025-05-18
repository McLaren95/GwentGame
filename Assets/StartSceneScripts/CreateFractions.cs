using System.Collections.Generic;
using UnityEngine;


public class CreateFractions : MonoBehaviour
{
    private Fraction fraction;
    [SerializeField] private CreateCards create_cards; 
    public List<Fraction> fractions = new List<Fraction>();
    public Fraction selected_fraction;
    private int index_fraction;

    [SerializeField] private CardController collection;
    [SerializeField] private CardController dec;
    [SerializeField] private CardController leaders;


    private Fraction createFraction(string name, PassiveSkillAbstract skill, List<Card> cards, List<LeaderAbstract> leaders, string path)
    {
        GameObject fractionObj = new GameObject(name);
        var fraction = fractionObj.AddComponent<Fraction>();
        fraction.initialization(name, skill, cards, leaders, path);
        fraction.transform.SetParent(transform);
        return fraction;
    }


    public void nextFraction()
    {
        fractions[index_fraction].set_pos(0.0f, 450.0f, 1.0f);
        collection.set_cards_to_pos(1);
        dec.set_cards_to_pos(1);
        leaders.set_leaders_to_pos(1);
        if (index_fraction == 3)
        {
            index_fraction = 0;
        }
        else
        {
            index_fraction++;
        }

        fractions[index_fraction].set_pos(0.0f, 450.0f, -150.0f);
        selected_fraction = fractions[index_fraction];
        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
        leaders.set_leaders_to_pos();
    }

    public void backFraction()
    {
        fractions[index_fraction].set_pos(0.0f, 450.0f, 1.0f);
        collection.set_cards_to_pos(1);
        dec.set_cards_to_pos(1);
        leaders.set_leaders_to_pos(1);
        if (index_fraction == 0)
        {
            index_fraction = 3;
        }
        else
        {
            index_fraction--;
        }

        fractions[index_fraction].set_pos(0.0f, 450.0f, -150.0f);
        selected_fraction = fractions[index_fraction];
        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
        leaders.set_leaders_to_pos();
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        create_cards = new GameObject("createCards").AddComponent<CreateCards>();
        var skill_kingdom = ScriptableObject.CreateInstance<PassiveSkillKingdomOfTheNorth>();
        var skill_nilfgaard = ScriptableObject.CreateInstance<PassiveSkillNilfgaard>();
        var skill_monsters = ScriptableObject.CreateInstance<PassiveSkillMonsters>();
        var skill_scoiatael = ScriptableObject.CreateInstance<PassiveSkillScoiatael>();

        fractions.Add(
            createFraction(
                "Королевства Севера",
                ScriptableObject.CreateInstance<PassiveSkillKingdomOfTheNorth>(), 
                create_cards.createCardKingdom(), 
                create_cards.getLeadersKingdomOfTheNorth(),
                "Assets/Skins/fractions/frac1.png")
            );

        fractions.Add(
            createFraction(
                "Нильфгаард",
                ScriptableObject.CreateInstance<PassiveSkillNilfgaard>(), 
                create_cards.createCardNilfgaard(), 
                create_cards.getLeadersNilfgaard(),
                "Assets/Skins/fractions/frac4.png")
            );

        fractions.Add(
            createFraction(
                "Чудовища",
                ScriptableObject.CreateInstance<PassiveSkillMonsters>(), 
                create_cards.createCardMonsters(), 
                create_cards.getLeadersMonsters(),
                "Assets/Skins/fractions/frac3.png")
            );

        fractions.Add(
            createFraction(
                "Скоя'таэли",
                ScriptableObject.CreateInstance<PassiveSkillScoiatael>(), 
                create_cards.createCardScoiatael(), 
                create_cards.getLeadersScoiatael(),
                "Assets/Skins/fractions/frac2.png")
            );

        index_fraction = 0;
        fractions[index_fraction].set_pos(0.0f, 450.0f, -150.0f);
        selected_fraction = fractions[index_fraction];


        
        for (int i = 0; i < fractions.Count; i++)
        {
            for (int j = 0; j < fractions[i].cards_collection.Count; j++)
            {
                fractions[i].cards_collection[j].setParentFraction(fractions[i]);
            }
            for (int j = 0; j < fractions[i].cards_leaders.Count; j++)
            {
                fractions[i].cards_leaders[j].setParentFraction(fractions[i]);

            }
        }

        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
        selected_fraction.cards_leaders[selected_fraction.index_leader].set_pos(0, 200, -300);
    }

}
