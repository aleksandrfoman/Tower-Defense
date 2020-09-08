using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerStats : MonoBehaviour
{
    public static int Money; // Деньги игровые
    public int startMoney = 400; // Начальные деньги
    public static int Lives = 0; //Жизни
    public int startLives = 20; //Начальные жизни

    public static int Rounds; //Раунды
    public static bool isGameOver = false;
    private void Start()
    {
        Lives = startLives;
        Money = startMoney;
        isGameOver = false;
        Rounds = 0;
    }
}
