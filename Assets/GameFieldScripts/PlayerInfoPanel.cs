using UnityEngine;
using TMPro;

public class PlayerInfoPanel : MonoBehaviour
{
    void Start()
    {
        GameObject playerObject = GameObject.Find("player_geralt");

        if (playerObject != null)
        {
            Player player = playerObject.GetComponent<Player>();

            if (player != null)
            {
                string playerFactionName = player.name_fraction;

                GameObject playerInfoPanel = GameObject.Find("PlayerInfoPanel");

                if (playerInfoPanel != null)
                {
                    Transform factionNameTransform = playerInfoPanel.transform.Find("FactionName");

                    if (factionNameTransform != null)
                    {
                        TMP_Text textMeshPro = factionNameTransform.GetComponent<TMP_Text>();

                        if (textMeshPro != null)
                        {
                            textMeshPro.text = playerFactionName;
                        }
                        else
                        {
                            Debug.LogError("TextMeshPro component not found on FactionName.");
                        }
                    }
                    else
                    {
                        Debug.LogError("FactionName object not found inside PlayerInfoPanel.");
                    }
                }
                else
                {
                    Debug.LogError("PlayerInfoPanel object not found in the scene.");
                }
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
}