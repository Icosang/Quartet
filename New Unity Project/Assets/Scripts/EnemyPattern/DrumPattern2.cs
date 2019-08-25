using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern2 : MonoBehaviour
{
    [SerializeField]
    public int RideCount { get; set; } = 0;
    UbhBullet bullet;

    void Awake() {
        bullet = GetComponentInParent<UbhBulletSimpleSprite2d>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.name.Contains("Ride")) {
            if ((RideCount == 0) && bullet.m_shooting)
            {
                // 탄정지
                RideCount++;
                bullet.m_pausing = true;
            }
            else if ((RideCount == 1) && bullet.m_shooting) 
            {
                //탄정지해제
                RideCount++;
                bullet.m_pausing = false;
                bullet.m_random = true;
                bullet.m_randomangle = 30f;
            }
        }
    }
}
