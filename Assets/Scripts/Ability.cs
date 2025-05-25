using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class AbilityAbstract : ScriptableObject
{
    //public string type;
    public Line line;
    public Player owner;
    public Card owner_card;


    public abstract void useAbility();

    public void set_owner_card(Card card)
    {
        this.owner_card = card;
    }

    public void set_owner(Player player)
    {
        this.owner = player;
    }

    public void set_line(Line line)
    {
        this.line = line;
    }
}

public class AbilityWithout : AbilityAbstract
{
    public override void useAbility() { return; }
}

public class AbilitySurgeOfSthreght : AbilityAbstract
{
    public override void useAbility()
    {
        int new_score = 0;
        for (int i = 0; i < this.line.cards.Count; i++)
        {
            if (this.line.cards[i].is_hero == 0)
            {
                this.line.cards[i].strenght++;
            }
            new_score += this.line.cards[i].get_strenght();
        }

        line.set_score(new_score);
    }
}

public class AbilityCommandersHorn : AbilityAbstract
{
    public override void useAbility() 
    {
        int new_score = 0;
        for (int i = 0; i < this.line.cards.Count; i++)
        {
            if (this.line.cards[i].is_hero == 0)
            {
                this.line.cards[i].strenght *= 2;
            }
            new_score += this.line.cards[i].get_strenght();
        }

        line.set_score(new_score);
    }
}



public class AbilityDouble : AbilityAbstract
{


    public override void useAbility()
    {
       for (int i = 0; i < this.line.cards.Count; i++)
        {
            this.line.cards[i].set_strenght(this.line.cards[i].get_strenght() + 2);
        }

        this.line.recalc_score_line();
    }
}



public class AbilityHero : AbilityAbstract
{
    public override void useAbility() { return; }
}



public class AbilityStrongConnection : AbilityAbstract
{
    public override void useAbility()
    {
        int new_score = 0;
        List<Card> cards_to_up = new List<Card>();
        for (int i = 0; i < this.line.cards.Count; i++)
        {
            if (this.line.cards[i].ability is AbilityStrongConnection)
            {
                cards_to_up.Add(this.line.cards[i]);
            }
            new_score += this.line.cards[i].get_strenght();
        }

        for (int i = 0; i < cards_to_up.Count && cards_to_up.Count > 1; i++)
        {
            new_score += cards_to_up[i].get_strenght();
            cards_to_up[i].strenght *= 2;
        }

        line.set_score(new_score);
    }
}



public class AbilitySpy : AbilityAbstract
{
    public override void useAbility()
    {
        List<Card> card_to_delete = new List<Card>();

        for (int i = 0; i < this.line.cards.Count; i++)
        {
            if (this.line.cards[i].is_hero == 0)
            {
                this.line.cards[i].set_strenght(this.line.cards[i].get_strenght() - this.owner_card.get_strenght());
            }
            if (this.line.cards[i].get_strenght() < 0)
            {
                card_to_delete.Add(this.line.cards[i]);
            }
        }

        for (int i = 0; i < card_to_delete.Count; i++)
        {
            this.line.del_card_to_line(card_to_delete[i]);

            if (this.owner.name_ == "geralt")
            {
                card_to_delete[i].send_to_dead_card("EnemyDeadCards");
            }
            else
            {
                card_to_delete[i].send_to_dead_card("PlayerDeadCards");
            }
        }

        this.line.recalc_score_line();
    }
}


public class AbilityHaze : AbilityAbstract
{
    private GwentRound round;

    public void set_round()
    {
        GameObject game = GameObject.Find("GameField");
        round = game.GetComponent<GwentGame>().round;
    }

    public override void useAbility()
    {
        this.set_round();
        int score_line_p1 = round.p1_line_ranged.cards.Count;
        int score_line_p2 = round.p2_line_ranged.cards.Count;

        for (int i = 0; i < round.p1_line_ranged.cards.Count; i++)
        {
            if (round.p1_line_ranged.cards[i].is_hero == 1)
            {
                score_line_p1 += round.p1_line_ranged.cards[i].get_strenght() - 1;
            }
        }

        for (int i = 0; i < round.p2_line_ranged.cards.Count; i++)
        {
            if (round.p2_line_ranged.cards[i].is_hero == 1)
            {
                score_line_p2 += round.p2_line_ranged.cards[i].get_strenght() - 1;
            }
        }

        round.p1_line_ranged.set_score(score_line_p1);
        round.p2_line_ranged.set_score(score_line_p2);
    }
}

public class AbilityAxe : AbilityAbstract
{
    private Line line_to_kill;
   

    private void choice_line()
    {
        GameObject game = GameObject.Find("GameField");
        GwentRound round = game.GetComponent<GwentGame>().round;

        if (this.owner.name_ == "geralt")
        {
            this.line_to_kill = round.p2_line_melee;
        }
        else
        {
            this.line_to_kill = round.p1_line_melee;
        }
    }

    public override void useAbility()
    {
        this.choice_line();

        List<Card> cards_to_dell = new List<Card>();

        for (int i = 0; i < this.line_to_kill.cards.Count; i++)
        {
            Card card;
            if (cards_to_dell.Count > 0)
            {
                card = cards_to_dell[0];
            }
            else
            {
                card = this.line_to_kill.cards[i];
            }

            if (card.get_strenght() >= 10 && card.is_hero == 0)
            {
                cards_to_dell.Add(card);

                for (int j = i + 1; j < this.line_to_kill.cards.Count; j++)
                {
                    if (this.line_to_kill.cards[j].get_strenght() > card.get_strenght())
                    {
                        cards_to_dell.Clear();
                        cards_to_dell.Add(this.line_to_kill.cards[j]);
                        card = this.line_to_kill.cards[j];
                    }
                    else if (this.line_to_kill.cards[j].get_strenght() == card.get_strenght())
                    {
                        cards_to_dell.Add(this.line_to_kill.cards[j]);
                    }
                }
            }
        }

        for(int i = 0; i < cards_to_dell.Count; i++)
        {
            line_to_kill.del_card_to_line(cards_to_dell[i]);
             
            if (owner.name_ == "geralt")
            {
                cards_to_dell[i].send_to_dead_card("EnemyDeadCards");
            }
            else
            {
                cards_to_dell[i].send_to_dead_card("PlayerDeadCards");
            }
        }

        line_to_kill.recalc_score_line();
    }
}

public class AbilityMedic : AbilityAbstract
{
    public override void useAbility()
    {
        this.line.recalc_score_line();
    }
}

public class AbilityFreezing : AbilityAbstract
{
    private GwentRound round;

    public void set_round()
    {
        GameObject game = GameObject.Find("GameField");
        round = game.GetComponent<GwentGame>().round;
    }

    public override void useAbility()
    {
        this.set_round();
        int score_line_p1 = round.p1_line_melee.cards.Count;
        int score_line_p2 = round.p2_line_melee.cards.Count;

        for (int i = 0; i < round.p1_line_melee.cards.Count; i++)
        {
            if (round.p1_line_melee.cards[i].is_hero == 1)
            {
                score_line_p1 += round.p1_line_melee.cards[i].get_strenght() - 1;
            }
        }

        for (int i = 0; i < round.p2_line_melee.cards.Count; i++)
        {
            if (round.p2_line_melee.cards[i].is_hero == 1)
            {
                score_line_p2 += round.p2_line_melee.cards[i].get_strenght() - 1;
            }
        }

        round.p1_line_melee.set_score(score_line_p1);
        round.p2_line_melee.set_score(score_line_p2);
    }
}

public class AbilityRain : AbilityAbstract
{
    private GwentRound round;

    public void set_round()
    {
        GameObject game = GameObject.Find("GameField");
        round = game.GetComponent<GwentGame>().round;
    }

    public override void useAbility()
    {
        this.set_round();
        int score_line_p1 = round.p1_line_siege.cards.Count;
        int score_line_p2 = round.p2_line_siege.cards.Count;

        for (int i = 0; i < round.p1_line_siege.cards.Count; i++)
        {
            if (round.p1_line_siege.cards[i].is_hero == 1)
            {
                score_line_p1 += round.p1_line_siege.cards[i].get_strenght() - 1;
            }
        }

        for (int i = 0; i < round.p2_line_siege.cards.Count; i++)
        {
            if (round.p2_line_siege.cards[i].is_hero == 1)
            {
                score_line_p2 += round.p2_line_siege.cards[i].get_strenght() - 1;
            }
        }

        round.p1_line_siege.set_score(score_line_p1);
        round.p2_line_siege.set_score(score_line_p2);
    }
}

public class AbilityClearSkies : AbilityAbstract
{
    public GwentRound round;

    public void set_round()
    {
        GameObject game = GameObject.Find("GameField");
        round = game.GetComponent<GwentGame>().round;
    }

    public override void useAbility()
    {
        this.set_round();

        round.p1_line_melee.recalc_score_line();
        round.p1_line_ranged.recalc_score_line();
        round.p1_line_siege.recalc_score_line();

        round.p2_line_melee.recalc_score_line();
        round.p2_line_ranged.recalc_score_line();
        round.p2_line_siege.recalc_score_line();
    }
}


public class AbilityScarecrow : AbilityAbstract
{
    public override void useAbility()
    {
        for (int i = 0; i < line.cards.Count; i++)
        {
            if (line.cards[i].is_hero == 1)
            {
                line.cards[i].is_hero = 0;
            }
            else
            {
                line.cards[i].is_hero = 1;
            }
        }
    }
}

public class AbilityAx : AbilityAbstract
{
    private Line line_to_kill;


    private void choice_line()
    {
        GameObject game = GameObject.Find("GameField");
        GwentRound round = game.GetComponent<GwentGame>().round;

        if (this.owner.name_ == "geralt")
        {
            this.line_to_kill = round.p2_line_melee;
        }
        else
        {
            this.line_to_kill = round.p1_line_melee;
        }
    }

    public override void useAbility()
    {
        this.choice_line();

        List<Card> cards_to_dell = new List<Card>();

        for (int i = 0; i < this.line_to_kill.cards.Count; i++)
        {
            Card card;
            if (cards_to_dell.Count > 0)
            {
                card = cards_to_dell[0];
            }
            else
            {
                card = this.line_to_kill.cards[i];
            }

            if (card.get_strenght() >= 10 && card.is_hero == 0)
            {
                cards_to_dell.Add(card);

                for (int j = i + 1; j < this.line_to_kill.cards.Count; j++)
                {
                    if (this.line_to_kill.cards[j].get_strenght() > card.get_strenght())
                    {
                        cards_to_dell.Clear();
                        cards_to_dell.Add(this.line_to_kill.cards[j]);
                        card = this.line_to_kill.cards[j];
                    }
                    else if (this.line_to_kill.cards[j].get_strenght() == card.get_strenght())
                    {
                        cards_to_dell.Add(this.line_to_kill.cards[j]);
                    }
                }
            }
        }

        for (int i = 0; i < cards_to_dell.Count; i++)
        {
            line_to_kill.del_card_to_line(cards_to_dell[i]);

            if (owner.name_ == "geralt")
            {
                cards_to_dell[i].send_to_dead_card("EnemyDeadCards");
            }
            else
            {
                cards_to_dell[i].send_to_dead_card("PlayerDeadCards");
            }
        }

        line_to_kill.recalc_score_line();
    }
}

public class AbilityNoEffect : AbilityAbstract
{
    public override void useAbility() { return; }
}