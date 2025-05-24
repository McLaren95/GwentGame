using UnityEngine;


public class GwentRound : MonoBehaviour
{
    public Player player1;
    public Line p1_line_melee;
    public Line p1_line_ranged;
    public Line p1_line_siege;

    public Line weather_line;

    public Player player2;
    public Line p2_line_melee;
    public Line p2_line_ranged;
    public Line p2_line_siege;

    public int number_round;
    

    private string get_name_line(string type_m, string player)
    {
        string name = "";
        if (type_m == "Ближний")
        {
            name = player + "MeleeRow";
        }
        else if (type_m == "Дальний")
        {
            name = player + "RangedRow";
        }
        else if (type_m == "Погода")
        {
            name = "WeatherField";
        }
        else
        {
            name = player + "SiegeRow";
        }

        return name;
    }


    private Line create_line(string player, int type_int)
    {
        var type_ = ScriptableObject.CreateInstance<TypeMillitary>();
        type_.setType(type_int);

        string name_line = this.get_name_line(type_.getType(), player);


        GameObject obj_line = GameObject.Find(name_line);
        Line line = obj_line.AddComponent<Line>();
        line.initialization(type_);

        return line;
    }

    public void initialization(
        int number, 
        Player player1,
        Player player2
        )
    {
        this.number_round = number;
        this.player1 = player1;
        this.player2 = player2;

        p1_line_melee = create_line("Player", 0);
        p1_line_ranged = create_line("Player", 1);
        p1_line_siege = create_line("Player", 2);

        weather_line = create_line("WeatherField", 3);

        p2_line_melee = create_line("Enemy", 0);
        p2_line_ranged = create_line("Enemy", 1);
        p2_line_siege = create_line("Enemy", 2);
    }
}
