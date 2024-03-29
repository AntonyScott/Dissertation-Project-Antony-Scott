using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class DialogueText : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text npcNameText;
    public string dialogue;
    public string npcName;
    public bool playerInRange;

    private MyGameActions input;

    private void Awake()
    {
        input = new MyGameActions();
    }

    private void OnEnable()
    {
        input.Enable();
        input.UI.Interact.performed += OnInteractionPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        input.UI.Interact.performed -= OnInteractionPerformed;
    }

    private void OnInteractionPerformed(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
                npcNameText.text = npcName;
                FindObjectOfType<AudioManager>().Play("Mumble Speak");
                //FindObjectOfType<AudioManager>().StopPlaying("Main Menu Theme");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}