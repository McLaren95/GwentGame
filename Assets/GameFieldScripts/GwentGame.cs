using UnityEngine;

public class GwentGame : MonoBehaviour
{
    public GwentRound round;
    //public GwentRound round2;
    //public GwentRound round3;

    public int number_round;

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

    private Line clear_line(Line line, Transform pos_cards_to_line)
    {
        for (int i = 0; line.cards.Count != 0;)
        {
            line.cards[i].transform.SetParent(null);
            line.cards[i].transform.SetParent(pos_cards_to_line);
            line.cards[i]._set_pos(-0.2f, 0.0f, 0.0f);

            line.cards.Remove(line.cards[i]);
        }

        return line;
    }

    private void del_round(GwentRound round)
    {
        GameObject PlayerDeadCards = GameObject.Find("PlayerDeadCards");
        Transform PDeadCards = PlayerDeadCards.transform.Find("DeadCards");
        GameObject EnemyDeadCards = GameObject.Find("EnemyDeadCards");
        Transform EDeadCards = EnemyDeadCards.transform.Find("DeadCards");

        Destroy(clear_line(round.weather_line, PDeadCards));
        Destroy(clear_line(round.p2_line_melee, EDeadCards));
        Destroy(clear_line(round.p2_line_ranged, EDeadCards));
        Destroy(clear_line(round.p2_line_siege, EDeadCards));
        Destroy(clear_line(round.p1_line_melee, PDeadCards));
        Destroy(clear_line(round.p1_line_ranged, PDeadCards));
        Destroy(clear_line(round.p1_line_siege, PDeadCards));
        Destroy(round);
    }

    public void create_round()
    {
        if (this.number_round != 0)
        {
            this.del_round(this.round);
        }
        this.number_round++;
        GameObject p1 = GameObject.Find("player_geralt");
        GameObject p2 = GameObject.Find("player_ciri");
        Player player1 = p1.GetComponent<Player>();
        Player player2 = p2.GetComponent<Player>();

        GameObject gwent = GameObject.Find("GameField");
        GameObject _round = new GameObject("round" + this.number_round.ToString());
        this.round = _round.AddComponent<GwentRound>();
        this.round.initialization(1, player1, player2);
        this.round.transform.SetParent(null);
        this.round.transform.SetParent(gwent.transform);
    }

    public void end()
    {
        this.del_round(this.round);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.number_round = 0;
        create_gwent();
        create_round();
    }

}
