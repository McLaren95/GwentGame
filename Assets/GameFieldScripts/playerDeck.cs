using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeckMoveScript : MonoBehaviour
{
    void Start()
    {

        GameObject DeckCardsPlayer = GameObject.Find("DeckCardsPlayer");

        if (DeckCardsPlayer != null)
        {
            GameObject P1 = GameObject.Find("player_geralt");
            Player player1 = P1.GetComponent<Player>();
            for (int i = 0; i < player1.dec_cards.Count; i++)
            {
                MoveObjectToCardCount(player1.dec_cards[i].name_card, DeckCardsPlayer);
            }

        }
    }

    void MoveObjectToCardCount(string objName, GameObject parent)
    {
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
            obj.transform.SetParent(parent.transform);
        }
    }
}