using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumBullet5 : BulletSetter
{
    UbhBullet bullet;
    public Transform m_targetTransform;
    private UbhShotCtrl m_shotCtrl;

    public override void SetBullet()
    {
        bullet = GetComponentInParent<UbhBulletSimpleSprite2d>();
        m_shotCtrl = transform.GetComponentInParent<UbhShotCtrl>();
        StartCoroutine(ResumeAndAim(1f));
    }

    IEnumerator ResumeAndAim(float waittime = 0f)
    {
        yield return new WaitForSeconds(waittime);        

        bullet.m_pausing = false;

        m_targetTransform = UbhUtil.GetTransformFromTagName("Player", false, false, transform);
        float angle = UbhUtil.GetAngleFromTwoPosition(transform, m_targetTransform, UbhUtil.AXIS.X_AND_Y);
        bullet.m_angle = angle;
        bullet.m_homing = true;
        bullet.m_homingTarget = m_targetTransform;
        bullet.m_homingAngleSpeed = 100f;
    }
}
