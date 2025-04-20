using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public abstract class LeaderAbstract : MonoBehaviour
{
    private SpriteRenderer render;
    private Sprite sprite;

    public string _name;
    public abstract void useAbility();

    public LeaderAbstract initialization(string name, string path_to_image) {  
        this._name = name;
        loadSprite(path_to_image);
        setupComponents();

        return this;
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
