using UnityEngine;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Diagnostics;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Threading;


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


    public void use_ability()
    {
        this.ability.useAbility();
    }

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

    public void set_strenght(int strenght)
    {
        this.strenght = strenght;
    }

    public void set_leader_line(Line line)
    {
        this.ability.set_line(line);
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


    private string get_owner_name()
    {
        string owner_name = this.owner.name_ == "geralt" ? "Player" : "Enemy";

        if (this.ability is AbilitySpy)
        {
            owner_name = this.owner.name_ == "geralt" ? "Enemy" : "Player";
        }

        return owner_name;
    }

    private string get_name_line(string type_millitary)
    {
        string plus_owner = this.get_owner_name();
        string name_line = "";

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
            name_line = "WeatherField";
        }
        else
        {
            name_line = plus_owner + "SiegeRow";
        }

        if (type_millitary == "Командирский рог")
        {
            name_line = plus_owner + "MeleeRow";
        }

        return name_line;
    }

    public void send_to_dead_card(string name_line)
    {
        GameObject weather_line = GameObject.Find(name_line);

        this.set_parent_card_to(weather_line, "DeadCards");
        this._set_pos(0f, 0f, 0f);
    }

    private bool clear_weather_line(Line line)
    {
        if (this.name_card == "Ясное небо")
        {
            GameObject game_field = GameObject.Find("GameField");
            GwentGame _game = game_field.GetComponent<GwentGame>();

            GameObject weather_line = GameObject.Find("PlayerDeadCards");
            Transform row_marker = weather_line.transform.Find("DeadCards");

            _game.clear_line(line, row_marker);

            return true;
        }

        return false;
    }

    private void set_weather_card_to_pos(Line line)
    {
        if (this.clear_weather_line(line))
        {
            return;
        }

        if (line.cards.Count == 1)
        {
            this._set_pos(-line.cards.Count * 0.6f, 0f, 2f);
        }
        else if (line.cards.Count == 2)
        {
            this._set_pos(-line.cards.Count * 0f, 0f, 2f);
        }
        else
        {
            this._set_pos(line.cards.Count * 0.2f, 0f, 2f);
        }
    }

    private void set_card_hand_to_pos(Line line)
    {
        if (line.cards.Count < 6)
        {
            this._set_pos(-line.cards.Count * 0.8f, 0f, 2f);
        }
        else
        {
            this._set_pos((line.cards.Count - 6) * 0.8f, 0f, 2f);
        }
    }

    private void set_parent_card_to(GameObject line, string type_line)
    {
        Transform row_lin = line.transform.Find(type_line);

        this.transform.SetParent(null);
        this.transform.SetParent(row_lin.transform);
    }

    private void set_commander_porn()
    {
        this._set_pos(0f, 0f, 0f);
    }

   
    public void OnMouseUpAsButton()
    {
        if (parentFraction == null && owner.hand_cards.Contains(this))
        {
            string type_millitary = this.type.getType();

            string name_line = this.get_name_line(type_millitary);


            GameObject obj_line = GameObject.Find(name_line);
            Line line = obj_line.GetComponent<Line>();

            if (line.cards.Count < 11 && (!line.cards.Contains(this) || this.ability is AbilityStrongConnection))
            {
                line.add_card(this);

                this.set_parent_card_to(obj_line, "RowMarker");
                if (type_millitary == "Погода")
                {
                    this.set_weather_card_to_pos(line);
                }
                else if (type_millitary == "Командирский рог")
                {
                    this.set_parent_card_to(obj_line, "CommanderHorn");
                    this.set_commander_porn();
                }
                else
                {
                    this.set_card_hand_to_pos(line);
                }

                owner.remove_card_in_hand(this);
                this.move_enemy_card();
            }    
        }
    }





















    public void make_enemy()
    {
        if (parentFraction == null && owner.hand_cards.Contains(this) || this.ability is AbilityDouble)
        {
            string type_millitary = this.type.getType();

            string name_line = this.get_name_line(type_millitary);


            GameObject obj_line = GameObject.Find(name_line);
            Line line = obj_line.GetComponent<Line>();

            if (line.cards.Count < 11 && (!line.cards.Contains(this) || this.ability is AbilityStrongConnection || this.ability is AbilityDouble))
            {
                line.add_card(this);

                this.set_parent_card_to(obj_line, "RowMarker");

                
                if (type_millitary == "Погода")
                {
                    this.set_weather_card_to_pos(line);
                }
                else if (type_millitary == "Командирский рог")
                {
                    this.set_parent_card_to(obj_line, "CommanderHorn");
                    this.set_commander_porn();
                }
                else
                {
                    this.set_card_hand_to_pos(line);
                }

                owner.remove_card_in_hand(this);
            }
        }
    }

    private void move_enemy_card()
    {
        GameObject _enemy = GameObject.Find("player_ciri");
        Player enemy = _enemy.GetComponent<Player>();

        enemy.hand_cards[0].make_enemy();
    }
}


