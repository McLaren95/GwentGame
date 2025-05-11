using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite sprite;

    public string name_;

    public Fraction fraction;
    public int health;
    
    public int total_score;


    [SerializeField] public LeaderAbstract leader;
    public List<Card> dec_cards = new List<Card>();
    public PassiveSkillAbstract passive_skill;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Запрещаем уничтожение
    }

    public void initialization(Fraction fraction, string name_, string path)
    {
        this.name_ = name_;
        this.fraction = fraction;
        this.health = 2;
        this.total_score = 0;



        this.leader = fraction.leader;
        DontDestroyOnLoad(this.leader);

        this.dec_cards = fraction.dec_cards;
        for (int i = 0; i < this.dec_cards.Count; i++)
        {
            DontDestroyOnLoad(this.dec_cards[i]);
        }

        this.passive_skill = fraction.passive_skill;
        DontDestroyOnLoad(this.passive_skill);

        setupComponents();
        loadSprite(path);
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

}
