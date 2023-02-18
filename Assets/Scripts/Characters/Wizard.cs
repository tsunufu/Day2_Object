using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    protected override void OnAttack()
    {
        var bullet = Instantiate(fireBallBullet, this.transform);
        Debug.Log("私はウィザードです");
    }

    protected override void AddDamage()
    {
        var damage = 10;
        hp -= damage;
        hpSlider.value = hp;
        if (hp <= 0)
        {
            DidDead();
            Debug.Log("またお会いしましょう...");
        }
    }
}
