using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    CharactorType type = CharactorType.Player;

    // キャラクターの移動速度
    [SerializeField]
    float moveSpeed = 3f;
    // キャラクターの回転速度
    [SerializeField]
    float rotateSpeed = 3f;
    // 攻撃した際に発射されるGameObject
    [SerializeField]
    GameObject fireBallBullet;
    // HPを表示させるスライダー
    [SerializeField]
    Slider hpSlider;

    private void Start()
    {

        hpSlider.maxValue = hp;

        hpSlider.value = hp;

    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void Update()
    {
        PlayerRotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnAttack();
        }
    }

    /// <summary>
    /// Playerの移動処理を行うメソッド
    /// </summary>
    private void PlayerMove()
    {
        // 横矢印入力を値で返し変数「horizontal」に格納
        float horizontal = Input.GetAxis("Horizontal");
        // 縦矢印入力を値で返し変数「vertical」に格納
        float vertical = Input.GetAxis("Vertical");
        // 三次元の移動方向量を計算する
        Vector3 moveValue = new Vector3(horizontal, 0, vertical) * Time.fixedDeltaTime * moveSpeed;
        // Playerを移動させる
        transform.Translate(moveValue);
    }

    /// <summary>
    /// Playerの回転処理を行うメソッド
    /// </summary>
    private void PlayerRotate()
    {
        // マウス横軸方向の移動量を取得する
        float horizontal = rotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        // Playerを回転させる
        transform.Rotate(0, horizontal, 0);
    }

    public override void OnAttack()
    {
        var bullet = Instantiate(fireBallBullet, this.transform);
    }

    public override void AddDamage()
    {
        var damage = 10;
        hp -= damage;
        hpSlider.value = hp;
        if(hp <= 0)
        {
            DidDead();
        }
    }

    public override void DidDead()
    {
        Debug.Log("playerが死んだ！");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            other.gameObject.SetActive(false);
            AddDamage();
        }
    }
}
