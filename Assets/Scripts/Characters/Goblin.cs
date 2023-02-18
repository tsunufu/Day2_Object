using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{

    protected override void OnAttack()
    {
        var bullet = Instantiate(fireBallBullet, this.transform);
        Debug.Log("ゴブリンだって強いんだぞー");
    }

    protected override void AddDamage()
    {
        var damage = 20;
        hp -= damage;
        hpSlider.value = hp;
        if (hp <= 0)
        {
            DidDead();
            Debug.Log("くそー");
        }
    }
}
