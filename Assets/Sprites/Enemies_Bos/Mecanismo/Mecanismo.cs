 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mecanismo : MonoBehaviour
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
        LoadDates();
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
    
     int b=0;
     int dates;
     public GameObject palanca;
     public GameObject palanca2;
     public GameObject paltaformas;
     
     
     void Update()
     {
          if(Input.GetKeyDown("f") && a && displayText.text == activeSentence)
             {
                 DisplayNextSentence();
                 b =1;
                 savePosition();
             }


             if(b==1)
             {
                 myAudio.PlayOneShot(speakSond);
                 Destroy(palanca);
                 palanca2.SetActive(true);
                 paltaformas.SetActive(true);
             }
     }
     
     public void savePosition()
    {
        PlayerPrefs.SetInt("Mecanismo", 1);
        Debug.Log("Datos Guardados Correctamente");
    }

    public void LoadDates()
    {
        
        dates = PlayerPrefs.GetInt("Mecanismo", 0);
        b = dates;
       
        Debug.Log("Datos cargados Correctamente");
    }

    
}
