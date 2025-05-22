using UnityEngine;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Diagnostics;
using UnityEngine.EventSystems;
using System.Collections.Generic;


[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
    public Fraction parentFraction;

    private SpriteRenderer render;
    private Sprite sprite;

    public string name_card;
    public int strenght;
    public int is_hero;

    private Vector3 pos;
    public TypeMillitary type;
    public AbilityAbstract ability;

    public Player owner;


    public void initialization(
        string name,
        int strenght,
        string path_to_image,
        TypeMillitary type,
        AbilityAbstract ability,
        int is_hero = 0,
        float x = 50.0f,
        float y = 50.0f,
        float z = 0.0f
        )
    {
        this.name_card = name;
        this.strenght = strenght;
        this.type = type;
        this.ability = ability;
        this.is_hero = is_hero;

        loadSprite(path_to_image);
        setupComponents();

        transform.localScale = new Vector3(x, y, z);
        set_pos(0, 0, 1);
    }


    public void set_pos(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    public void _set_pos(float x, float y, float z)
    {
        transform.localPosition = new Vector3(x, y, z);
    }

    public void _set_scale(float x, float y, float z)
    {
        transform.localScale = new Vector3(x, y, z);
    }

    private void setupComponents()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = sprite;

        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
    }

    private void loadSprite(string path)
    {
        sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(path);
    }

    private void Start()
    {


    }

    public void setParentFraction(Fraction fraction)
    {
        parentFraction = fraction;
    }

    public void set_player(Player player)
    {
        this.owner = player;
    }

    public int get_strenght()
    {
        return this.strenght;
    }
    public void OnMouseDown()
    {
        if (parentFraction != null)
        {
            if (parentFraction.cards_collection.Contains(this))
                parentFraction.MoveToDeck(this);
            else if (parentFraction.dec_cards.Contains(this))
                parentFraction.MoveToCollection(this);
        }
    }


    public void OnMouseUpAsButton()
    {
        if (parentFraction == null && owner.hand_cards.Contains(this))
        {
            List<string> types = new List<string>
        {
            "Ближний",
            "Дальний",
            "Осадный",
            "Погода",
            "Командирский рог"
        };
            var type_millitary = types[this.type.type];
            string name_line = "";

            string plus_owner = this.owner.name_ == "geralt" ? "Player" : "Enemy";

            if (this.ability is AbilitySpy)
            {
                plus_owner = this.owner.name_ == "geralt" ? "Enemy" : "Player";
            }

            if (type_millitary == "Ближний")
            {
                name_line = plus_owner + "MeleeRow";
            }
            else if (type_millitary == "Дальний")
            {
                name_line = plus_owner + "RangedRow";
            }
            else if (type_millitary == "Погода")
            {

            }
            else if (type_millitary == "Командирский рог")
            {

            }
            else
            {
                name_line = plus_owner + "SiegeRow";
            }

            GameObject obj_line = GameObject.Find(name_line);
            Line line = obj_line.GetComponent<Line>();

            if (line.cards.Count < 11 && (!line.cards.Contains(this) || this.ability is AbilityStrongConnection))
            {
                line.add_card(this);

                Transform row_lin = obj_line.transform.Find("RowMarker");

                this.transform.SetParent(null);
                this.transform.SetParent(row_lin.transform);

                if (line.cards.Count < 6)
                {
                    this._set_pos(-line.cards.Count * 0.8f, 0f, 2f);
                }
                else
                {
                    this._set_pos((line.cards.Count - 6) * 0.8f, 0f, 2f);
                }

                owner.remove_card_in_hand(this); 
            }    
        }
    }
}

