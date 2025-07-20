using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class DialogueSystem : MonoBehaviour
{
    private static readonly int End = Animator.StringToHash("END");
    private static readonly int Start = Animator.StringToHash("START");
    
    private readonly List<string> _skipLettersSound = new List<string>
    {
        ".", "!", "?", ",", ";", ":", "-", "—", "(", ")", "[", "]", "{", "}", "'", "\""
    };

    [Header("Components")] 
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerText;
    
    [Header("Settings")]
    [SerializeField] private float textTypingSpeed = 0.5f;
    [SerializeField] private InputActionReference skipDialogueAction;
    
    public bool isTyping;
    public bool isEnabled = true;
    
    [SerializeField] private DialogueObject currentDialogue;

    private int _index;
    
    // TODO: 
    // Add delay before starting the dialogue
    // Change the typing speed, because the audio is going too fast
    // Add an end custom event where the outer script can subscribe to it
    
    private void Awake()
    {
        skipDialogueAction.action.performed += _ => SkipDialogue();
        
        skipDialogueAction.action.Enable();
        
        PlayDialogue(currentDialogue);
    }

    public void PlayDialogue(DialogueObject dialogue)
    {
        isEnabled = true;
        dialogueAnimator.SetTrigger(Start);
        currentDialogue = dialogue;
        StartDialogue(dialogue);
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        _index = 0;
        currentDialogue = dialogue;
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        _index++;
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (var c in currentDialogue.Replies[_index].text)
        {
            if (!_skipLettersSound.Contains(c.ToString()))
            {
                AudioManager.Instance.PlayTypingSound();
            }
            
            dialogueText.text += c;
            yield return new WaitForSeconds(textTypingSpeed);
        }
        isTyping = false;
    }

    public void SkipDialogue()
    {
        if (!isEnabled) return;
        
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentDialogue.Replies[_index].text;
            isTyping = false;
            return;
        }
        
        if (_index == currentDialogue.Replies.Length - 1)
        {
            EndDialogue();
            return;
        }
        
        NextLine();
    }

    private void EndDialogue()
    {
        dialogueAnimator.SetTrigger(End);
        isTyping = false;
        isEnabled = false;
    }
}
