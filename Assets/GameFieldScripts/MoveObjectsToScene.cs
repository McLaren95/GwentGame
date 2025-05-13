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
        for (int i = 0; i < player1.dec_cards.Count; i++)
        {
            player1.dec_cards[i].transform.SetParent(null);
            MoveObjectToCardCount(player1.dec_cards[i].name_card, DeckCardsPlayer);
        }
    }

    private void move_dec_cards_player2()
    {
        GameObject DeckCardsEnemy = GameObject.Find("DeckCardsEnemy");

        GameObject P2 = GameObject.Find("player_ciri");
        Player player2 = P2.GetComponent<Player>();
        for (int i = 0; i < player2.dec_cards.Count; i++)
        {
            MoveObjectToCardCount(player2.dec_cards[i].name_card, DeckCardsEnemy);
        }
    }

    private void move_players_to_pos()
    {
        GameObject FactionAvatarPlayer = GameObject.Find("FactionAvatarPlayer");
        GameObject FactionAvatarEnemy = GameObject.Find("FactionAvatarEnemy");

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
            Card moving_card = player1.dec_cards[rand.Next(0, player1.dec_cards.Count)];
            player1.move_card_from_dec_to_hand(moving_card);
            MoveObjectToCardCountSetNull(moving_card.name_card, HandDeckPlayer);
        }
    }

    private void move_random_10_cards_to_hand_player2()
    {
        GameObject P2 = GameObject.Find("player_ciri");
        Player player2 = P2.GetComponent<Player>();

        GameObject DeckCardsEnemy = GameObject.Find("DeckCardsEnemy");

        System.Random rand = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            Card moving_card = player2.dec_cards[rand.Next(0, player2.dec_cards.Count)];
            player2.move_card_from_dec_to_hand(moving_card);
            MoveObjectToCardCountSetNull(moving_card.name_card, DeckCardsEnemy);
        }
    }

    private void move_leaders()
    {
        GameObject LeaderPlayer = GameObject.Find("LeaderPlayer");
        //GameObject LeaderEnemy = GameObject.Find("LeaderEnemy");
        GameObject P1 = GameObject.Find("player_geralt");
        Player player1 = P1.GetComponent<Player>();
        //GameObject P2 = GameObject.Find("player_ciri");
        //Player player2 = P2.GetComponent<Player>();

        MoveObjectToCardCount(player1.leader._name, LeaderPlayer);
        //MoveObjectToCardCount(player2.leader._name, LeaderEnemy);
    }


    void Start()
    {
        move_dec_cards_player1();
        //move_dec_cards_player2();
        move_players_to_pos();
        move_random_10_cards_to_hand_player1();
        //move_random_10_cards_to_hand_player2();
        move_leaders();

    }

    void MoveObjectToCardCountSetNull(string objName, GameObject parent)
    {
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            obj.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
            obj.transform.SetParent(parent.transform);
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