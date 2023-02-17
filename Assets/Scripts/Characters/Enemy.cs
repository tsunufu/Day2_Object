using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    CharactorType type = CharactorType.Monster;

    // HPを表示させるスライダー
    [SerializeField]
    Slider hpSlider;
    // 攻撃した際に発射されるGameObject
    [SerializeField]
    GameObject fireBallBullet;
    // 死亡した際に表示するテキスト
    [SerializeField]
    GameObject deadText;
    private float interval = 3.0f;
    private float timeElapsed;

    [SerializeField] private GameObject Player;

    void Start()
    {

        deadText.SetActive(false);

        hpSlider.maxValue = hp;

        hpSlider.value = hp;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= interval)
        {
            OnAttack();

            timeElapsed = 0.0f;
        }

        LookYAxis(Player.transform.position);
    }

    public override void OnAttack()
    {
        var bullet = Instantiate(fireBallBullet, this.transform);
    }

    public override void AddDamage()
    {
        hp -= 10;
        hpSlider.value = hp;
        if (hp <= 0)
        {
            DidDead();
        }
    }

    public override void DidDead()
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