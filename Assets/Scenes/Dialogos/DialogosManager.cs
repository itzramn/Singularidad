using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogosManager : MonoBehaviour
{
    public Dialogos dialogo;
     bool a ;
    Queue<string> sentences;
    public GameObject dialogosPanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    public float typingSpeed;
    AudioSource myAudio;
    public AudioClip speakSond;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }
   
    void StarDialogos()
    {
        sentences.Clear();
        foreach(string sentence in dialogo.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

   void DisplayNextSentence()
   {
       if(sentences.Count <= 0)
       {
           displayText.text = activeSentence;
           return;
       }
       activeSentence = sentences.Dequeue();
       displayText.text = activeSentence;
       StopAllCoroutines();
       StartCoroutine(TypeTheSentence(activeSentence));
   }
   IEnumerator TypeTheSentence(string sentence)
   {
       displayText.text = "";
       foreach (char letter in sentence.ToCharArray())
       {
           displayText.text += letter;
           myAudio.PlayOneShot(speakSond);
           yield return new WaitForSeconds(typingSpeed);
       }
   }

   
     private void OnTriggerEnter2D(Collider2D other) {
         if(other.CompareTag("Player") )
         {
             a=true;
             dialogosPanel.SetActive(true);
             StarDialogos();
         }
     }
       
     private void OnTriggerExit2D(Collider2D other) {
        
         if(other.CompareTag("Player"))
         {   
              a=false;
             Debug.Log("salido");
             StopAllCoroutines();
             dialogosPanel.SetActive(false);
         }
     }
    

     void Update()
     {
          if(Input.GetKeyDown("f") && a && displayText.text == activeSentence)
             {
                 DisplayNextSentence();
             }
     }
    

    
}
