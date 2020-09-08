using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; // Деньги игровые
    public int startMoney = 400; // Начальные деньги
    public static int Lives; //Жизни
    public int startLives = 20; //Начальные жизни
    public static int Rounds; //Раунды

    private void Start()
    {
        Lives = startLives;
        Money = startMoney;

        Rounds = 0;
    }
}
