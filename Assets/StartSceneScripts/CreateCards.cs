using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CreateCards : MonoBehaviour
{
    [SerializeField] private Card card;

    public Card createCard(
        string name, 
        int strenght, 
        string path_to_image, 
        TypeMillitary type, 
        AbilityAbstract ability, 
        int is_hero = 0,
        float x = 50.0f,
        float y = 50.0f,
        float z = 0.0f
        )
    {
        var new_card = new GameObject(name).AddComponent<Card>();
        new_card.initialization(name, strenght, path_to_image, type, ability, is_hero, x, y, z);

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
        cards.Add(createCard("Эмиель Регис", 5, "Assets/Skins/Cards/neutral/emiel_reggis.png", type_m[0], a_no_effects, 0, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Геральт из Ривии", 15, "Assets/Skins/Cards/neutral/gerald_iz_rivii.png", type_m[0], a_no_effects, 0, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Гюнтер о Дим", 2, "Assets/Skins/Cards/neutral/gunter_o_dim.png", type_m[2], a_double));
        cards.Add(createCard("Гюнтер о Дим: тьма", 4, "Assets/Skins/Cards/neutral/gunter_o_dim_tma.png", type_m[1], a_double));
        cards.Add(createCard("Лютик", 2, "Assets/Skins/Cards/neutral/lutic.png", type_m[0], a_commander_horn));
        cards.Add(createCard("Ольгерд фон Эверек", 6, "Assets/Skins/Cards/neutral/olgerd_fon_everek.png", type_m[0], a_surge_of_sthreght));
        cards.Add(createCard("Трисс Меригольд", 7, "Assets/Skins/Cards/neutral/triss_merigold.png", type_m[0], a_no_effects, 0, 75.0f, 75.0f, 0.0f));
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
        cards.Add(createCard("Осадная башня", 6, "Assets/Skins/Cards/kingdom_of_the_north/cards/osadnaya_bashnya.jpg", type_m[2], a_no_effects, 0, 70.0f, 70.0f, 0.0f));
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
        cards.Add(createCard("Зигфрид из Денесле", 5, "Assets/Skins/Cards/kingdom_of_the_north/cards/zigfrid_is_denesle.jpg", type_m[0], a_no_effects));

        cards.Add(createCard("Эстерад Тиссен", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/esterad_tissen.jpg", type_m[0], a_no_effects, 1, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Филиппа Эйльхарт", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/filippa_eilxart.jpg", type_m[1], a_no_effects, 1));
        cards.Add(createCard("Вернон Роше", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/venon_roshe.jpg", type_m[0], a_no_effects, 1));
        cards.Add(createCard("Ян Наталис", 10, "Assets/Skins/Cards/kingdom_of_the_north/heroes/yan_natalis.jpg", type_m[0], a_no_effects, 1));

        return cards;
    }

    public List<LeaderAbstract> getLeadersKingdomOfTheNorth()
    {
        List<LeaderAbstract> leaders = new List<LeaderAbstract>();
        LeaderKingdomOfTheNorth1 lead1 = new GameObject("Фольтест Железный Владыка").AddComponent<LeaderKingdomOfTheNorth1>();
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

    public List<Card> createCardNilfgaard()
    {
        List<Card> cards = new List<Card>(getNeutralCards());

        List<TypeMillitary> type_m = getTypeMillitary();

        var a_no_effects = ScriptableObject.CreateInstance<AbilityNoEffect>();
        var a_stong_connection = ScriptableObject.CreateInstance<AbilityStrongConnection>();
        var a_medic = ScriptableObject.CreateInstance<AbilityMedic>();
        var a_spy = ScriptableObject.CreateInstance<AbilitySpy>();

        cards.Add(createCard("Альбрых", 2, "Assets/Skins/Cards/Nilfgaard/cards/Albrih.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Ассире вар Анагыд", 6, "Assets/Skins/Cards/Nilfgaard/cards/Assire_var_Anagid.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Бол. огненный скорпион", 10, "Assets/Skins/Cards/Nilfgaard/cards/bol_ognenniy_scorpion.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Бригада \"Импера\"", 3, "Assets/Skins/Cards/Nilfgaard/cards/brigada_Impera.jpg", type_m[0], a_stong_connection));
        cards.Add(createCard("Цинтия", 4, "Assets/Skins/Cards/Nilfgaard/cards/Cintiya.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Фрингилья Виго", 6, "Assets/Skins/Cards/Nilfgaard/cards/Fringilya_Vigo.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Кагыр Маур аэп Кеаллах", 6, "Assets/Skins/Cards/Nilfgaard/cards/Kagir_Mayr_aep_Keallax.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Кавалерия \"Наузикаа\"", 2, "Assets/Skins/Cards/Nilfgaard/cards/kavaleriya_Nayzikaa.jpg", type_m[0], a_stong_connection));
        cards.Add(createCard("Лучник Бурой Хоругви", 10, "Assets/Skins/Cards/Nilfgaard/cards/luchnik_byroi_xorygvi.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Лучная поддержка", 1, "Assets/Skins/Cards/Nilfgaard/cards/Lychnaya_podderjka.jpg", type_m[1], a_medic));
        cards.Add(createCard("Молодой посланник", 5, "Assets/Skins/Cards/Nilfgaard/cards/molodoy_poslannik.jpg", type_m[0], a_stong_connection));
        cards.Add(createCard("Мортейзен", 3, "Assets/Skins/Cards/Nilfgaard/cards/Morteyzen.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Огненный скорпион", 5, "Assets/Skins/Cards/Nilfgaard/cards/ognenniy_scorpion.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Осадная поддержка", 0, "Assets/Skins/Cards/Nilfgaard/cards/osadnaya_podderjka.jpg", type_m[2], a_medic));
        cards.Add(createCard("Путткаммер", 3, "Assets/Skins/Cards/Nilfgaard/cards/Putkammer.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Раинфарн", 4, "Assets/Skins/Cards/Nilfgaard/cards/Rainfarn.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Ренуальд аэп Матсен", 5, "Assets/Skins/Cards/Nilfgaard/cards/Renyald_aep_Matsen.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Сапер", 6, "Assets/Skins/Cards/Nilfgaard/cards/saper.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Сгнившая петрария", 3, "Assets/Skins/Cards/Nilfgaard/cards/sgnivshaya_petrariya.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Шилярд Фиц-Остерлен", 7, "Assets/Skins/Cards/Nilfgaard/cards/Shilyard_Fic_Osterlen.jpg", type_m[0], a_spy));
        cards.Add(createCard("Стефан Скеллен", 9, "Assets/Skins/Cards/Nilfgaard/cards/Stefan_Skellen.jpg", type_m[0], a_spy));
        cards.Add(createCard("Свирс", 2, "Assets/Skins/Cards/Nilfgaard/cards/Svirs.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Вангемар", 4, "Assets/Skins/Cards/Nilfgaard/cards/Vangemar.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Ваттье де Ридо", 4, "Assets/Skins/Cards/Nilfgaard/cards/Vattie_de_Rido.jpg", type_m[0], a_spy));
        cards.Add(createCard("Вреемде", 2, "Assets/Skins/Cards/Nilfgaard/cards/Vreemde.jpg", type_m[0], a_no_effects));

        cards.Add(createCard("Лето из Гулеты", 10, "Assets/Skins/Cards/Nilfgaard/heroes/leto_iz_Gyleti.jpg", type_m[0], a_no_effects, 1));
        cards.Add(createCard("Менно Коегоорн", 10, "Assets/Skins/Cards/Nilfgaard/heroes/Menno_Koegoorn.jpg", type_m[0], a_medic, 1));
        cards.Add(createCard("Морвран Воорхис", 10, "Assets/Skins/Cards/Nilfgaard/heroes/Morvran_Voorxis.jpg", type_m[2], a_no_effects, 1));
        cards.Add(createCard("Тибор Эггебрахт", 10, "Assets/Skins/Cards/Nilfgaard/heroes/Tibor_Eggebraxt.jpg", type_m[1], a_no_effects, 1));

        return cards;
    }

    public List<LeaderAbstract> getLeadersNilfgaard()
    {

        List<LeaderAbstract> leaders = new List<LeaderAbstract>();

        LeaderNilfgaard1 lead1 = new GameObject("Эмгыр вар Эмрейс Белое Пламя").AddComponent<LeaderNilfgaard1>();
        LeaderNilfgaard2 lead2 = new GameObject("Эмгыр вар Эмрейс Император Нильфгаарда").AddComponent<LeaderNilfgaard2>();
        LeaderNilfgaard3 lead3 = new GameObject("Эмгыр вар Эмрейс Йож из Эрленвальда").AddComponent<LeaderNilfgaard3>();
        LeaderNilfgaard4 lead4 = new GameObject("Эмгыр вар Эмрейс Властелин Юга").AddComponent<LeaderNilfgaard4>();

        leaders.Add(lead1.initialization("Эмгыр вар Эмрейс Белое Пламя", "Assets/Skins/Cards/Nilfgaard/leaders/Emgir_var_emreys_beloe_plamya.jpg"));
        leaders.Add(lead2.initialization("Эмгыр вар Эмрейс Император Нильфгаарда", "Assets/Skins/Cards/Nilfgaard/leaders/Emgir_var_emreys_imperator_Nilfgaarda.jpg"));
        leaders.Add(lead3.initialization("Эмгыр вар Эмрейс Йож из Эрленвальда", "Assets/Skins/Cards/Nilfgaard/leaders/Emgir_var_emreys_ioz_is_Erlevalda.jpg"));
        leaders.Add(lead4.initialization("Эмгыр вар Эмрейс Властелин Юга", "Assets/Skins/Cards/Nilfgaard/leaders/Emgir_var_emreys_vlastelin_uga.jpg"));


        return leaders;
    }

    public List<Card> createCardMonsters()
    {
        List<Card> cards = new List<Card>(getNeutralCards());

        List<TypeMillitary> type_m = getTypeMillitary();

        var a_no_effects = ScriptableObject.CreateInstance<AbilityNoEffect>();
        var a_axe = ScriptableObject.CreateInstance<AbilityAxe>();
        var a_double = ScriptableObject.CreateInstance<AbilityDouble>();

        cards.Add(createCard("Бес", 6, "Assets/Skins/Cards/monsters/cards/bes.jpg", type_m[0], a_no_effects, 0, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Элементаль огня", 6, "Assets/Skins/Cards/monsters/cards/elemental_ognya.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Элементаль земли", 6, "Assets/Skins/Cards/monsters/cards/elemental_zemli.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Эндриага", 2, "Assets/Skins/Cards/monsters/cards/endriaga.jpg", type_m[1], a_no_effects, 0, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Гаргулья", 2, "Assets/Skins/Cards/monsters/cards/garguliya.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Главоглаз", 4, "Assets/Skins/Cards/monsters/cards/glavoglaz.jpg", type_m[0], a_double));
        cards.Add(createCard("Грифон", 5, "Assets/Skins/Cards/monsters/cards/griffon.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Гуль", 1, "Assets/Skins/Cards/monsters/cards/gul.jpg", type_m[0], a_double));
        cards.Add(createCard("Игоша", 4, "Assets/Skins/Cards/monsters/cards/igosha.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Кладбищенская баба", 5, "Assets/Skins/Cards/monsters/cards/kladbishenskaya_baba.jpg", type_m[1], a_no_effects, 0, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Ледяной Великан", 5, "Assets/Skins/Cards/monsters/cards/ledyanoy_velikan.jpg", type_m[2], a_no_effects));
        cards.Add(createCard("Моровая дева", 5, "Assets/Skins/Cards/monsters/cards/morovaya_deva.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Накер", 2, "Assets/Skins/Cards/monsters/cards/naker.jpg", type_m[0], a_double, 0, 70.0f, 70.0f, 0.0f));
        cards.Add(createCard("Огромный главоглаз", 6, "Assets/Skins/Cards/monsters/cards/ogromniy_glavoglaz.jpg", type_m[2], a_double));
        cards.Add(createCard("Пугач", 5, "Assets/Skins/Cards/monsters/cards/pugach.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Туманник", 2, "Assets/Skins/Cards/monsters/cards/tymannik.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Вампиры: брукса", 4, "Assets/Skins/Cards/monsters/cards/vampiry_bruksa.jpg", type_m[0], a_double));
        cards.Add(createCard("Вампиры: экимма", 4, "Assets/Skins/Cards/monsters/cards/vampiry_ecimma.jpg", type_m[0], a_double));
        cards.Add(createCard("Вампиры: фледер", 4, "Assets/Skins/Cards/monsters/cards/vampiry_fleder.jpg", type_m[0], a_double));
        cards.Add(createCard("Вампиры: гаркаин", 4, "Assets/Skins/Cards/monsters/cards/vampiry_garkain.jpg", type_m[0], a_double));
        cards.Add(createCard("Вампиры: катакан", 4, "Assets/Skins/Cards/monsters/cards/vampiry_katacan.jpg", type_m[0], a_double));
        cards.Add(createCard("Василиск", 2, "Assets/Skins/Cards/monsters/cards/vasilisk.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Ведьма: Кухарка", 6, "Assets/Skins/Cards/monsters/cards/vedma_kuharka.jpg", type_m[0], a_double));
        cards.Add(createCard("Ведьма: Пряха", 6, "Assets/Skins/Cards/monsters/cards/vedma_prahua.jpg", type_m[0], a_double));
        cards.Add(createCard("Ведьма: Шептуха", 6, "Assets/Skins/Cards/monsters/cards/vedma_sheptuha.jpg", type_m[0], a_double));
        cards.Add(createCard("Вилохвост", 5, "Assets/Skins/Cards/monsters/cards/viloxvost.jpg", type_m[0], a_no_effects, 0, 75.0f, 75.0f, 0.0f));
        cards.Add(createCard("Виверна", 2, "Assets/Skins/Cards/monsters/cards/viverna.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Волколак", 5, "Assets/Skins/Cards/monsters/cards/volkolap.jpg", type_m[0], a_no_effects));

        cards.Add(createCard("Драуг", 10, "Assets/Skins/Cards/monsters/heroes/draugr.jpg", type_m[0], a_no_effects, 1));
        cards.Add(createCard("Имлерих", 10, "Assets/Skins/Cards/monsters/heroes/implerix.jpg", type_m[0], a_no_effects, 1));
        cards.Add(createCard("Кейран", 8, "Assets/Skins/Cards/monsters/heroes/keyran.jpg", type_m[0], a_axe, 1));
        cards.Add(createCard("Леший", 10, "Assets/Skins/Cards/monsters/heroes/leshiy.jpg", type_m[1], a_no_effects, 1));

        cards.Add(createCard("Гниющенко", 100, "Assets/Skins/govnushenko_card.jpg", type_m[2], a_no_effects, 1));

        return cards;
    }

    public List<LeaderAbstract> getLeadersMonsters()
    {
        List<LeaderAbstract> leaders = new List<LeaderAbstract>();

        LeaderMonsters1 lead1 = new GameObject("Эредин Бреакк Глас Командир Дикой Охоты").AddComponent<LeaderMonsters1>();
        LeaderMonsters2 lead2 = new GameObject("Эредин Бреакк Глас Король Aen Elle").AddComponent<LeaderMonsters2>();
        LeaderMonsters3 lead3 = new GameObject("Эредин Бреакк Глас Король Aen Elle").AddComponent<LeaderMonsters3>();
        LeaderMonsters4 lead4 = new GameObject("Эредин Бреакк Глас Убийца Оберона").AddComponent<LeaderMonsters4>();

        leaders.Add(lead1.initialization("Эредин Бреакк Глас Командир Дикой Охоты", "Assets/Skins/Cards/monsters/leaders/eredin_breakk_glas_komandir_dikoy_ohoti.jpg"));
        leaders.Add(lead2.initialization("Эредин Бреакк Глас Король Aen Elle", "Assets/Skins/Cards/monsters/leaders/eredin_breakk_glas_korol_aen_elle.jpg"));
        leaders.Add(lead3.initialization("Эредин Бреакк Глас Король Aen Elle", "Assets/Skins/Cards/monsters/leaders/eredin_breakk_glas_korol_aen_elle_2.jpg"));
        leaders.Add(lead4.initialization("Эредин Бреакк Глас Убийца Оберона", "Assets/Skins/Cards/monsters/leaders/eredin_breakk_glas_ybiyca_Oberona.jpg"));

        return leaders;
    }

    public List<Card> createCardScoiatael()
    {
        List<Card> cards = new List<Card>(getNeutralCards());

        List<TypeMillitary> type_m = getTypeMillitary();

        var a_no_effects = ScriptableObject.CreateInstance<AbilityNoEffect>();
        var a_double = ScriptableObject.CreateInstance<AbilityDouble>();
        var a_medic = ScriptableObject.CreateInstance<AbilityMedic>();
        var a_axe = ScriptableObject.CreateInstance<AbilityAxe>();

        cards.Add(createCard("Деннис Кранмер", 6, "Assets/Skins/Cards/skoyataeli/cards/dennis_kranmer.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Эльфский застрельщик", 2, "Assets/Skins/Cards/skoyataeli/cards/elfiyskiy_zastrelshik.jpg", type_m[1], a_double, 0, 75.0f, 75.0f, 0.0f));
        cards.Add(createCard("Ида Эмеан", 6, "Assets/Skins/Cards/skoyataeli/cards/ida_emean.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Кадет \"Врихедда\"", 4, "Assets/Skins/Cards/skoyataeli/cards/kadet_vrixedda.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Краснолюд-застрельщик", 3, "Assets/Skins/Cards/skoyataeli/cards/krasnolyd_zastrelshik.jpg", type_m[0], a_double));
        cards.Add(createCard("Лекарь-гавенкар", 0, "Assets/Skins/Cards/skoyataeli/cards/lekar_gavenkar.jpg", type_m[1], a_medic));
        cards.Add(createCard("Лучник из Дол Блатанны", 4, "Assets/Skins/Cards/skoyataeli/cards/lychnik_iz_dol_blatanny.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Махакамские добровольцы", 5, "Assets/Skins/Cards/skoyataeli/cards/maxakamskie_dobrovolci.jpg", type_m[0], a_no_effects));
        cards.Add(createCard("Мильва", 10, "Assets/Skins/Cards/skoyataeli/cards/milva.jpg", type_m[1], a_axe));
        cards.Add(createCard("Поддержка гавенкаров", 5, "Assets/Skins/Cards/skoyataeli/cards/podderjka_gavenkarov.jpg", type_m[0], a_double));
        cards.Add(createCard("Риордаин", 1, "Assets/Skins/Cards/skoyataeli/cards/riordain.jpg", type_m[1], a_no_effects));
        cards.Add(createCard("Торувьель", 2, "Assets/Skins/Cards/skoyataeli/cards/toryviel.jpg", type_m[1], a_no_effects));

        cards.Add(createCard("Эитнэ", 10, "Assets/Skins/Cards/skoyataeli/heroes/eitne.jpg", type_m[1], a_no_effects, 1));
        cards.Add(createCard("Иорвет", 10, "Assets/Skins/Cards/skoyataeli/heroes/iorvet.jpg", type_m[1], a_no_effects, 1));
        cards.Add(createCard("Изенгрим Фаоильтиарна", 10, "Assets/Skins/Cards/skoyataeli/heroes/izengim_faoiltiarna.jpg", type_m[1], a_no_effects, 1));


        return cards;
    }

    public List<LeaderAbstract> getLeadersScoiatael()
    {
        List<LeaderAbstract> leaders = new List<LeaderAbstract>();

        LeaderScoiatael1 lead1 = new GameObject("Францеска Финдабаир Истинная эльфка").AddComponent<LeaderScoiatael1>();
        LeaderScoiatael2 lead2 = new GameObject("Францеска Финдабаир Королева Дол Блатанны").AddComponent<LeaderScoiatael2>();
        LeaderScoiatael3 lead3 = new GameObject("Францеска Финдабаир Маргаритка из Долин").AddComponent<LeaderScoiatael3>();
        LeaderScoiatael4 lead4 = new GameObject("Францеска Финдабаир Прекраснейшая").AddComponent<LeaderScoiatael4>();

        leaders.Add(lead1.initialization("Францеска Финдабаир Истинная эльфка", "Assets/Skins/Cards/skoyataeli/leaders/franceska_fundabair_istinnaya_elfka.jpg"));
        leaders.Add(lead2.initialization("Францеска Финдабаир Королева Дол Блатанны", "Assets/Skins/Cards/skoyataeli/leaders/franceska_fundabair_koroleva_dol_blatanni.jpg"));
        leaders.Add(lead3.initialization("Францеска Финдабаир Маргаритка из Долин", "Assets/Skins/Cards/skoyataeli/leaders/franceska_fundabair_margaritka_iz_dolin.jpg"));
        leaders.Add(lead4.initialization("Францеска Финдабаир Прекраснейшая", "Assets/Skins/Cards/skoyataeli/leaders/franceska_fundabair_prekrasneyshaya.jpg"));

        return leaders;
    }
    
    public List<Card> createWeatherCards()
    {
        List<Card> cards = new List<Card>();

        List<TypeMillitary> type_m = getTypeMillitary();


        return cards;
    }
}
