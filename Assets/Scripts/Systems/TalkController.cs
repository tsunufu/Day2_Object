using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkController : MonoBehaviour
{
    /// <summary>
    /// 誰が話しているかの話者を指定するEnum
    /// </summary>
    public enum Talker
    {
        Player,
        Buddy,
        Enemy
    }


    /// <summary>
    /// Talkデータを持つ構造体
    /// </summary>
    public struct TalkStruct
    {
        public int id;
        public Talker talker;
        public string contents;

        public TalkStruct(int id, Talker talker, string contents)
        {
            this.id = id;
            this.talker = talker;
            this.contents = contents;
        }
    }

    /// <summary>
    /// TalkStruct型のListを定義する
    /// </summary>
    private List<TalkStruct> talkStructs = new List<TalkStruct>();

    // Start is called before the first frame update
    void Start()
    {
        talkStructs.Add(new TalkStruct(1, Talker.Player, "おはよう"));
        talkStructs.Add(new TalkStruct(2, Talker.Buddy, "今日もいい天気だね"));
        talkStructs.Add(new TalkStruct(3, Talker.Player, "待って，あそこに何かいる"));
        talkStructs.Add(new TalkStruct(4, Talker.Enemy, "がおー"));
        talkStructs.Add(new TalkStruct(5, Talker.Buddy, "うわ！ゴブリンが出てきた！"));

        foreach(TalkStruct talkStruct in talkStructs)
        {
            Debug.Log("Talker: " + talkStruct.talker + ", Contents: " + talkStruct.contents);
        }

    }
}
