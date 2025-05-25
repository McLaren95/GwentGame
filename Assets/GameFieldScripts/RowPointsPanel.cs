using UnityEngine;
using TMPro;

public class RowPointsPanel : MonoBehaviour
{
    public TMP_Text playerMeleePointsText;
    public TMP_Text playerRangedPointsText;
    public TMP_Text playerSiegePointsText;
    public TMP_Text player_total;

    public TMP_Text enemyMeleePointsText;
    public TMP_Text enemyRangedPointsText;
    public TMP_Text enemySiegePointsText;
    public TMP_Text enemy_total;

    public GwentRound gwentRound;

    public int get_player_total()
    {
        return this.gwentRound.p1_line_melee.score + this.gwentRound.p1_line_ranged.score + this.gwentRound.p1_line_siege.score;
    }

    public int get_enemy_total()
    {
        return this.gwentRound.p2_line_melee.score + this.gwentRound.p2_line_ranged.score + this.gwentRound.p2_line_siege.score;
    }

    public void set_round(GwentRound round)
    {
        this.gwentRound = round;
    }

    public void update_score()
    {
        this.playerMeleePointsText.text = $"{this.gwentRound.p1_line_melee.score}";
        this.playerRangedPointsText.text = $"{this.gwentRound.p1_line_ranged.score}";
        this.playerSiegePointsText.text = $"{this.gwentRound.p1_line_siege.score}";

        this.player_total.text = $"{this.get_player_total()}";


        this.enemyMeleePointsText.text = $"{this.gwentRound.p2_line_melee.score}";
        this.enemyRangedPointsText.text = $"{this.gwentRound.p2_line_ranged.score}";
        this.enemySiegePointsText.text = $"{this.gwentRound.p2_line_siege.score}";

        this.enemy_total.text = $"{this.get_enemy_total()}";
    }
}