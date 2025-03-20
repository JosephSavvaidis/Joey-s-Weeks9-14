using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{

    public Transform hours;
    public Transform mins;
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine clockIsRunning;
    IEnumerator doOneHour;

    //cookcoockclock remastered
    public Animator animator;
    public int coocooNumber;

    void Start()
    {
        clockIsRunning = StartCoroutine(MoveTheClock());

        //t += Time.deltaTime;

        //if (t > timeAnHourTakes)
        //{
        //    t = 0;
        //    OnTheHour.Invoke();

        //    hour++;
        //    if (hour == 12)
        //    {
        //        hour = 0;
        //    }
        //}
    }

    private IEnumerator MoveTheClock()
    {
        while (true)
        {
            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doOneHour);
        }


    }

    private IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            
            
            mins.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hours.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }
        
        OnTheHour.Invoke(hour);
    }
    public IEnumerator hitCooCoo()
    {
        while(coocooNumber < hour)
        {
            coocooNumber += 1;
            animator.SetBool("Coo", true);
            yield return new WaitForSeconds(1);
            animator.SetBool("Coo", false);
        }
        coocooNumber = 0;
    }
    public void StopTheClock()
    {
        if (clockIsRunning != null)
        {
            StopCoroutine(clockIsRunning);
        }
        StopCoroutine(MoveTheClock());
        StopCoroutine(doOneHour);
    }
    IEnumerator GriddyMaster()
    {
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("2");
    }
}