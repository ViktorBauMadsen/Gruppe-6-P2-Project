using TMPro;
using UnityEngine;

public class Dialogue_Assistant : MonoBehaviour
{
    [SerializeField] private TextWriter TextWriter;
    private TextMeshProUGUI messageText;
    private AudioSource TalkingAudioSource;
    private void Awake()
    {
        if (messageText == null)
        {
            messageText = transform.Find("message").Find("messageText").GetComponent<TextMeshProUGUI>();
            
        }
    }

    private void Start()
    {
        string originalText = messageText.text;
        if (messageText != null)
        {
            originalText = messageText.text;
            messageText.text = string.Empty;
        }

        if(TextWriter!=null && messageText != null)
        {
           
            TextWriter.AddWriter(messageText, originalText, 0.025f);
        }
        

    }





}
