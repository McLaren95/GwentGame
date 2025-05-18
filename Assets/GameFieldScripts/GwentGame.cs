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
        GameObject gwent = GameObject.Find("GameField");
        GameObject round = new GameObject("round1");
        round1 = round.AddComponent<GwentRound>();
        round1.transform.SetParent(gwent.transform);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        create_gwent();
        create_first_round();
    }

}
