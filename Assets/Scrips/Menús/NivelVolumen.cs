using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NivelVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image mute;
    
public Slider sliderB;
public float sliderValueB;
public Image panelBrillo;
    void Start()
    {
        slider.value =PlayerPrefs.GetFloat("volAudio", 0.5f);
        sliderB.value =PlayerPrefs.GetFloat("brillo", 0f);
        panelBrillo.color = new Color(panelBrillo.color.r,panelBrillo.color.g,panelBrillo.color.b, sliderB.value);
        AudioListener.volume =slider.value;
        RevisarMute();
    }

    public void ChangeSlider( float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarMute();
    }
    public void RevisarMute()
    {
        if(sliderValue ==0)
        {
            mute.enabled =true;
        }
        else
        {
            mute.enabled = false;
        }
        
    }

  public void ChangeBrillo(float valor2)
  {
      sliderValueB= valor2;
      PlayerPrefs.SetFloat("brillo", sliderValueB);
     panelBrillo.color = new Color(panelBrillo.color.r,panelBrillo.color.g,panelBrillo.color.b, sliderB.value);

  }







}
