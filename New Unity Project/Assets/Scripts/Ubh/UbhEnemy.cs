﻿using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
public class UbhEnemy : UbhMonoBehaviour
{
    protected GameManager manager;
    public const string NAME_PLAYER = "Player";
    public const string NAME_PLAYER_BULLET = "PlayerBullet";
    [SerializeField]
    float timer = 0f;
    [SerializeField, FormerlySerializedAs("_Hp")]
    protected float m_hp = 1000;
    //무적
    public bool Invincible { get; set; } = false;
    
    protected virtual void Start()
    {
       manager = D.Get<GameManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime; 
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Playerbullet")
        {
            UbhPlayerBullet playerBullet = c.transform.parent.GetComponent<UbhPlayerBullet>();
            if (playerBullet != null && playerBullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(playerBullet);
            }
        }
    }
    protected IEnumerator InvincibleTime(float time)
    {
        Invincible = true;
        yield return new WaitForSeconds(time);
        Invincible = false;
    }
    public void HpDown(float down) {
        if (!Invincible)
        {
            m_hp -= down;
            manager.AddScore((long)(down * 10));
        }
    }
    protected IEnumerator StartPattern(float waittime = 0f, int patternnum = 0)
    {
        yield return new WaitForSeconds(waittime);
        transform.GetChild(patternnum).gameObject.SetActive(true);
        timer = 0f;
        manager.timebonus = true;
    }
    protected IEnumerator EndPattern(float waittime, int patternnum, long patternscore, float bonustime, bool dodgeonly = false)
    {
        yield return new WaitForSeconds(waittime);
        transform.GetChild(patternnum).gameObject.SetActive(false);
        manager.AddScore(patternscore);
        if (manager.timebonus)
        {
            if (dodgeonly)
            {
                manager.AddScore(patternscore * 3 / 2);
            }
            else manager.AddScore(patternscore + (long)(patternscore * ((bonustime - timer) / bonustime)));
        }
    }
}