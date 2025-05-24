using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;


public class GwentGame : MonoBehaviour
{
    public GwentRound round;

    public int number_round;

    public RowPointsPanel panel;

    public List<GameObject> healt_player;
    public List<GameObject> healt_enemy;

    Player winner;

    private void init_health()
    {
        healt_player.Add(GameObject.Find("PlayerHealthIcon1"));
        healt_player.Add(GameObject.Find("PlayerHealthIcon2"));

        healt_enemy.Add(GameObject.Find("EnemyHealthIcon1"));
        healt_enemy.Add(GameObject.Find("EnemyHealthIcon2"));
    }

    private void del_health_player()
    {
        if (healt_player.Count > 0)
        {
            GameObject health = healt_player[0];
            healt_player.Remove(health);
            health.transform.position = new Vector3(123f, 123f, 123f);
        }
    }

    private void del_health_enemy()
    {
        if (healt_enemy.Count > 0)
        {
            GameObject health = healt_enemy[0];
            healt_enemy.Remove(health);
            health.transform.position = new Vector3(123f, 123f, 123f);
        }
    }

    private void check_winner_in_round()
    {
        int player_score = this.panel.get_player_total();
        int enemy_score = this.panel.get_enemy_total();

        if (player_score > enemy_score)
        {
            this.del_health_enemy();
        }
        else if (player_score == enemy_score)
        {
            this.del_health_enemy();
            this.del_health_player();
        }
        else
        {
            this.del_health_player();
        }
    }

    private void check_winner()
    {
        if (this.healt_player.Count == 0 && this.healt_enemy.Count > 0)
        {
            this.winner = GameObject.Find("player_ciri").GetComponent<Player>();
        } 
        else if (this.healt_enemy.Count == 0 && this.healt_player.Count > 0)
        {
            this.winner = GameObject.Find("player_geralt").GetComponent<Player>();
        }
    }

    private void create_gwent()
    {
        GameObject gwent = new GameObject("GwentRounds");
        GameObject game_field = GameObject.Find("GameField");
        gwent.transform.SetParent(game_field.transform);
    }

    public Line clear_line(Line line, Transform pos_cards_to_line)
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

    private void set_score_null()
    {
        this.round.p1_line_melee.update_score_lines();
    }

    private void create_win(string path)
    {
        GameObject okno = new GameObject("WIN");
        SpriteRenderer render = okno.AddComponent<SpriteRenderer>();
        Sprite sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(path);
        render.sprite = sprite;
        okno.transform.position = new Vector3(0f, 0f, -1f);
        okno.transform.localScale = new Vector3(1.4f, 1.4f, 1f);

    }

    public void create_round()
    {
        if (this.number_round != 0)
        {
            this.check_winner_in_round();
            this.check_winner();
            this.del_round(this.round);
        }
        if (healt_player.Count == 0 && healt_enemy.Count == 0)
        {
            this.create_win("Assets/Skins/win/draw.png");
        }
        else if (this.winner == null)
        {
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

            this.panel.set_round(this.round);

            this.set_score_null();
        }
        else
        {
            if (this.winner.name_ == "geralt")
            {
                this.create_win("Assets/Skins/win/win.png");
            }
            else 
            {
                this.create_win("Assets/Skins/win/los.png");
            }
                
        }
    }

    public void end()
    {
        this.check_winner_in_round();
        this.check_winner();
        if (winner == null)
        {
            this.create_win("Assets/Skins/win/draw.png");
        }
        else
        {
            if (this.winner.name_ == "geralt")
            {
                this.create_win("Assets/Skins/win/win.png");
            }
            else
            {
                this.create_win("Assets/Skins/win/los.png");
            }
        }
            this.del_round(this.round);
    }

    private void find_panel_score()
    {
        GameObject obj_panel = GameObject.Find("RowPointsPanel");
        this.panel = obj_panel.GetComponent<RowPointsPanel>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        init_health();

        find_panel_score();

        this.number_round = 0;
        create_gwent();
        create_round();
    }

}
