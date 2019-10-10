using UnityEngine;

public class BackgroundReleaser : MonoBehaviour

{
    void OnTriggerExit2D(Collider2D c)

    {
        if (c.gameObject.tag == "Bullet" || c.gameObject.tag == "Playerbullet")
        {
            UbhBullet bullet = null;

            if (c.transform.parent.GetComponent<UbhPlayerBullet>() != null)
            {
                bullet = c.transform.parent.GetComponent<UbhPlayerBullet>();
            }
            else if (c.transform.parent.GetComponent<UbhBulletSimpleSprite2d>() != null) {
                bullet = c.transform.parent.GetComponent<UbhBulletSimpleSprite2d>();
            }

            if (bullet != null && bullet.isActive){
                UbhObjectPool.instance.ReleaseBullet(bullet);
            }
            
        }

    }

}