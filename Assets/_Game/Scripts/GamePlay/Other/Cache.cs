using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{

    private static Dictionary<Collider, IHit> hits = new Dictionary<Collider, IHit>();

    public static IHit GetHit(Collider collider)
    {
        if (!hits.ContainsKey(collider))
        {
            hits.Add(collider, collider.GetComponent<IHit>());
        }
        return hits[collider];
    }

    private static Dictionary<Collider, Character> characters = new Dictionary<Collider, Character>();

    public static Character GetCharacter(Collider collider)
    {
        if (!characters.ContainsKey(collider))
        {
            characters.Add(collider, collider.GetComponent<Character>());
        }
        return characters[collider];
    }

    private static Dictionary<Collider, Bullet> bullets = new Dictionary<Collider, Bullet>();

    public static Bullet GetBullet(Collider collider)
    {
        if (!bullets.ContainsKey(collider))
        {
            bullets.Add(collider, collider.GetComponent<Bullet>());
        }
        return bullets[collider];
    }

    private static Dictionary<Mask, Character> maskCharacters = new Dictionary<Mask, Character>();

    public static Character GetCharacterFromMask(Mask mask)
    {
        if (!maskCharacters.ContainsKey(mask))
        {
            maskCharacters.Add(mask, mask.GetComponent<Character>());
        }
        return maskCharacters[mask];
    }
}
