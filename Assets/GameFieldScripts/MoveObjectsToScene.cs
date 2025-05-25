using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObjectsFromDontDestroyToScene : MonoBehaviour
{
    private Player player;
    private Player enemy;


    private void init_players()
    {
        GameObject P1 = GameObject.Find("player_geralt");
        GameObject P2 = GameObject.Find("player_ciri");
        player = P1.GetComponent<Player>();
        enemy = P2.GetComponent<Player>();
    }

    private void move_dec_cards_player(Player player, string type_deck)
    {
        GameObject deck_cards = GameObject.Find(type_deck);

        Vector3 old = deck_cards.transform.localScale;
        deck_cards.transform.localScale = new Vector3(200f, 270f, 0f);

        for (int i = 0; i < player.dec_cards.Count; i++)
        {
            player.dec_cards[i].transform.SetParent(null);
            MoveObjectToCardCount(player.dec_cards[i].name_card, deck_cards);
            player.dec_cards[i].set_pos(0f, 0f, 0f);
        }

        deck_cards.transform.localScale = old;
    }

    private void move_players_to_pos()
    {
        GameObject FactionAvatarPlayer = GameObject.Find("FactionAvatarPlayer");
        GameObject FactionAvatarEnemy = GameObject.Find("FactionAvatarEnemy");

        MoveObjectToCardCount("player_geralt", FactionAvatarPlayer);
        MoveObjectToCardCount("player_ciri", FactionAvatarEnemy);

        this.player.transform.localScale = new Vector3(130f, 130f, 10f);
        this.enemy.transform.localScale = new Vector3(130f, 130f, 10f);

        this.player.transform.localPosition = new Vector3(0f, 0f, 0f);
        this.enemy.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    private void move_random_10_cards_to_hand_player1()
    {
        GameObject HandDeckPlayer = GameObject.Find("HandDeckPlayer");

        System.Random rand = new System.Random();
        int cardsToMove = Mathf.Min(10, this.player.dec_cards.Count);

        for (int i = 0; i < cardsToMove; i++)
        {
            if (this.player.dec_cards.Count == 0)
                break;

            int index = rand.Next(this.player.dec_cards.Count);
            Card card = this.player.dec_cards[index];
            this.player.move_card_from_dec_to_hand(card);

            if (i < this.player.hand_cards.Count)
            {
                MoveObjectToCardCountSetNull(this.player.hand_cards[i].name_card, HandDeckPlayer);
                this.player.hand_cards[i]._set_pos(-4.1f + i * 0.9f, 0.0f, 1.0f);
            }
        }
    }

    private void move_random_10_cards_to_hand_player2()
    {
        System.Random rand = new System.Random();
        int cardsToMove = Mathf.Min(10, this.enemy.dec_cards.Count);

        for (int i = 0; i < cardsToMove; i++)
        {
            if (this.enemy.dec_cards.Count == 0)
                break;

            int index = rand.Next(this.enemy.dec_cards.Count);
            Card card = this.enemy.dec_cards[index];
            this.enemy.move_card_from_dec_to_hand(card);
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

        MoveObjectToCardCount(this.player.leader._name, LeaderPlayer);
        MoveObjectToCardCount(this.enemy.leader._name, LeaderEnemy);
        this.player.leader._set_pos(0.0f, 0.0f, 0.0f);
        this.enemy.leader._set_pos(0.0f, 0.0f, 0.0f);
        LeaderPlayer.transform.localScale = old1;
        LeaderEnemy.transform.localScale = old2;
    }


    void Start()
    {
        this.init_players();

        this.move_dec_cards_player(this.player, "DeckCardsPlayer");
        this.move_dec_cards_player(this.enemy, "DeckCardsEnemy");
        move_players_to_pos();
        move_random_10_cards_to_hand_player1();
        move_random_10_cards_to_hand_player2();
        move_leaders();

        Destroy(this);
    }


    void MoveObjectToCardCountSetNull(string objName, GameObject parent)
    {
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            Transform currentParent = obj.transform.parent;
            if (currentParent != null)
            {
                obj.transform.SetParent(null);
            }
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
            obj.transform.SetParent(parent.transform);
        }
    }

    void MoveObjectToCardCount(string objName, GameObject parent)
    {
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            Transform currentParent = obj.transform.parent;
            if (currentParent != null)
            {
                obj.transform.SetParent(null);
            }
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());

            obj.transform.SetParent(parent.transform);
        }
    }
}