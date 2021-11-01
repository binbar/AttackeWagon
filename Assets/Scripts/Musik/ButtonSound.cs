using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource mySound; 
        public AudioClip SoundButton; // звук при нажатии 

    public void HoverSound()
    {
        mySound.PlayOneShot(SoundButton);
    }
 
}
