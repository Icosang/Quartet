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
                D.Get<SoundManager>().sounds["DEAD"].Play();
                if (D.Get<GameManager>().life == 1) {
                    Destroy(transform.parent.gameObject); // 죽음
                    return;
                }
                D.Get<GameManager>().life -= 1;
               
            }
        }
        else if (colTrans.tag == "Bullet")
        {
        }
    }
}
