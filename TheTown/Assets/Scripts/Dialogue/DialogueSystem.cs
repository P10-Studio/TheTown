using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class DialogueSystem : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private CanvasGroup dialogueGroup;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private AudioSource textTypingAudioSource;
    
    [Header("Settings")]
    [SerializeField] private float textTypingSpeed = 0.05f;
    [SerializeField] private InputActionReference skipDialogueAction;
    [SerializeField] private float typingVolume = 0.5f;
    
    public bool isTyping;
    
    [SerializeField] private DialogueObject currentDialogue;

    private int _index;
    
    private void Awake()
    {
        if (dialogueGroup == null)
        {
            dialogueGroup = GetComponent<CanvasGroup>();
        }
        
        if (dialogueText == null)
        {
            dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        skipDialogueAction.action.performed += _ => SkipDialogue();
    }

    public void PlayDialogue(DialogueObject dialogue, out bool success)
    {
        if (isTyping)
        {
            success = false;
            return;
        }
        
        success = true;
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
        if (_index < currentDialogue.Replies.Length - 1)
        {
            _index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isTyping = false;   
            
            // TODO: end dialogue, trigger en event
        }
    }

    private IEnumerator TypeLine()
    {
        foreach (var c in currentDialogue.Replies[_index].text)
        {
            var soundEffect = currentDialogue.Replies[_index].audioClip;
            textTypingAudioSource.pitch = Random.Range(0.9f, 1.1f);
            textTypingAudioSource.PlayOneShot(soundEffect, typingVolume);
            dialogueText.text += c;
            yield return new WaitForSeconds(textTypingSpeed);
        }
    }

    public void SkipDialogue()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentDialogue.Replies[_index].text;
            isTyping = false;
            return;
        }

        if (_index < currentDialogue.Replies.Length - 1)
        {
            NextLine();
        }
        else
        {
            isTyping = false;
        }
    }

    private void Update()
    {
        if (currentDialogue != null)
        {
            // skip dialogue action
            
        }
        
        // Check if the skip action is triggered
        
        if (dialogueText.text == currentDialogue.Replies[_index].text)
        {
            NextLine();
        } else
        {
            StopAllCoroutines();
            dialogueText.text = currentDialogue.Replies[_index].text;
        }
    }
}
