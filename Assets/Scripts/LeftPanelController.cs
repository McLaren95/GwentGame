using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LeftPanelController : MonoBehaviour
{
    [Header("Leader Slots")]
    public Image enemyLeaderImage;
    public Image playerLeaderImage;

    [Header("Enemy Info")]
    public Image enemyIcon;
    public TMP_Text enemyName;
    public TMP_Text enemyFactionName;
    public TMP_Text enemyCardsCount;
    public TMP_Text enemyScore;
    public Transform enemyLivesContainer; // сюда добавим иконки жизни

    [Header("Player Info")]
    public Image playerIcon;
    public TMP_Text playerName;
    public TMP_Text playerFactionName;
    public TMP_Text playerCardsCount;
    public TMP_Text playerScore;
    public Transform playerLivesContainer;

    [Header("Weather Field")]
    public Transform weatherContainer;

    [Header("Player Pass Button")]
    public Button playerPassButton;

    void Start()
    {
        // Пример «заглушки»:
        enemyName.text = "Болван";
        enemyFactionName.text = "Чудовища";
        enemyCardsCount.text = "Карты: 9";
        enemyScore.text = "0";
        // аналогично для игрока…
        playerName.text = "Геральт";
        playerFactionName.text = "Королевство севера";
        playerCardsCount.text = "Карты: 10";
        playerScore.text = "0";

        // Привяжем кнопку:
        playerPassButton.onClick.RemoveAllListeners();
        playerPassButton.onClick.AddListener(OnPlayerPass);
    }

    public void OnPlayerPass()
    {
        Debug.Log("Игрок спасовал!");
    }
}
