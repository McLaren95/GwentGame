using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObjectsFromDontDestroyToScene : MonoBehaviour
{
    private void move_dec_cards_player1()
    {
        GameObject DeckCardsPlayer = GameObject.Find("DeckCardsPlayer");

        GameObject P1 = GameObject.Find("player_geralt");
        Player player1 = P1.GetComponent<Player>();

        Vector3 old = DeckCardsPlayer.transform.localScale;
        DeckCardsPlayer.transform.localScale = new Vector3(200f, 270f, 0f);

        for (int i = 0; i < player1.dec_cards.Count; i++)
        {
            player1.dec_cards[i].transform.SetParent(null);
            MoveCard(player1.dec_cards[i], DeckCardsPlayer);
            player1.dec_cards[i].set_pos(0f, 0f, 0f);
        }

        DeckCardsPlayer.transform.localScale = new Vector3(1f, 1.219077f, 1f);
    }

    private void move_dec_cards_player2()
    {
        GameObject DeckCardsEnemy = GameObject.Find("DeckCardsEnemy");

        GameObject P2 = GameObject.Find("player_ciri");
        Player player2 = P2.GetComponent<Player>();

        Vector3 old = DeckCardsEnemy.transform.localScale;
        DeckCardsEnemy.transform.localScale = new Vector3(200f, 270f, 0f);

        for (int i = 0; i < player2.dec_cards.Count; i++)
        {
            MoveCard(player2.dec_cards[i], DeckCardsEnemy);
            player2.dec_cards[i].set_pos(0f, 0f, 0f);
        }

        DeckCardsEnemy.transform.localScale = new Vector3(1f, 1.219077f, 1f);

    }






    private void move_players_to_pos()
    {
        GameObject FactionAvatarPlayer = GameObject.Find("FactionAvatarPlayer");
        GameObject FactionAvatarEnemy = GameObject.Find("FactionAvatarEnemy");
        GameObject player_geralt = GameObject.Find("player_geralt");
        GameObject player_ciri = GameObject.Find("player_ciri");

        player_geralt.transform.localPosition = new Vector3(0f, 0f, 0f);
        player_ciri.transform.localPosition = new Vector3(0f, 0f, 0f);

        player_geralt.transform.localScale = new Vector3(130f, 130f, 10f);
        player_ciri.transform.localScale = new Vector3(130f, 130f, 10f);

        MoveObjectToCardCount("player_geralt", FactionAvatarPlayer);
        MoveObjectToCardCount("player_ciri", FactionAvatarEnemy);
    }







    private void move_random_10_cards_to_hand_player1()
    {
        GameObject P1 = GameObject.Find("player_geralt");
        Player player1 = P1.GetComponent<Player>();

        GameObject HandDeckPlayer = GameObject.Find("HandDeckPlayer");

        System.Random rand = new System.Random();

        for (int i = 0; i < 10; i++)
        {
            player1.move_card_from_dec_to_hand(player1.dec_cards[rand.Next(0, player1.dec_cards.Count - 1)]);
            MoveObjectToCardCountSetNull(player1.hand_cards[i].name_card, HandDeckPlayer);
            player1.hand_cards[i]._set_pos(-4.1f + i * 0.9f, 0.0f, 1.0f);
            //if (player1.dec_cards.Count >= 10)
            //{
            //    break;
            //}
        }
    }

    private void move_random_10_cards_to_hand_player2()
    {
        GameObject P2 = GameObject.Find("player_ciri");
        Player player2 = P2.GetComponent<Player>();

        System.Random rand = new System.Random();

        for (int i = 0; i < 10; i++)
        {
            player2.move_card_from_dec_to_hand(player2.dec_cards[rand.Next(0, player2.dec_cards.Count - 1)]);

        }
    }

    private void move_leaders()
    {
        GameObject LeaderPlayer = GameObject.Find("LeaderPlayer");
        GameObject LeaderEnemy = GameObject.Find("LeaderEnemy");

        Vector3 old1 = LeaderPlayer.transform.localScale;
        LeaderPlayer.transform.localScale = new Vector3(150f, 200f, 0f);
        Vector3 old2 = LeaderEnemy.transform.localScale;
        LeaderEnemy.transform.localScale = new Vector3(150f, 200f, 0f);

        GameObject P1 = GameObject.Find("player_geralt");
        Player player1 = P1.GetComponent<Player>();
       

        GameObject P2 = GameObject.Find("player_ciri");
        Player player2 = P2.GetComponent<Player>();

        MoveObjectToCardCount(player1.leader._name, LeaderPlayer);
        MoveObjectToCardCount(player2.leader._name, LeaderEnemy);
        player1.leader._set_pos(0.0f, 0.0f, 0.0f);
        player2.leader._set_pos(0.0f, 0.0f, 0.0f);
        LeaderPlayer.transform.localScale = old1;
        LeaderEnemy.transform.localScale = old2;
    }







    void Start()
    {
        move_dec_cards_player1();
        move_dec_cards_player2();
        move_players_to_pos();
        move_random_10_cards_to_hand_player1();
        move_random_10_cards_to_hand_player2();
        move_leaders();

    }







    void MoveObjectToCardCountSetNull(string objName, GameObject parent)
    {
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            // Отвязываем объект от текущего родителя
            Transform currentParent = obj.transform.parent;
            if (currentParent != null)
            {
                obj.transform.SetParent(null);
            }

            // Перемещаем объект в активную сцену
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
            // Привязываем объект к новому родителю
            obj.transform.SetParent(parent.transform);
        }
    }

    void MoveObjectToCardCount(string objName, GameObject parent)
    {
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            // Отвязываем объект от текущего родителя
            Transform currentParent = obj.transform.parent;
            if (currentParent != null)
            {
                obj.transform.SetParent(null);
            }

            // Перемещаем объект в активную сцену
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());

            // Привязываем объект к новому родителю
            obj.transform.SetParent(parent.transform);
        }
    }

    void MoveCard(Card card, GameObject parent)
    {
        if (card != null && card.gameObject != null)
        {
            // Отвязываем карту от текущего родителя
            Transform currentParent = card.gameObject.transform.parent;
            if (currentParent != null)
            {
                card.gameObject.transform.SetParent(null);
            }

            // Перемещаем карту в активную сцену
            SceneManager.MoveGameObjectToScene(card.gameObject, SceneManager.GetActiveScene());

            // Привязываем карту к новому родителю
            card.gameObject.transform.SetParent(parent.transform);

        }
    }
}