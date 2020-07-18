using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Joystick;
    public Button Attack1;
    public Button Attack2;
    public Button Attack3;
    public Button Attack4;

    float g_time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        g_time = Time.time;
        Debug.Log(g_time);

    }
}
