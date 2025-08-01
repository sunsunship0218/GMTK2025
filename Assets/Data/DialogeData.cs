using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogeData ", menuName = "Data/Dialoge")]
public class DialogeData : ScriptableObject
{
    [TextArea]
    public string NPCName;
    public Sprite NPCSprite;
    public string PlayerName;
    public Sprite PlayerSprite;
    public List<DialogueLine> dialogueLines;
   // public bool[] autoProgressLine;
    public float autoProgressDelay = 1.5f;
    public float typingSeed=0.05f;
    public AudioClip voiceSound;
    public float voicePitch =1f;


}
[System.Serializable]
public class DialogueLine
{
    public enum SpeakerType { NPC, Player }
    public SpeakerType speaker;
    [TextArea]
    public string line;
    public bool autoProgress;
}
