using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    public static float ATTACK_DELAY_TIME = 0.4f;
    TypeWeapon type;
    [SerializeField] MeshRenderer rend;
    [SerializeField] GameObject child;
    public bool IsCanAttack => child.activeSelf;

    public TypeWeapon Type
    {
        get { return type; }
        set { type = value; }
    }

    [SerializeField] TypeBullet typeBullet ;

    public override void OnInit()
    {

    }
    public override void OnDespawn()
    {

    }
    
    public void Throw(Character character, Vector3 targetPoint)
    {
        child.SetActive(false);
        Invoke(nameof(SetEnable), ATTACK_DELAY_TIME);
        Bullet bullet = SimplePool.Spawn<Bullet>((PoolType)typeBullet, TF.position, Quaternion.identity);
        bullet.OnInit(character,targetPoint);
        bullet.TF.localScale = Vector3.one;
    }
    
    public void SetEnable()
    {
        child.SetActive(true);
    }
    public void SetMeshRenderer(Material newMaterial)
    {
        for(int i=0; i < rend.materials.Length; i++)
        {
            rend.sharedMaterials[i] = newMaterial;
        }
    }
}
