using UnityEngine;
using System.Collections.Generic;
using System.Linq;


[RequireComponent(typeof(SpriteRenderer))]
public class Fraction : MonoBehaviour
{
    [SerializeField] private CardController collection;
    [SerializeField] private CardController dec;
    [SerializeField] private CardController leader_controller;

    private string name_fraction;
    public PassiveSkillAbstract passive_skill;
    [SerializeField] public LeaderAbstract leader;
    public StatsUserCards stats;

    public List<Card> cards_collection = new List<Card>();
    public List<Card> dec_cards = new List<Card>();
    public List<LeaderAbstract> cards_leaders = new List<LeaderAbstract>();

    private SpriteRenderer render;
    private Sprite sprite;

    public int index_leader;

    public void usePassiveSkill() { return; }

    public List<Card> returnDecCards() { return this.dec_cards; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Запрещаем уничтожение
    }

    public void initialization(string name, PassiveSkillAbstract skill, List<Card> cards, List<LeaderAbstract> leaders, string path_to_image)
    {
        this.name_fraction = name;
        this.passive_skill = skill;
        this.cards_leaders = leaders;
        this.cards_collection = cards;

        this.leader = cards_leaders[0];


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
        cards_collection.Remove(card);
        dec_cards.Add(card);

        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
    }

    public void MoveToCollection(Card card)
    {
        dec_cards.Remove(card);
        cards_collection.Add(card);

        collection.set_cards_to_pos();
        dec.set_cards_to_pos();
    }

    public void next_leader()
    {
        this.leader.set_pos(0, 200, 1);
        this.index_leader++;
        if (this.index_leader == this.cards_leaders.Count)
        {
            this.index_leader = 0;
        }
        this.leader = this.cards_leaders[this.index_leader];
        this.leader.set_pos(0, 200, -300);
    }

    private void Start()
    {
        collection = GameObject.Find("CollectionCards").GetComponent<CardController>();
        dec = GameObject.Find("DecCards").GetComponent<CardController>();
        leader_controller = GameObject.Find("SelectLeaders").GetComponent<CardController>();

        index_leader = 0;
    }
}
