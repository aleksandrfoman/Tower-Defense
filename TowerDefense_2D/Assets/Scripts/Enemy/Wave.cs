using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy; //Префаб врага
    public int count; //Количество врагов
    public float rate; //Задержка между выходом врагов
}
