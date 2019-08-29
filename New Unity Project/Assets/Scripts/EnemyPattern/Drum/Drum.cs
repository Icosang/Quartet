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
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void FixedUpdate()
    {
        if (m_hp <= 500 && (pattern.Equals(PatternState.Pattern1))){
            transform.GetChild(0).gameObject.SetActive(false);
            pool.ReleaseAllBullet();
            StartCoroutine(InvincibleTime());
            transform.GetChild(1).gameObject.SetActive(true);
            pattern = PatternState.Pattern2;
        }
        if (m_hp <= 0 && (pattern.Equals(PatternState.Pattern2)))
        {
            pool.ReleaseAllBullet();
        }
    }

}
