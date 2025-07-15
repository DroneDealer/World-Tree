//Code reused from my Fortune Teller dialogue script with a few modificatios
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public GameObject dialogueBubble;
    public GameObject continueIndicator;
    public string[] lines;
    public float delay = 0.03f;
    private int index = 0;
    private bool isTyping = false;
    public AudioClip clickClip;
    public AudioSource audioSource;
    public GameObject UIDialogueHolder;
    public GameObject FeedButton;
    public GameObject returnButton;
    public GameObject ResetAllProgressButton;
    private void Start()
    {
        UIDialogueHolder.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextLine();
        }
    }

    public IEnumerator TypeText()
    {
        UIDialogueHolder.transform.SetAsLastSibling();
        isTyping = true;
        UIDialogueHolder.SetActive(true);
        dialogueBubble.SetActive(true);
        textBox.gameObject.SetActive(true);
        continueIndicator.SetActive(false);
        textBox.text = "";

        foreach (char c in lines[index])
        {
            textBox.text += c;
            if (!char.IsWhiteSpace(c) && clickClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(clickClip);
            }
            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
        continueIndicator.SetActive(true);
    }

    void NextLine()
    {
        continueIndicator.SetActive(false);
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeText());
        }
        else
        {
            textBox.gameObject.SetActive(false);
            continueIndicator.SetActive(false);
            dialogueBubble.SetActive(false);
            FeedButton.SetActive(true);
            returnButton.SetActive(true);
            ResetAllProgressButton.SetActive(true);
            Debug.Log("End of dialogue");
        }
    }
}