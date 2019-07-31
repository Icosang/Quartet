using UnityEngine;
using UnityEngine.Serialization;
public class UbhEnemy : UbhMonoBehaviour
{
    public const string NAME_PLAYER = "Player";
    public const string NAME_PLAYER_BULLET = "PlayerBullet";

    private const string ANIM_DAMAGE_TRIGGER = "Damage";

    [SerializeField, FormerlySerializedAs("_Hp")]
    private int m_hp = 1;
    // 포인트. 나중에 시스템에 추가할 것
    [SerializeField, FormerlySerializedAs("_Point")]
    private int m_point = 100;
    
    private void OnTriggerEnter2D(Collider2D c)
    {
        // *It is compared with name in order to separate as Asset from project settings.
        //  However, it is recommended to use Layer or Tag.
        if (c.name.Contains(NAME_PLAYER_BULLET))
        {
            UbhPlayerBullet playerBullet = c.transform.parent.GetComponent<UbhPlayerBullet>();
            if (playerBullet != null && playerBullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(playerBullet);

                m_hp = m_hp - playerBullet.m_power;

                if (m_hp <= 0)
                {

                    Destroy(gameObject);
                }
                else
                {
                    // 적 피격모션... 필요한지?
                }
            }
        }
    }
}