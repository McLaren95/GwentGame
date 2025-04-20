using UnityEngine;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Diagnostics;


[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
    private SpriteRenderer render;
    private Sprite sprite;

    public string name_card;
    public int strenght;
    private int is_hero;

    private Vector3 pos;
    private TypeMillitary type;
    private AbilityAbstract ability;
    

    public void initialization(string name, int strenght, string path_to_image, TypeMillitary type, AbilityAbstract ability, int is_hero=0)
    {
        this.name_card = name;
        this.strenght = strenght;
        this.type = type;
        this.ability = ability;
        this.is_hero = is_hero;
       
        loadSprite(path_to_image);
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
}

