using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSight : MonoBehaviour
{
    [SerializeField] Character character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            Character target = Cache.GetCharacter(other);
            if (!target.IsDead)
            {
                character.AddTarget(target);
                if (character is Player)
                {
                    Character bot = character.FindTargetInRange();
                    if ((character as Player).currentMask != (bot as Bot).MaskBot)
                    {
                        if ((character as Player).currentMask != null)
                        {
                            (character as Player).currentMask.SetEnable(false);
                        }
                        (character as Player).currentMask = (bot as Bot).MaskBot;
                        (character as Player).currentMask.SetEnable(true);
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            Character target = Cache.GetCharacter(other);
            character.RemoveTarget(target);
            if (character is Player)
            {
                (target as Bot).MaskBot.SetEnable(false);
                if((character as Player).currentMask == (target as Bot).MaskBot)
                {
                    (character as Player).currentMask = null;
                }
            }
        }
    }
}
