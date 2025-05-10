using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[RequireComponent(typeof(SpriteRenderer))]
public class Fraction : MonoBehaviour
{
    [SerializeField] private CardController collection;
    [SerializeField] private CardController dec;

    private string name_fraction;
    private PassiveSkillAbstract passive_skill;
    private LeaderAbstract leader;
    private StatsUserCards stats;

    public List<Card> cards_collection = new List<Card>();
    public List<Card> dec_cards = new List<Card>();
    public List<LeaderAbstract> cards_leaders = new List<LeaderAbstract>();

    private SpriteRenderer render;
    private Sprite sprite;


    public void usePassiveSkill() { return; }

    public List<Card> returnDecCards() { return this.dec_cards; }


   public void initialization(string name, PassiveSkillAbstract skill, List<Card> cards, List<LeaderAbstract> leaders, string path_to_image)
    {
        this.name_fraction = name;
        this.passive_skill = skill;
        this.cards_leaders = leaders;
        this.cards_collection = cards;

        
        loadSprite(path_to_image);
        setupComponents();

        transform.localScale = new Vector3(100.0f, 110.0f, 0.0f);
        set_pos(0.0f, 400.0f, 1.0f);
    }


    public void set_pos(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }


    private void setupComponents()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = sprite;

    }

    private void loadSprite(string path)
    {
        sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(path);
    }

    public void MoveToDeck(Card card)
    {
        UnityEngine.Debug.Log($"Â 111: {card}");
        cards_collection.Remove(card);
        dec_cards.Add(card);

        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
    }

    public void MoveToCollection(Card card)
    {
        UnityEngine.Debug.Log($"Â 222: {card}");
        dec_cards.Remove(card);
        cards_collection.Add(card);

        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
    }

    private void Start()
    {
        collection = GameObject.Find("CollectionCards").GetComponent<CardController>();
        dec = GameObject.Find("DecCards").GetComponent<CardController>();
    }
}
