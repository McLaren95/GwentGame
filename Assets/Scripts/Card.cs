using UnityEngine;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Diagnostics;
using UnityEngine.EventSystems;


[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
    public Fraction parentFraction;

    private SpriteRenderer render;
    private Sprite sprite;

    public string name_card;
    public int strenght;
    private int is_hero;

    private Vector3 pos;
    private TypeMillitary type;
    private AbilityAbstract ability;


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
}

