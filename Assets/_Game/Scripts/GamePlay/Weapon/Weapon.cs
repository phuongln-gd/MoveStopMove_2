using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    public static float ATTACK_DELAY_TIME = 0.5f;
    TypeWeapon type;
    [SerializeField] MeshRenderer rend;

    public bool IsCanAttack => rend.gameObject.activeSelf;
    public TypeWeapon Type
    {
        get { return type; }
        set { type = value; }
    }

    [SerializeField] BulletType bulletType;

    public override void OnInit()
    {

    }
    public override void OnDespawn()
    {

    }

    public void Throw(Character character, Vector3 targetPoint, float size)
    {
        Bullet bullet = SimplePool.Spawn<Bullet>((PoolType)bulletType, TF.position, Quaternion.identity);
        bullet.OnInit(character,targetPoint,size);
        bullet.TF.localScale = size * Vector3.one;
        rend.gameObject.SetActive(false);
        Invoke(nameof(SetEnable),ATTACK_DELAY_TIME);
    }
    
    public void SetEnable()
    {
        rend.gameObject.SetActive(true);
    }
    public void SetMeshRenderer(Material newMaterial)
    {
        for(int i=0; i < rend.materials.Length; i++)
        {
            rend.sharedMaterials[i] = newMaterial;
        }
    }
}
