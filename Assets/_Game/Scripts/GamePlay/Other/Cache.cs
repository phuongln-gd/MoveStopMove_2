using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{
    private static Dictionary<Collider, Character> characters = new Dictionary<Collider, Character>();

    public static Character GetCharacter(Collider collider)
    {
        if (!characters.ContainsKey(collider))
        {
            characters.Add(collider, collider.GetComponent<Character>());
        }
        return characters[collider];
    }

    /*private static Dictionary<Mask, Character> maskCharacters = new Dictionary<Mask, Character>();

    public static Character GetCharacterFromMask(Mask mask)
    {
        if (!maskCharacters.ContainsKey(mask))
        {
            maskCharacters.Add(mask, mask.GetComponent<Character>());
        }
        return maskCharacters[mask];
    }*/
}
