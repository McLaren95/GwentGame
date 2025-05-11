using System.Diagnostics;
using UnityEngine;

public class GameFieldController : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public void set_cards_player1()
    {
        
    }

    private void Awake()
    {
        player1 = GameObject.Find("player_geralt")?.GetComponent<Player>();
        player2 = GameObject.Find("player_ciri")?.GetComponent<Player>();


    }

    void Start()
    {


    }


}
