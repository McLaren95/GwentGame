using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private CreateFractions create_fractions;
    public Button button;

    public void OnButtonClick()
    {
        if (create_fractions.selected_fraction.dec_cards.Count > 10)
        {
            GameObject player1_ = new GameObject("player_geralt");
            var player1 = player1_.AddComponent<Player>();
            player1.initialization(create_fractions.selected_fraction, "geralt", "Assets/Skins/Cards/skoyataeli/heroes/saesentessis_files/geralt.jpg");

            GameObject player2_ = new GameObject("player_ciri");
            var player2 = player2_.AddComponent<Player>();

            create_fractions.nextFraction();

            for(int i = 0; i < create_fractions.selected_fraction.cards_collection.Count; i++)
            {
                create_fractions.selected_fraction.MoveToDeck(create_fractions.selected_fraction.cards_collection[i]);
            }

            player2.initialization(create_fractions.selected_fraction, "ciri", "Assets/Skins/Cards/skoyataeli/heroes/saesentessis_files/ciri.jpg");

            SceneManager.LoadScene("GameField");
        }
    }

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
}
