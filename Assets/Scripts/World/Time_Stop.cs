using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Time_Stop : MonoBehaviour
{
    public static Time_Stop Instance { get; private set; }

    private float Speed;
    private bool ComeBackTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ComeBackTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ComeBackTime)
        {
            // if the timescale is slower than normal then set it back over time based on the values set
            if (Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * Speed;
            }
            //otherwise the time should be normal and the bool should be false
            else
            {
                Time.timeScale = 1f;
                ComeBackTime = false;
            }
        }
    }

    public void StopTime(float ChangeTime, int RestoreTime, float Delay)
    {
        Speed = RestoreTime;

        //make time start to go back to normal speed
        if (Delay > 0)
        {
            StopCoroutine(TimeComeBack(Delay));
            StartCoroutine(TimeComeBack(Delay));
        }
        else
        {
            ComeBackTime = true;
        }

        Time.timeScale = ChangeTime;
    }

    IEnumerator TimeComeBack(float amt)
    {
        //set the bool to make the timescale go back to normal and does it in real time
        ComeBackTime = true;
        yield return new WaitForSecondsRealtime(amt);
    }
}
