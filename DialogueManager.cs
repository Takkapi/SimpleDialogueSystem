using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Button nextButton;
    
    [SerializeField] TMP_Text characterName;
    [SerializeField] TMP_Text dialogueText;
    
    [SerializeField] GameObject dialogueUI;
    
    [SerializeField] DialogueSO[] dialogues;

    public static DialogueManager Instance;
    
    public bool isInDialogue;
    
    private string _dialogueContentText;
    
    private void Awake()
    {
        Instance = this;
        dialogueUI.SetActive(false);
        nextButton.gameObject.SetActive(false);
        
        dialogueText.text = "";
    }

    IEnumerator StartTypewritter()
    {
        dialogueText.text = "";
        nextButton.gameObject.SetActive(false);
        
        for (int i = 0; i < _dialogueContentText.Length; i++)
        {
            dialogueText.text += _dialogueContentText[i];
            yield return new WaitForSeconds(0.05f);
        }
        
        nextButton.gameObject.SetActive(true);
        StopCoroutine(StartTypewritter());
    }

    public void StartDialogue(int index)
    {
        int length = dialogues[index].dialogues.Length;
        int counter = 0;
        
        isInDialogue = true;
        
        dialogueUI.SetActive(true);
        
        characterName.text = dialogues[index].dialogues[0].name;
        _dialogueContentText =  dialogues[index].dialogues[0].content;
        
        StartCoroutine(StartTypewritter());
        
        nextButton.onClick.AddListener(() =>
        {
            counter++;
            
            if (counter >= length)
            {
                dialogueUI.SetActive(false);
                isInDialogue = false;
                nextButton.onClick.RemoveAllListeners();
            }
            else
            {
                _dialogueContentText = dialogues[index].dialogues[counter].content;
                
                characterName.text = dialogues[index].dialogues[counter].name;
                StartCoroutine(StartTypewritter());
                
            }
        });
    }
}
