using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] DialogeData DialogeData;
    [SerializeField] GameObject DialogePanel;
    [SerializeField] TMP_Text DialogeText, nameText;
    [SerializeField] Image PortraitIMG;
    [SerializeField] AudioSource TextAudio;
    int DialogueIndex;
    bool Istyping, IsDialogueActive;

    public void Interact()
    {
        Debug.Log($"[NPC] Interact() called on {gameObject.name} | IsDialogueActive={IsDialogueActive} | HasData={(DialogeData != null)}");

        if (DialogeData == null) return;

        if (!IsDialogueActive)
            StartDialoge();
        else
            NextLine();
    }

    void NextLine()
    {

        if (Istyping)
        {
            StopAllCoroutines();
            DialogeText.SetText(DialogeData.dialogueLines[DialogueIndex].line);
            Istyping = false;
            return;
        }
        DialogueIndex++;

        if (DialogueIndex < DialogeData.dialogueLines.Count )
        {
            StartCoroutine(TypeLIne());
        }
        else
        {
            EndDialague();
        }
    }

    void StartDialoge()
    {
        IsDialogueActive = true;
        DialogueIndex = 0;
        DialogePanel.SetActive(true);
        StartCoroutine(TypeLIne());
    }
    public bool CanInteract()
    {
        return !IsDialogueActive;
    }
    IEnumerator TypeLIne()
    {
        Istyping = true;
        DialogeText.SetText("");
        var currentLine = DialogeData.dialogueLines[DialogueIndex];

        DisplaySpeakerInfo(currentLine);

        if (TextAudio != null && DialogeData.voiceSound != null)
        {
            TextAudio.Stop(); // 確保前一句結束的聲音不殘留
            TextAudio.clip = DialogeData.voiceSound;
            TextAudio.pitch = DialogeData.voicePitch;
            TextAudio.Play();
        }
        foreach (char letter in DialogeData.dialogueLines[DialogueIndex].line)
        {
            DialogeText.text += letter;

            yield return new WaitForSeconds(DialogeData.typingSeed);
        }
        Istyping = false;
        if (DialogeData.dialogueLines[DialogueIndex].autoProgress)
        {
            yield return new WaitForSeconds(DialogeData.autoProgressDelay);
            NextLine();
        }
    }
    void DisplaySpeakerInfo(DialogueLine line)
    {
        
        if (line.speaker == DialogueLine.SpeakerType.NPC)
        {
            nameText.SetText(DialogeData.NPCName);
            PortraitIMG.sprite = DialogeData.NPCSprite;
        }
        else
        {
            nameText.SetText(DialogeData.PlayerName);
            PortraitIMG.sprite = DialogeData.PlayerSprite;
        }
    }

        public void EndDialague()
    {
        StopAllCoroutines();
        IsDialogueActive = false;
        DialogeText.SetText("");
        DialogePanel.SetActive(false);
    }
}
