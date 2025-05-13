using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private CreateFractions create_fractions;
    public Button button;


    public void OnButtonClick()
    { 
        GameObject player1_ = new GameObject("player_geralt");
        var player1 = player1_.AddComponent<Player>();
        player1.initialization(create_fractions.selected_fraction, "geralt", "Assets/Skins/Cards/skoyataeli/heroes/saesentessis_files/geralt.jpg");


        GameObject player2_ = new GameObject("player_ciri");
        var player2 = player2_.AddComponent<Player>();
        player2.initialization(create_fractions.selected_fraction, "ciri", "Assets/Skins/Cards/skoyataeli/heroes/saesentessis_files/ciri.jpg");

        //for (int i = 0; i < create_fractions.selected_fraction.dec_cards.Count; i++)
        //{
        //    DontDestroyOnLoad(create_fractions.selected_fraction.dec_cards[i]);
        //}

        //for (int i = 0; i < create_fractions.selected_fraction.dec_cards.Count; i++)
        //{
        //    DontDestroyOnLoad(create_fractions.selected_fraction.dec_cards[i]);
        //}

        SceneManager.LoadScene("GameField");
    }

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
}
