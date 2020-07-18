using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    //Raw Image to Show Video Images [Assign from the Editor]
    public RawImage v_image;
    public GameObject Image;
    public GameObject tut;
    public GameObject Intro;
    public GameObject ques;
    public GameObject Create;
    public GameObject logo;
    public GameObject tit;
    public GameObject joy;

    public List<VideoClip> videoClipList;

    private List<VideoPlayer> videoPlayerList;
    private int videoIndex = 0;


    public Button action1;
    public Button action2;
    public Button action3;
    public Button action4;

    public Button Attack1;
    public Button Attack2;
    public Button Attack3;
    public Button Attack4;
    
 
    

    //Audio
    private AudioSource audioSource;


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

    IEnumerator playVideo(bool firstRun = true)
    {
        if (videoClipList == null || videoClipList.Count <= 0)
        {
            Debug.LogError("Assign VideoClips from the Editor");
            yield break;
        }
        v_image.gameObject.SetActive(true);
        //Init videoPlayerList first time this function is called
        if (firstRun)
        {
            videoPlayerList = new List<VideoPlayer>();
            for (int i = 0; i < videoClipList.Count; i++)
            {
                //Create new Object to hold the Video and the sound then make it a child of this object
                GameObject vidHolder = new GameObject("VP" + i);
                vidHolder.transform.SetParent(transform);

                //Add VideoPlayer to the GameObject
                VideoPlayer videoPlayer = vidHolder.AddComponent<VideoPlayer>();
                videoPlayerList.Add(videoPlayer);

                //Add AudioSource to  the GameObject
                AudioSource audioSource = vidHolder.AddComponent<AudioSource>();

                //Disable Play on Awake for both Video and Audio
                videoPlayer.playOnAwake = false;
                audioSource.playOnAwake = false;

                //We want to play from video clip not from url
                videoPlayer.source = VideoSource.VideoClip;

                //Set Audio Output to AudioSource
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

                //Assign the Audio from Video to AudioSource to be played
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, audioSource);

                //Set video Clip To Play 
                videoPlayer.clip = videoClipList[i];
            }
        }

        //Make sure that the NEXT VideoPlayer index is valid
        if (videoIndex >= videoPlayerList.Count)
            yield break;

        //Prepare video
        videoPlayerList[videoIndex].Prepare();

        //Wait until this video is prepared
        while (!videoPlayerList[videoIndex].isPrepared)
        {
            Debug.Log("Preparing Index: " + videoIndex);
            yield return null;
        }
        Debug.LogWarning("Done Preparing current Video Index: " + videoIndex);

        //Assign the Texture from Video to RawImage to be displayed
        v_image.texture = videoPlayerList[videoIndex].texture;

        //Play first video
        videoPlayerList[videoIndex].Play();

        //Wait while the current video is playing
        bool reachedHalfWay = false;
        int nextIndex = (videoIndex + 1);
        while (videoPlayerList[videoIndex].isPlaying)
        {
            Debug.Log("Playing time: " + videoPlayerList[videoIndex].time + " INDEX: " + videoIndex);

            //(Check if we have reached half way)
            if (!reachedHalfWay && videoPlayerList[videoIndex].time >= (videoPlayerList[videoIndex].clip.length / 2))
            {
                reachedHalfWay = true; //Set to true so that we don't evaluate this again

                //Make sure that the NEXT VideoPlayer index is valid. Othereise Exit since this is the end
                if (nextIndex >= videoPlayerList.Count)
                {
                    Debug.LogWarning("End of All Videos: " + videoIndex);
                    yield break;
                }

                //Prepare the NEXT video
                Debug.LogWarning("Ready to Prepare NEXT Video Index: " + nextIndex);
                videoPlayerList[nextIndex].Prepare();
            }
            yield return null;
        }
        Debug.Log("Done Playing current Video Index: " + videoIndex);

        //Wait until NEXT video is prepared
        while (!videoPlayerList[nextIndex].isPrepared)
        {
            Debug.Log("Preparing NEXT Video Index: " + nextIndex);
            yield return null;
        }

        Debug.LogWarning("Done Preparing NEXT Video Index: " + videoIndex);

        //Increment Video index
        videoIndex++;

        //Play next prepared video. Pass false to it so that some codes are not executed at-all
        StartCoroutine(playVideo(false));
        v_image.gameObject.SetActive(false);
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        // Introduction
        logo.SetActive(true);
        yield return new WaitForSeconds(10);
        logo.SetActive(false);

        // Introduction
        tit.SetActive(true);
        yield return new WaitForSeconds(10);
        tit.SetActive(false);

        // Introduction
        Intro.SetActive(true);
        yield return new WaitForSeconds(10);
        Intro.SetActive(false);
        
        // Tutorial
        tut.SetActive(true);
        yield return new WaitForSeconds(5);
        tut.SetActive(false);

        // Audio

        //1.Loop through each AudioClip
      /*  for (int i = 0; i < g_audioClips.Length; i++)
        {
            if (i == 1)
            {
                Attack1.gameObject.SetActive(true);
                Attack2.gameObject.SetActive(true);
                joy.gameObject.SetActive(true);
            }
            else if (i == 3 || i==5)
            {
                Attack3.gameObject.SetActive(true);
                Attack4.gameObject.SetActive(true);
                joy.gameObject.SetActive(true);

            }

            
            
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
            Attack1.gameObject.SetActive(false);
            Attack2.gameObject.SetActive(false);
            Attack3.gameObject.SetActive(false);
            Attack4.gameObject.SetActive(false);
            joy.gameObject.SetActive(false);
           
        }

        */
        //Video

        Application.runInBackground = true;
       // Image.SetActive(true);
        StartCoroutine(playVideo());
        //Image.SetActive(false);
        
        // Question
        ques.SetActive(true);
        action1.gameObject.SetActive(true);
        action2.gameObject.SetActive(true);
        action3.gameObject.SetActive(true);
        action4.gameObject.SetActive(true);

        ques.SetActive(false);
        action1.gameObject.SetActive(false);
        action2.gameObject.SetActive(false);
        action3.gameObject.SetActive(false);
        action4.gameObject.SetActive(false);

        // Created By
        Create.SetActive(true);
        yield return new WaitForSeconds(10);
        Create.SetActive(false);





    }

}
