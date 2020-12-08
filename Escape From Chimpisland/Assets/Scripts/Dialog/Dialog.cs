using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// !!! NOTICE !!!
/// Important that the first sentence is "" since we need to make sure the user wont activate Key Input "Return" from both this class and ShowDialogBouble
/// </summary>

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI continueDisplay;
    public List<string> sentences;
    public float typingSpeed;
    public bool interacting { get; private set; }

    private int _index;
    private bool _displayed = false;
    private IEnumerator Type()
    {
        foreach (var letter in sentences[_index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(1 / typingSpeed); // Wait an amount of seconds before typing new letters in our dialog
        }
    }

    private void Update()
    {
        // Check if the full text has been displayed
        if (textDisplay.text == sentences[_index] && interacting)
        {
            _displayed = true;
            continueDisplay.text = "'Enter' to continue";
        }

        if (_displayed && interacting)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _displayed = false;
                continueDisplay.text = "";
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

            textDisplay.text = ""; // Reset display
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
        interacting = true;
        StartCoroutine(Type());
    }

    public void StartFirstDialog()
    {
        _index = 1;
        interacting = true;
        StartCoroutine(Type());

    }

    public void CloseDialog()
    {
        continueDisplay.text = "";
        textDisplay.text = "";
        interacting = false;
        _index = 0;
    }
}
