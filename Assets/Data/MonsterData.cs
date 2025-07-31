using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterData ", menuName = "GameFile/Monster Document")]
public class MonsterData: ScriptableObject
{
    public string monsterName;

    [TextArea(3, 10)]
    public string Text;
    // 可選：用來顯示怪物頭像
    public Sprite monsterPortrait;
    // 可選：用來播放死亡音效或台詞
    public AudioClip deathVoiceClip; 
}
