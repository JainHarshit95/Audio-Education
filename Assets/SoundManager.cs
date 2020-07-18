using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
    public AudioSource g_Attack1Sound;
    public AudioSource g_Attack2Sound;
    public AudioSource g_Attack3Sound;
    public AudioSource g_Attack4Sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void PlayAttack1Sound()
    {
        g_Attack1Sound.Play();
    }

    public void PlayAttack2Sound()
    {
        g_Attack2Sound.Play();
    }

    public void PlayAttack3Sound()
    {
        g_Attack3Sound.Play();
    }

    public void PlayAttack4Sound()
    {
        g_Attack4Sound.Play();
    }
}