using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    CharactorType type = CharactorType.Monster;

    // HPを表示させるスライダー
    [SerializeField] protected
    Slider hpSlider;
    // 攻撃した際に発射されるGameObject
    [SerializeField] protected
    GameObject fireBallBullet;
    // 死亡した際に表示するテキスト
    [SerializeField] protected
    GameObject deadText;
    private float interval = 3.0f;

    [SerializeField] private GameObject Player;

    void Start()
    {
        StartCoroutine(Coroutine(interval));

        deadText.SetActive(false);

        hpSlider.maxValue = hp;

        hpSlider.value = hp;
    }

    void Update()
    {
        LookYAxis(Player.transform.position);
    }

    protected override void OnAttack()
    {
        var bullet = Instantiate(fireBallBullet, this.transform);
    }

    private IEnumerator Coroutine(float interval)
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            OnAttack();
        }
    }

    protected override void AddDamage()
    {
        var damage = 10;
        hp -= damage;
        hpSlider.value = hp;
        if (hp <= 0)
        {
            DidDead();
        }
    }

    protected override void DidDead()
    {
        deadText.SetActive(true);
        hpSlider.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            other.gameObject.SetActive(false);
            AddDamage();
        }
    }
}