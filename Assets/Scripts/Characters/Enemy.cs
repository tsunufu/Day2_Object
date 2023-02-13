using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // HPを表示させるスライダー
    [SerializeField]
    Slider hpSlider;
    // 攻撃した際に発射されるGameObject
    [SerializeField]
    GameObject fireBallBullet;
    // 死亡した際に表示するテキスト
    [SerializeField]
    GameObject deadText;

    void Start()
    {
        
    }

    void Update()
    {

    }
}