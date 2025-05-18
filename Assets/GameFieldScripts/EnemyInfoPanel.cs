using UnityEngine;
using TMPro;

public class EnemyInfoPanel : MonoBehaviour
{
    public TMP_Text factionNameText;
    public TMP_Text enemyCountText;

    private Player enemy;

    void Start()
    {
        GameObject enemyObject = GameObject.Find("player_ciri");

        if (enemyObject != null)
        {
            enemy = enemyObject.GetComponent<Player>();

            if (enemy != null)
            {
                enemy.OnCardCountChanged += UpdateCardCount;

                UpdateFactionName(enemy.name_fraction);

                UpdateCardCount(enemy.hand_cards.Count);
            }
            else
            {
                Debug.LogError("Player component not found on player_ciri.");
            }
        }
        else
        {
            Debug.LogError("Player object 'player_ciri' not found.");
        }
    }

    private void UpdateFactionName(string factionName)
    {
        if (factionNameText != null)
        {
            factionNameText.text = factionName;
        }
        else
        {
            Debug.LogError("FactionName TextMeshPro component not assigned.");
        }
    }

    public void UpdateCardCount(int cardCount)
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = $"{cardCount}";
        }
        else
        {
            Debug.LogError("EnemyCount TextMeshPro component not assigned.");
        }
    }

    void OnDestroy()
    {
        if (enemy != null)
        {
            enemy.OnCardCountChanged -= UpdateCardCount;
        }
    }
}