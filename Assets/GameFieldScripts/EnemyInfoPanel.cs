using UnityEngine;
using TMPro;

public class EnemyInfoPanel : MonoBehaviour
{
    void Start()
    {
        GameObject enemyObject = GameObject.Find("player_ciri");

        if (enemyObject != null)
        {
            Player enemy = enemyObject.GetComponent<Player>();

            if (enemy != null)
            {
                string enemyFactionName = enemy.name_fraction;

                GameObject enemyInfoPanel = GameObject.Find("EnemyInfoPanel");

                if (enemyInfoPanel != null)
                {
                    Transform factionNameTransform = enemyInfoPanel.transform.Find("EnemyFactionName");

                    if (factionNameTransform != null)
                    {
                        TMP_Text textMeshPro = factionNameTransform.GetComponent<TMP_Text>();

                        if (textMeshPro != null)
                        {
                            textMeshPro.text = enemyFactionName;
                        }
                        else
                        {
                            Debug.LogError("TextMeshPro component not found on EnemyFactionName.");
                        }
                    }
                    else
                    {
                        Debug.LogError("EnemyFactionName object not found inside EnemyInfoPanel.");
                    }
                }
                else
                {
                    Debug.LogError("EnemyInfoPanel object not found in the scene.");
                }
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
}