using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    private InputAction textContinue;
    public InputActionAsset CharacterActionAsset;

    private static DialogueManager instance;

    [Header("Param")]

    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Globals Ink File")]
    [SerializeField] private TextAsset LoadglobalsJSON;

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayName;

    [SerializeField] private Animator colorAnimator;

    private Animator layoutAnimator;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private bool canContinueNext = false;

    private Coroutine displayLineCoroutine;

    private bool canSkip = false;
    private bool submitSkip = false;
    private bool isAddingTextTag = false;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "color";
    private const string LAYOUT_TAG = "layout";

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private DialogueVariables dialogueVariables;

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

        dialogueVariables = new DialogueVariables(LoadglobalsJSON);
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
        if (textContinue.WasPressedThisFrame())
        {
            submitSkip = true;
        }

        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueNext && currentStory.currentChoices.Count == 0 && textContinue.WasPressedThisFrame())
        {
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        ContinueStory();
    }

    private void ExitDialogue()
    {
        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = null;
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogue();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        continueIcon.SetActive(false);
        canContinueNext = false;
        submitSkip = false;
        HideChoices();

        StartCoroutine(CanSkip());

        foreach (char letter in line.ToCharArray())
        {
            if (canSkip && submitSkip)
            {
                submitSkip = false;
                dialogueText.text = line;
                break;
            }
            if(letter == '<' || isAddingTextTag)
            {
                isAddingTextTag = true;
                dialogueText.text += letter;
                if(letter == '>') 
                {
                    isAddingTextTag = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        continueIcon.SetActive(true);
        DisplayChoices();
        canContinueNext = true;
    }

    private IEnumerator CanSkip()
    {
        canSkip = false; //Making sure the variable is false.
        yield return new WaitForSeconds(0.05f);
        canSkip = true;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length) { Debug.LogError("More choices than UI can support."); }

        int index = 0;

        foreach (Choice choice in currentChoices)
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

    private void HideChoices()
    {
        foreach(GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
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
        textContinue.WasPressedThisFrame();
        ContinueStory();
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
                    colorAnimator.Play(tagValue);
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

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null) 
        {
            Debug.LogWarning("Ink Variable was found to be null");
        }
        return variableValue;
    }
}
