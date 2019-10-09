using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        HitCheck(c.transform);
    }

    private void HitCheck(Transform colTrans)
    {
        if (colTrans.tag == "Bullet")
        {
            UbhBullet bullet = colTrans.GetComponentInParent<UbhBullet>();
            if (bullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(bullet);
                //Destroy(transform.parent.gameObject); // 죽음
                D.Get<SoundManager>().sounds["DEAD"].Play();
            }
        }
        else if (colTrans.tag == "Bullet")
        {
        }
    }
}
