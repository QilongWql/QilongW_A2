using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;  
  
public class PlaySoundOnClick : MonoBehaviour  
{  
    public AudioClip soundClip; 
  
    private AudioSource audioSource; 
    private bool isPlaying; 
  
    void Start()  
    {  
        
        audioSource = gameObject.AddComponent<AudioSource>();  
        audioSource.clip = soundClip;  
        audioSource.loop = false;   
        audioSource.playOnAwake = false; 
        isPlaying = false; 
    }  
  
     
    public void ToggleSound()  
    {  
        if (audioSource.clip != null)  
        {  
            if (isPlaying)  
            {  
                
                audioSource.Pause();  
                isPlaying = false;  
            }  
            else  
            {  
                
                audioSource.Play();  
                isPlaying = true;  
  
                
            }  
        }  
        else  
        {  
            Debug.LogWarning("no");  
        }  
    }  
  
   
}