using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant 
{
    public static string ANIM_IDLE = "idle";
    public static string AMIM_ATTACK = "attack";
    public static string ANIM_DANCE = "dance";
    public static string ANIM_RUN = "run";
    public static string ANIM_WIN = "win";
    public static string ANIM_ULTI = "ulti";
    public static string ANIM_DEAD = "dead";

    public static string TAG_OBSTACLE = "Obstacle";
    public static string TAG_CHARACTER = "Character";
}

public enum TypeColor
{
    Green, Cyan, Yellow, Red, Black, Orange, Blue
}

public enum TypeWeapon
{
    W_Boomerang = PoolType.W_Boomerang,
    W_Uzi = PoolType.W_Uzi,
    W_Candy_0 = PoolType.W_Candy_0,
    W_Candy_1 = PoolType.W_Candy_1,
    W_Candy_2 = PoolType.W_Candy_2,
    W_Candy_3 = PoolType.W_Candy_3,
    W_Knife = PoolType.W_Knife,
    W_Axe = PoolType.W_Axe,
    W_Hammer = PoolType.W_Hammer
}

public enum TypeBullet
{
    B_Boomerang = PoolType.B_Boomerang,
    B_Uzi = PoolType.B_Uzi,
    B_Candy_0 = PoolType.B_Candy_0,
    B_Candy_1 = PoolType.B_Candy_1,
    B_Candy_2 = PoolType.B_Candy_2,
    B_Candy_3 = PoolType.B_Candy_3,
    B_Knife = PoolType.B_Knife,
    B_Axe = PoolType.B_Axe,
    B_Hammer = PoolType.B_Hammer
}
public enum BulletType
{
    Forward,
    Rotate,
    Boomerang
}