using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreateCards : MonoBehaviour
{
    [SerializeField] private Card card;

    public Card createCard(string name, int strenght, string path_to_image, TypeMillitary type, AbilityAbstract ability, int is_hero=0)
    {
        var new_card = new GameObject(name).AddComponent<Card>();
        new_card.initialization(name, strenght, path_to_image, type, ability, is_hero);

        return new_card;
    }


    private List<TypeMillitary> getTypeMillitary()
    {
        List<TypeMillitary> types = new List<TypeMillitary>();
        
        var near = ScriptableObject.CreateInstance<TypeMillitary>();
        var far = ScriptableObject.CreateInstance<TypeMillitary>();
        var siege = ScriptableObject.CreateInstance<TypeMillitary>();
        near.setType(0);
        far.setType(1);
        siege.setType(2);

        types.Add(near);
        types.Add(far);
        types.Add(siege);

        return types;
    }

    public List<Card> getNeutralCards()
    {
        List<Card> cards = new List<Card>();

        List<TypeMillitary> type_m = getTypeMillitary();

        var a_spy = ScriptableObject.CreateInstance<AbilitySpy>();
        var a_no_effects = ScriptableObject.CreateInstance<AbilityNoEffect>();
        var a_double = ScriptableObject.CreateInstance<AbilityDouble>();
        var a_commander_horn = ScriptableObject.CreateInstance<AbilityCommandersHorn>();
        var a_surge_of_sthreght = ScriptableObject.CreateInstance<AbilitySurgeOfSthreght>();
        var a_medic = ScriptableObject.CreateInstance<AbilityMedic>();
        var a_axe = ScriptableObject.CreateInstance<AbilityAxe>();

        cards.Add(createCard("Таинственный эльф", 0, "Assets/Skins/Cards/neutral/tainstvenniy_elf.png", type_m[0], a_spy));
        cards.Add(createCard("Цирилла", 15, "Assets/Skins/Cards/neutral/cirilla.png", type_m[0], a_no_effects));
        cards.Add(createCard("Эмиель Регис", 5, "Assets/Skins/Cards/neutral/emiel_reggis.png", type_m[0], a_no_effects));
        cards.Add(createCard("Геральт из Ривии", 15, "Assets/Skins/Cards/neutral/gerald_iz_rivii.png", type_m[0], a_no_effects));
        cards.Add(createCard("Гюнтер о Дим", 2, "Assets/Skins/Cards/neutral/gunter_o_dim.png", type_m[2], a_double));
        cards.Add(createCard("Гюнтер о Дим: тьма", 4, "Assets/Skins/Cards/neutral/gunter_o_dim_tma.png", type_m[1], a_double));
        cards.Add(createCard("Лютик", 2, "Assets/Skins/Cards/neutral/lutic.png", type_m[0], a_commander_horn));
        cards.Add(createCard("Ольгерд фон Эверек", 6, "Assets/Skins/Cards/neutral/olgerd_fon_everek.png", type_m[0], a_surge_of_sthreght));
        cards.Add(createCard("Трисс Меригольд", 7, "Assets/Skins/Cards/neutral/triss_merigold.png", type_m[0], a_no_effects));
        cards.Add(createCard("Йеннифэр из Венгерберга", 7, "Assets/Skins/Cards/neutral/ueninifer_iz_vengerberga.png", type_m[1], a_medic));
        cards.Add(createCard("Весемир", 6, "Assets/Skins/Cards/neutral/vesemir.png", type_m[0], a_no_effects));
        cards.Add(createCard("Виллентретенмерт", 7, "Assets/Skins/Cards/neutral/villentretenment.png", type_m[0], a_axe));
        cards.Add(createCard("Золтан Хивай", 5, "Assets/Skins/Cards/neutral/zolvan_hivai.png", type_m[0], a_no_effects));

        return cards;
    }

    public List<Card> createCardKingdom()
    {
        List<Card> cards = new List<Card>(getNeutralCards());

        List<TypeMillitary> type_m = getTypeMillitary();

        var a_medic = ScriptableObject.CreateInstance<AbilityMedic>();
        var a_no_effects = ScriptableObject.CreateInstance<AbilityNoEffect>();
        var a_stong_connection = ScriptableObject.CreateInstance<AbilityStrongConnection>();
        var a_spy = ScriptableObject.CreateInstance<AbilitySpy>();
        var a_axe = ScriptableObject.CreateInstance<AbilityAxe>();


        cards.Add(createCard("Баллиста", 6, "Assets/Skins/Cards/kingdom_of_the_north/cards/ballista.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Бьянка", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/bianka.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Боец Синих Полосок", 4, "Assets/Skins/Cards/kingdom_of_the_north/cards/boec_sinix_polosok.jpg", type_m[0], a_stong_connection));
        cards.Add(createCard("Детмольд", 6, "Assets/Skins/Cards/kingdom_of_the_north/cards/detmold.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Гребаная пехтура", 1, "Assets/Skins/Cards/kingdom_of_the_north/cards/grebannaya_pehtura.jpg", type_m[0], a_stong_connection));
        cards.Add(createCard("Каздвенский осадный мастер", 1, "Assets/Skins/Cards/kingdom_of_the_north/cards/kaedvenskiy_osadniy_master.jpg", type_m[2], a_axe));
        cards.Add(createCard("Катапульта", 8, "Assets/Skins/Cards/kingdom_of_the_north/cards/katapylta.jpg", type_m[2], a_stong_connection));
        cards.Add(createCard("Кейра Мец", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/keyra_mec.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Лекарь Бурой Хоругви", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/lekar_byroy_Xorygvi.jpg", type_m[2], a_medic));
        cards.Add(createCard("Осадная башня", 6, "Assets/Skins/Cards/kingdom_of_the_north/cards/osadnaya_bashnya.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Плотва", 3, "Assets/Skins/Cards/kingdom_of_the_north/cards/plotva.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Принц Стеннис", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/princ_stennis.jpg", type_m[0], a_spy));
        cards.Add(createCard("Реданский пехотинец", 1, "Assets/Skins/Cards/kingdom_of_the_north/cards/redanskiy_pehotinec.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Рубайлы из Кринфрида", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/rubaily_iz_Krinfrida.jpg", type_m[1], a_stong_connection));
        cards.Add(createCard("Сабрина Глевиссиг", 4, "Assets/Skins/Cards/kingdom_of_the_north/cards/sabrina_glevissing.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Шеала де Тансервилль", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/seala_de_Tanservill.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Шелдон Скаггс", 4, "Assets/Skins/Cards/kingdom_of_the_north/cards/selfton_skaggs.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Сигизмунд Дийкстра", 4, "Assets/Skins/Cards/kingdom_of_the_north/cards/sigzimund_diykstra.jpg", type_m[0], a_spy));
        cards.Add(createCard("Талер", 1, "Assets/Skins/Cards/kingdom_of_the_north/cards/taler.jpg", type_m[2], a_spy));
        cards.Add(createCard("Требушет", 4, "Assets/Skins/Cards/kingdom_of_the_north/cards/trebyshet.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Ярпен Зигрин", 2, "Assets/Skins/Cards/kingdom_of_the_north/cards/yarpen_zigrin.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Зигфрид из Денесле", 5, "", type_m[0], a_no_effects));
        
        cards.Add(createCard("Эстерад Тиссен", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/esterad_tissen.jpg", type_m[0], a_no_effects, 1));
        cards.Add(createCard("Филиппа Эйльхарт", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/filippa_eilxart.jpg", type_m[1], a_no_effects, 1));
        cards.Add(createCard("Вернон Роше", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/venon_roshe.jpg", type_m[0], a_no_effects, 1));
        cards.Add(createCard("Ян Наталис", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/yan_natalis.jpg", type_m[0], a_no_effects, 1));

        return cards;
    }

    public List<LeaderAbstract> getLeadersKingdomOfTheNorth()
    {

        List<LeaderAbstract> leaders = new List<LeaderAbstract>();
        LeaderKingdomOfTheNorth1 lead1 = new GameObject("Фольтест Железный Владыка").AddComponent< LeaderKingdomOfTheNorth1>();
        LeaderKingdomOfTheNorth2 lead2 = new GameObject("Фольтест Король Темерии").AddComponent<LeaderKingdomOfTheNorth2>();
        LeaderKingdomOfTheNorth3 lead3 = new GameObject("Фольтест Предводитель Севера").AddComponent<LeaderKingdomOfTheNorth3>();
        LeaderKingdomOfTheNorth4 lead4 = new GameObject("Фольтест Сын Меделла").AddComponent<LeaderKingdomOfTheNorth4>();
        LeaderKingdomOfTheNorth5 lead5 = new GameObject("Фольтест Завоеватель").AddComponent<LeaderKingdomOfTheNorth5>();
        leaders.Add(lead1.initialization("Фольтест Железный Владыка", "Assets/Skins/Cards/kingdom_of_the_north/leaders/foltest_jelezniy_vladica.png"));
        leaders.Add(lead2.initialization("Фольтест Король Темерии", "Assets/Skins/Cards/kingdom_of_the_north/leaders/foltest_korol_temerii.png"));
        leaders.Add(lead3.initialization("Фольтест Предводитель Севера", "Assets/Skins/Cards/kingdom_of_the_north/leaders/foltest_predvoditel_severa.png"));
        leaders.Add(lead4.initialization("Фольтест Сын Меделла", "Assets/Skins/Cards/kingdom_of_the_north/leaders/foltest_sin_medela.png"));
        leaders.Add(lead5.initialization("Фольтест Завоеватель", "Assets/Skins/Cards/kingdom_of_the_north/leaders/foltest_zavoevatel.png"));

        return leaders;

    }
}
