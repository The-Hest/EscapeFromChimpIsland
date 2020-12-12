using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// !!! NOTICE !!!
/// Important that the first sentence is "" since we need to make sure the user wont activate Key Input "Return" from both this class and ShowDialogBouble
/// </summary>

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI fieldText;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI interactText;
    public Image dialogBackground;
    public List<string> sentences;
    public float typingSpeed;
    public bool interacting { get; private set; }
    public bool finishedTalking { get; private set; }

    private int _index;
    private bool _displayed = false;


    private IEnumerator Type()
    {
        foreach (var letter in sentences[_index].ToCharArray())
        {
            fieldText.text += letter;
            yield return new WaitForSeconds(1 / typingSpeed); // Wait an amount of seconds before typing new letters in our dialog
        }
    }

    private void Start()
    {
        dialogBackground.enabled = false;
    }

    private void Update()
    {
        // Check if the full text has been displayed
        if (fieldText.text == sentences[_index] && interacting)
        {
            _displayed = true;
            continueText.text = "'Enter' to continue";
        }

        // If the sentence is completed and the player is til in range get next line
        if (_displayed && interacting)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _displayed = false;
                continueText.text = "";
                GetNextSentence();
            }
        }
    }

    public void GetNextSentence()
    {
        // As long as we havent reached EOF
        if (_index < sentences.Count - 1)
        {
            _index++;

            fieldText.text = ""; // Reset display
            StartCoroutine(Type());
        }
        else
        {
            CloseDialog();
        }
    }

    public void StartDialog()
    {
        _index = 0;
        ShowField(true);
        interacting = true;
        finishedTalking = false;
        StartCoroutine(Type());
    }

    public void CloseDialog()
    {
        ShowField(false);
        interacting = false;
        finishedTalking = true;
        _index = 0;
    }

    public void ShowField(bool show)
    {
        if (show)
        {
            interactText.text = "";
            dialogBackground.enabled = true;
        }
        else
        {
            StopAllCoroutines();
            continueText.text = "";
            fieldText.text = "";
            dialogBackground.enabled = false;

        }
        
    }
}
