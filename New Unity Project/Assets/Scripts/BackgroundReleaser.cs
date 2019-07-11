using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReleaser : MonoBehaviour

{
    void OnTriggerExit2D(Collider2D c)

    {
        //임시로 플레이어불렛만 적용, 나중에 고칠것
        if (c.gameObject.tag == "Bullet")
        {
            UbhBullet bullet = null;

            if (c.transform.parent.GetComponent<UbhPlayerBullet>() != null){
                bullet = c.transform.parent.GetComponent<UbhPlayerBullet>();
            }

            if (bullet != null && bullet.isActive){
                UbhObjectPool.instance.ReleaseBullet(bullet);
            }

        }

    }

}