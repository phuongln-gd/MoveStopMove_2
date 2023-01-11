using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : GameUnit
{
    [SerializeField] Animator anim;
    public Animator Anim => anim;

    [SerializeField] SkinnedMeshRenderer colorBody;

    [SerializeField] Transform weaponPosition;

    Weapon currentWeapon;
    public Weapon CurrentWeapon => currentWeapon;
    public override void OnInit()
    {

    }

    public override void OnDespawn()
    {

    }

    public void ChangeWeapon(TypeWeapon newWeapon)
    {
        if(currentWeapon != null)
        {
            SimplePool.Despawn(currentWeapon);
        }
        currentWeapon = SimplePool.Spawn<Weapon>((PoolType)newWeapon,weaponPosition.position,weaponPosition.rotation);
        currentWeapon.transform.SetParent(weaponPosition);
    }
    public void ChangeColorBody(TypeColor color)
    {
        colorBody.material.color = GameManager.Instance.colorData.GetMaterialColor(color).color;
    }
}
