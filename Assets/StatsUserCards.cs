using UnityEngine;

public class StatsUserCards : MonoBehaviour
{
    public int cards_in_dec;
    public int cards_squad;
    public int cards_special;
    public int total_cards_special;
    public int heroes;

    public void setCardsSquad(int count) { this.cards_squad = count; }
    public void setCardsInDec(int count) { this.cards_in_dec = count; }
    public void setCardsSpecial(int count) { this.cards_special = count; }
    public void setTotalCardStrenght(int count) { this.total_cards_special = count; }
    public void setHeroes(int count) { this.cards_squad = count; }
}
