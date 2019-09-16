using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern3Ride : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D c)

    {
        if (c.gameObject.name.Contains("DrumBullet5"))
        {
            UbhBullet bullet = c.transform.parent.GetComponent<UbhBulletSimpleSprite2d>();
            DrumBullet5 bullet5 = c.transform.GetComponent<DrumBullet5>();

            if (bullet != null && bullet.isActive && !bullet5.triggered)
            {
                bullet.m_pausing = true;
                bullet5.triggered = true;
            }

        }

    }
}
