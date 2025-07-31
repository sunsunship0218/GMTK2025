using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterData ", menuName = "GameFile/Monster Document")]
public class MonsterData: ScriptableObject
{
    public string monsterName;

    [TextArea(3, 10)]
    public string Text;
    // �i��G�Ψ���ܩǪ��Y��
    public Sprite monsterPortrait;
    // �i��G�ΨӼ��񦺤`���ĩΥx��
    public AudioClip deathVoiceClip; 
}
