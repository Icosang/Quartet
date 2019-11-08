using UnityEngine;

public class LinearShooter : MonoBehaviour
{

    float MaxDistance = 20f;
    float delayTimer = 0;
    float delayTime = 0.15f;
    GameManager manager;

    private void Start()
    {
        manager = D.Get<GameManager>();
    }
    void FixedUpdate()
    {
        // 5 - Shooting
        if (Input.GetKey(KeyCode.Z) && !manager.ispausing)
        {
            if (delayTimer <= 0)
            {
                Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.red);
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, MaxDistance);
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit2D hit = hits[i];
                    var enemy = hit.transform.GetComponent<UbhEnemy>();
                    if (enemy != null)
                    {
                        enemy.HpDown(1.5f);
                    }
                }

                delayTimer = delayTime;
            }

        }
        if (delayTimer > 0) delayTimer -= Time.deltaTime;
    }
}
