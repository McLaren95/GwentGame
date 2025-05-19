using UnityEngine;

public class GwentGame : MonoBehaviour
{
    public GwentRound round1;
    public GwentRound round2;
    public GwentRound round3;

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

    private void create_first_round()
    {
        GameObject p1 = GameObject.Find("player_geralt");
        GameObject p2 = GameObject.Find("player_ciri");
        Player player1 = p1.GetComponent<Player>();
        Player player2 = p2.GetComponent<Player>();

        GameObject gwent = GameObject.Find("GameField");
        GameObject round = new GameObject("round1");
        round1 = round.AddComponent<GwentRound>();
        round1.initialization(0, player1, player2);
        round1.transform.SetParent(gwent.transform);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        create_gwent();
        create_first_round();
    }

}
