using UnityEngine;

public class GwentGame : MonoBehaviour
{
    public GwentRound round1;
    public GwentRound round2;
    public GwentRound round3;

    public int round;

    Player winner;

    public void press_pass_button()
    {
        return;
    }

    private void create_gwent()
    {
        GameObject gwent = new GameObject("GwentRounds");
        GameObject game_field = GameObject.Find("GameField");
        gwent.transform.SetParent(game_field.transform);
    }


    private void del_round(GwentRound round)
    {
        GameObject PlayerDeadCards = GameObject.Find("PlayerDeadCards");
        Transform PDeadCards = PlayerDeadCards.transform.Find("DeadCards");
        GameObject EnemyDeadCards = GameObject.Find("EnemyDeadCards");
        Transform EDeadCards = EnemyDeadCards.transform.Find("DeadCards");

        for (int i = 0; round.p2_line_melee.cards.Count != 0;)
        {
            round.p2_line_melee.cards[i].transform.SetParent(null);
            round.p2_line_melee.cards[i].transform.SetParent(EDeadCards);
            round.p2_line_melee.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            round.p2_line_melee.cards.Remove(round.p2_line_melee.cards[i]);
        }
        for (int i = 0; round.p2_line_ranged.cards.Count != 0;)
        {
            round.p2_line_ranged.cards[i].transform.SetParent(null);
            round.p2_line_ranged.cards[i].transform.SetParent(EDeadCards);
            round.p2_line_ranged.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            round.p2_line_ranged.cards.Remove(round.p2_line_ranged.cards[i]);
        }
        for (int i = 0; round.p2_line_siege.cards.Count != 0;)
        {
            round.p2_line_siege.cards[i].transform.SetParent(null);
            round.p2_line_siege.cards[i].transform.SetParent(EDeadCards);
            round.p2_line_siege.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            round.p2_line_siege.cards.Remove(round.p2_line_siege.cards[i]);
        }

        for (int i = 0; round.p1_line_melee.cards.Count != 0;)
        {
            round.p1_line_melee.cards[i].transform.SetParent(null);
            round.p1_line_melee.cards[i].transform.SetParent(PDeadCards);
            round.p1_line_melee.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            round.p1_line_melee.cards.Remove(round.p1_line_melee.cards[i]);
        }
        for (int i = 0; round.p1_line_ranged.cards.Count != 0;)
        {
            round.p1_line_ranged.cards[i].transform.SetParent(null);
            round.p1_line_ranged.cards[i].transform.SetParent(PDeadCards);
            round.p1_line_ranged.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            round.p1_line_ranged.cards.Remove(round.p1_line_ranged.cards[i]);
        }
        for (int i = 0; round.p1_line_siege.cards.Count != 0;)
        {
            round.p1_line_siege.cards[i].transform.SetParent(null);
            round.p1_line_siege.cards[i].transform.SetParent(PDeadCards);
            round.p1_line_siege.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            round.p1_line_siege.cards.Remove(round.p1_line_siege.cards[i]);
        }
        Destroy(round.p2_line_melee);
        Destroy(round.p2_line_ranged);
        Destroy(round.p2_line_siege);
        Destroy(round.p1_line_melee);
        Destroy(round.p1_line_ranged);
        Destroy(round.p1_line_siege);
        Destroy(round);
    }


    private void create_first_round()
    {

        this.round = 1;
        GameObject p1 = GameObject.Find("player_geralt");
        GameObject p2 = GameObject.Find("player_ciri");
        Player player1 = p1.GetComponent<Player>();
        Player player2 = p2.GetComponent<Player>();

        GameObject gwent = GameObject.Find("GameField");
        GameObject round = new GameObject("round1");
        round1 = round.AddComponent<GwentRound>();
        round1.initialization(1, player1, player2);
        round1.transform.SetParent(null);
        round1.transform.SetParent(gwent.transform);
    }

    public void create_second_round()
    {
        this.del_round(this.round1);
        this.round = 2;
        GameObject p1 = GameObject.Find("player_geralt");
        GameObject p2 = GameObject.Find("player_ciri");
        Player player1 = p1.GetComponent<Player>();
        Player player2 = p2.GetComponent<Player>();

        GameObject gwent = GameObject.Find("GameField");
        GameObject round = new GameObject("round2");
        round2 = round.AddComponent<GwentRound>();
        round2.initialization(1, player1, player2);
        round2.transform.SetParent(null);
        round2.transform.SetParent(gwent.transform);
    }

    public void create_third_round()
    {
        this.del_round(this.round2);
        this.round = 3;
        GameObject p1 = GameObject.Find("player_geralt");
        GameObject p2 = GameObject.Find("player_ciri");
        Player player1 = p1.GetComponent<Player>();
        Player player2 = p2.GetComponent<Player>();

        GameObject gwent = GameObject.Find("GameField");
        GameObject round = new GameObject("round3");
        round3 = round.AddComponent<GwentRound>();
        round3.initialization(1, player1, player2);
        round3.transform.SetParent(null);
        round3.transform.SetParent(gwent.transform);
    }

    public void end()
    {
        this.del_round(this.round3);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        create_gwent();
        create_first_round();
    }

}
