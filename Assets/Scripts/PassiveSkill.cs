using UnityEngine;

public abstract class PassiveSkillAbstract : ScriptableObject
{
    public string type;
    public abstract void usePassiveSkill();
}

public class PassiveSkillKingdomOfTheNorth : PassiveSkillAbstract
{
    public override void usePassiveSkill()
    {
        return;
    }
}

public class PassiveSkillNilfgaard : PassiveSkillAbstract
{
    public override void usePassiveSkill()
    {
        return;
    }
}

public class PassiveSkillMonsters : PassiveSkillAbstract
{
    public override void usePassiveSkill()
    {
        return;
    }
}

public class PassiveSkillScoiatael : PassiveSkillAbstract
{
    public override void usePassiveSkill()
    {
        return;
    }
}