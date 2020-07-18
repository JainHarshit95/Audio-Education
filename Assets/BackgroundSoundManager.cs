using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackgroundSoundManager : MonoBehaviour
{
    public AudioClip[] g_audioClips;
    public AudioSource g_audioSource;

    
    void Awake()
    {
        g_audioSource = GetComponent<AudioSource>();
      
    }


    // Use this for initialization
    void Start()
    {
       StartCoroutine(playAudioSequentially());
      
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < g_audioClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            g_audioSource.clip = g_audioClips[i];

            //3.Play Audio
            g_audioSource.Play();

            //4.Wait for it to finish playing
            while (g_audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }

       

    }


}
