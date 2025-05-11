using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private SpriteRenderer render;
    private Sprite sprite;

    public string name_;

    public Fraction fraction;
    public int health;
    
    public int total_score;



    public void initialization(Fraction fraction, string name_, string path)
    {
        this.name_ = name_;
        this.fraction = fraction;
        this.health = 2;
        this.total_score = 0;

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
