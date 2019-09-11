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
            
            if (bullet != null && bullet.isActive)
            {
                bullet.m_pausing = true;
            }

        }

    }
}
