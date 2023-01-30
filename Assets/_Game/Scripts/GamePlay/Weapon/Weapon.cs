using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    CounterTime counterTime = new CounterTime();

    private void Update()
    {
        counterTime.Execute();
    }
    public void ResetAttack()
    {
        counterTime.Start(() => SetEnable(), 0.75f);
    }
    public void Throw(Character character, Vector3 targetPoint, float size)
    {
        child.SetActive(false);
        Bullet bullet = SimplePool.Spawn<Bullet>((PoolType)typeBullet, TF.position,TF.rotation);
        bullet.OnInit(character,targetPoint,this,size);
        bullet.TF.localScale = Vector3.one * size;
    }

    public void SetEnable()
    {
        child.SetActive(true);
        LevelManager.Instance.player.IsAttacking = false;
    }
    public void SetMeshRenderer(Material newMaterial)
    {
        for(int i=0; i < rend.materials.Length; i++)
        {
            rend.sharedMaterials[i] = newMaterial;
        }
    }
}
