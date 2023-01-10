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

    public static string TAG_OBSTACLE = "Obstacle";
    public static string TAG_CHARACTER = "Character";
}

public enum TypeColor
{
    Green, Cyan, Yellow, Red, Black, Orange, Blue
}

public enum TypeWeapon
{
    Boomerang =PoolType.Boomerang,
    Uzi = PoolType.Uzi,
    Candy_0 = PoolType.Candy_0,
    Candy_1 = PoolType.Candy_1,
    Candy_2 = PoolType.Candy_2,
    Candy_3 = PoolType.Candy_3,
    Knife = PoolType.Knife,
    Axe = PoolType.Axe,
    Hammer = PoolType.Hammer
}