using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Character
{
    CharactorType type = CharactorType.Villager;

    // 生成するダイアログに当たるゲームオブジェクト
    [SerializeField]
    GameObject dialogObject;
    // ダイアログを生成するHierarchy上で親関係となるゲームオブジェクト
    [SerializeField]
    Transform canvas;

    [SerializeField] private GameObject Player;


    private void Update()
    {
        LookYAxis(Player.transform.position);
    }

    // ダメージを受けた際の実装例
    /*void ダメージを受けた！()
    {
        SetDialog("表示するテキスト","誰が話しているか");
    }*/

    /// <summary>
    /// ダイヤログへ文字を表示させる処理
    /// </summary>
    /// <param name="content">表示させる内容</param>
    /// <param name="talker">話者</param>
    private void SetDialog(string content, string talker)
    {
        // ダイアログを生成させる
        var dialog = Instantiate(dialogObject, canvas);
        var interval = 3.0f;
        // Dialogクラスを呼び出し、表示処理を実行する
        dialog.GetComponent<Dialog>().DisplayDialog(content, talker);
        Destroy(dialog, interval);
    }

    protected override void OnAttack()
    {
        
    }

    protected override void AddDamage()
    {
        SetDialog("痛い！やめて", "村人A");
    }

    protected override void DidDead()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "EnemyBullet")
        {
            other.gameObject.SetActive(false);
            AddDamage();
        }
    }


}
