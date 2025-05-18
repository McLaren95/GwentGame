using UnityEngine;
using TMPro;

public class PlayerInfoPanel : MonoBehaviour
{
    public TMP_Text factionNameText;
    public TMP_Text playerCountText;

    private Player player;

    void Start()
    {
        GameObject playerObject = GameObject.Find("player_geralt");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();

            if (player != null)
            {
                // Подписываемся на событие изменения количества карт
                player.OnCardCountChanged += UpdateCardCount;

                UpdateFactionName(player.name_fraction);

                UpdateCardCount(player.hand_cards.Count);
            }
            else
            {
                Debug.LogError("Player component not found on player_geralt.");
            }
        }
        else
        {
            Debug.LogError("Player object 'player_geralt' not found.");
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
        if (playerCountText != null)
        {
            playerCountText.text = $"{cardCount}";
        }
        else
        {
            Debug.LogError("PlayerCount TextMeshPro component not assigned.");
        }
    }

    void OnDestroy()
    {
        if (player != null)
        {
            player.OnCardCountChanged -= UpdateCardCount;
        }
    }
}