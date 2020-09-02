using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public float range, cooldown, curCooldown = 0f;
    public GameObject projectile;
    public Color color;
    public Tower(float range, float curCooldwn,Color color)
    {
        this.range = range;
        cooldown = curCooldwn;
        this.color = color;
    }
}

public class TowerProjectile
{
    public float speed;
    public int damage;
    public Color color;

    public TowerProjectile(float speed, int dmg, Color color)
    {
        this.speed = speed;
        damage = dmg;
        this.color = color;
    }
}

public enum TowerType
{
    FIRST_TOWER,
    SECOND_TOWER
}

public class GameController : MonoBehaviour
{
   public List<GameObject> wayPoints = new List<GameObject>();
   public List<Tower> allTowers = new List<Tower>();
   public List<TowerProjectile>allProjectile = new List<TowerProjectile>();

   private void Awake()
   {
        allTowers.Add(new Tower(4,0.3f,Color.magenta));
        allTowers.Add(new Tower(8,1,Color.yellow));

        allProjectile.Add(new TowerProjectile(11,5,Color.magenta));
        allProjectile.Add(new TowerProjectile(20,40,Color.yellow));
   }
}