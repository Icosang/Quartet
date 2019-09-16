using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumBullet5 : BulletSetter
{
    UbhBullet bullet;
    public Transform m_targetTransform;
    private UbhShotCtrl m_shotCtrl;
    public bool triggered { get; set; } = false;

    public override void SetBullet()
    {
        bullet = GetComponentInParent<UbhBulletSimpleSprite2d>();
        m_shotCtrl = transform.GetComponentInParent<UbhShotCtrl>();
        StartCoroutine(ResumeAndAim(1f));
        triggered = false;
    }

    IEnumerator ResumeAndAim(float waittime = 0f)
    {
        yield return new WaitForSeconds(waittime);        

        bullet.m_pausing = false;

        m_targetTransform = UbhUtil.GetTransformFromTagName("Player", false, false, transform);
        if (m_targetTransform != null)
        {
            float angle = UbhUtil.GetAngleFromTwoPosition(transform, m_targetTransform, UbhUtil.AXIS.X_AND_Y);
            bullet.transform.SetEulerAnglesZ(angle);
        }
    }
}
