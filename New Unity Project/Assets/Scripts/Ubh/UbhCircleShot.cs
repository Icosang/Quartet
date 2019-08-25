using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Ubh circle shot.
/// </summary>
[AddComponentMenu("UniBulletHell/Shot Pattern/Circle Shot")]


public class UbhCircleShot : UbhBaseShot
{
    [Header("===== CircleShot Settings =====")]
    // "Set a angle of shot. (0 to 360)"
    [Range(0f, 360f), FormerlySerializedAs("_Angle")]
    public float m_angle = 0f;

    public override void Shot()
    {
        if (m_bulletNum <= 0 || m_bulletSpeed <= 0f)
        {
            Debug.LogWarning("Cannot shot because BulletNum or BulletSpeed is not set.");
            return;
        }

        if (m_shooting)
        {
            return;
        }

        m_shooting = true;
    }

    private void Update()
    {
        if (m_shooting == false)
        {
            return;
        }

        float shiftAngle = 360f / (float)m_bulletNum;

        for (int i = 0; i < m_bulletNum; i++)
        {
            UbhBullet bullet = GetBullet(transform.position);
            if (bullet == null)
            {
                break;
            }

            float angle = shiftAngle * i + m_angle;

            ShotBullet(bullet, m_bulletSpeed, angle);
        }

        FiredShot();

        FinishedShot();
    }
}