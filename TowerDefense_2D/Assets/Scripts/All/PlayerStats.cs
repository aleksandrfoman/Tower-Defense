using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerStats
{
    public static int Money; // Game money
    public int startMoney = 400;
    public static int Lives = 0;
    public int startLives = 20;

    public static int Rounds;
    public static bool isGameOver = false;
    public void Init()
    {
        Lives = startLives;
        Money = startMoney;
        isGameOver = false;
        Rounds = 0;
    }
}
