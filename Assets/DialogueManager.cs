using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using UnityEngine.SearchService;

public class DialogueManager : MonoBehaviour
{
    private InputAction textContinue;
    public InputActionAsset CharacterActionAsset;

    private static DialogueManager instance;

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayName;

    private Animator layoutAnimator;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set;}

    public bool AutoText = false;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

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
    }

    public static DialogueManager GetInstance()
    { 
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;

        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
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
        dialogueText.text = null;
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogue();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length) { Debug.LogError("More choices than UI can support."); }

        int index = 0;

        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags) 
        {
            string[] splitTag = tag.Split(':');

            if(splitTag.Length != 2) { Debug.LogError("Tag could not be appropriately"); }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey) 
            {
                case SPEAKER_TAG:
                    displayName.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("That tag couldn't be found. Try another.");
                    break;
            }
        }
    }
}
