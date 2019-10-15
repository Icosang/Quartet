using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
public class UbhEnemy : UbhMonoBehaviour
{
    public const string NAME_PLAYER = "Player";
    public const string NAME_PLAYER_BULLET = "PlayerBullet";
    [SerializeField, FormerlySerializedAs("_Hp")]
    protected float m_hp = 1000;
    // 포인트. 나중에 시스템에 추가할 것
    [SerializeField, FormerlySerializedAs("_Point")]
    private int m_point = 100;
    //무적
    public bool Invincible { get; set; } = false;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Playerbullet")
        {
            UbhPlayerBullet playerBullet = c.transform.parent.GetComponent<UbhPlayerBullet>();
            if (playerBullet != null && playerBullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(playerBullet);
            }
        }
    }
    protected IEnumerator InvincibleTime(float time)
    {
        Invincible = true;
        yield return new WaitForSeconds(time);
        Invincible = false;
    }
    public void HpDown(float down) {
        if(!Invincible) m_hp -= down;
    }
}