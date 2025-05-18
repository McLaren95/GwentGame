using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite sprite;

    public string name_;
    public string name_fraction;

    public Fraction fraction;
    public int health;
    
    public int total_score;


    [SerializeField] public LeaderAbstract leader;

    public List<Card> dec_cards = new List<Card>();
    public List<Card> hand_cards = new List<Card>();
    public List<Card> dead_cards = new List<Card>();

    // Событие для уведомления об изменении количества карт
    public delegate void CardCountChanged(int newCount);
    public event CardCountChanged OnCardCountChanged;

    public PassiveSkillAbstract passive_skill;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void initialization(Fraction fraction, string name_, string path)
    {
        this.name_ = name_;
        this.fraction = fraction;
        this.health = 2;
        this.total_score = 0;
        this.name_fraction = fraction.name_fraction;


        this.leader = fraction.leader;
        DontDestroyOnLoad(this.leader);

        this.dec_cards = fraction.dec_cards;
        for (int i = 0; i < this.dec_cards.Count; i++)
        {
            DontDestroyOnLoad(this.dec_cards[i]);
        }

        this.passive_skill = fraction.passive_skill;
        DontDestroyOnLoad(this.passive_skill);

        loadSprite(path);
        setupComponents();
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


    public void move_card_from_dec_to_hand(Card card)
    {
        dec_cards.Remove(card);
        hand_cards.Add(card);
        NotifyCardCountChanged();
    }

    private void NotifyCardCountChanged()
    {
        OnCardCountChanged?.Invoke(hand_cards.Count);
    }


}
