using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern2 : BulletSetter
{
    public int RideCount { get; set; } = 0;
    UbhBullet bullet;
    SpriteRenderer spriteR;
    Sprite[] sprites;

    void Start() {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Sprites/SmallBullets");
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
                //랜덤으로 색변경
                spriteR.sprite = sprites[Random.Range(0, sprites.Length)];
            }
        }
    }
    public override void SetBullet() {
        bullet = GetComponentInParent<UbhBulletSimpleSprite2d>();
        RideCount = 0;
        spriteR.sprite = sprites[4];
        bullet.m_pausing = false;
    }
}
