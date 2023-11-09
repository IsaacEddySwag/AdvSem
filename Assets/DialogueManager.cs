using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    private InputAction textContinue;
    public InputActionAsset CharacterActionAsset;

    private static DialogueManager instance;

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set;}

    public bool AutoText = false;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private void OnEnable()
    {
        //Enables the gameplay control scheme from an input action map
        CharacterActionAsset.FindActionMap("Gameplay").Enable();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        textContinue = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Jump");

        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;

        foreach(GameObject choice in choices) 
        {
            choicesText[index] = choice.GetComponent<TextMeshProUGUI>();
            index++;
        }
    }

    public static DialogueManager GetInstance()
    { 
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueIsPlaying) 
        {
            return;
        }

        if(textContinue.WasPressedThisFrame() || AutoText)
        {
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogue()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogue();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length) { Debug.LogError("Too many choices than UI can support."); }
        int index = 0;
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++) { }
        {
            choices[i].gameObject.SetActive(false);
        }
    }
}
