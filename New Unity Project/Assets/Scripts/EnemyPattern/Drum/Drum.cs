using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : UbhEnemy
{
    enum PatternState
    {
        Pattern1,
        Pattern2,
        Pattern3
    }
    PatternState pattern = PatternState.Pattern1;
    UbhObjectPool pool;


    void Awake()
    {
        pool = GameObject.FindWithTag("Pool").GetComponent<UbhObjectPool>();
        StartCoroutine(StartPattern());
    }
    void FixedUpdate()
    {
        if (m_hp <= 500 && (pattern.Equals(PatternState.Pattern1))){
            EndPattern(0);
            pool.ReleaseAllBullet();
            StartCoroutine(InvincibleTime());
            StartCoroutine(StartPattern(3.0f, 1));
            pattern = PatternState.Pattern2;
        }
        if (m_hp <= 0 && (pattern.Equals(PatternState.Pattern2)))
        {
            //3ÆÐÅÏ
        }
    }
    IEnumerator StartPattern(float waittime = 0f, int patternnum = 0)
    {
        yield return new WaitForSeconds(waittime);
        transform.GetChild(patternnum).gameObject.SetActive(true);
    }
    void EndPattern(int patternnum)
    {
        transform.GetChild(patternnum).gameObject.SetActive(false);
    }

}
