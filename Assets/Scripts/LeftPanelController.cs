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
    public Transform enemyLivesContainer; // ���� ������� ������ �����

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
        // ������ ���������:
        enemyName.text = "������";
        enemyFactionName.text = "��������";
        enemyCardsCount.text = "�����: 9";
        enemyScore.text = "0";
        // ���������� ��� �������
        playerName.text = "�������";
        playerFactionName.text = "����������� ������";
        playerCardsCount.text = "�����: 10";
        playerScore.text = "0";

        // �������� ������:
        playerPassButton.onClick.RemoveAllListeners();
        playerPassButton.onClick.AddListener(OnPlayerPass);
    }

    public void OnPlayerPass()
    {
        Debug.Log("����� ��������!");
    }
}
