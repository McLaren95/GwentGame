using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public abstract class LeaderAbstract : MonoBehaviour
{
    public Fraction parentFraction;

    private SpriteRenderer render;
    private Sprite sprite;

    public string _name;
    public abstract void useAbility();

    public LeaderAbstract initialization(string name, string path_to_image) {  
        this._name = name;
        loadSprite(path_to_image);
        setupComponents();

        transform.localScale = new Vector3(40, 40, 1);

        return this;
    }

    public void set_pos(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
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

    public void OnMouseDown()
    {
        if (parentFraction != null)
        {
            if (parentFraction.cards_leaders.Contains(this))
                parentFraction.next_leader();

        }
    }

}

public class LeaderKingdomOfTheNorth1 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderKingdomOfTheNorth2 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderKingdomOfTheNorth3 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderKingdomOfTheNorth4 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderKingdomOfTheNorth5 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}



public class LeaderNilfgaard1 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderNilfgaard2 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderNilfgaard3 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderNilfgaard4 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}



public class LeaderMonsters1 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderMonsters2 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderMonsters3 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderMonsters4 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}



public class LeaderScoiatael1 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderScoiatael2 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderScoiatael3 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}

public class LeaderScoiatael4 : LeaderAbstract
{
    public override void useAbility()
    {
        return;
    }
}
