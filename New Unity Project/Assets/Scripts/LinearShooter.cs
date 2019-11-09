using UnityEngine;
using System.Collections;

public class LinearShooter : MonoBehaviour
{

    float MaxDistance = 20f;
    float delayTimer = 0;
    float delayTime = 0.15f;
    GameManager manager;
    [SerializeField]
    ParticleSystem particle = null;
    Vector2 location;
    int particlecount = 0;

    private void Start()
    {
        manager = D.Get<GameManager>();
        location = new Vector2(transform.position.x + 1.5f , 0);
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
                        location = new Vector2(transform.position.x, enemy.transform.position.y);
                        if (particle != null)
                        {
                            particle.transform.position = location;
                            particlecount++;
                            if (particlecount == 1)
                            {
                                StartCoroutine(Bang());
                                particlecount = 0;
                            }
                        }
                    }
                }

                delayTimer = delayTime;
            }

        }
        if (delayTimer > 0) delayTimer -= Time.deltaTime;
    }
    IEnumerator Bang()
    {
        yield return new WaitForSeconds(0.1f);
        particle.Play();
        yield return null;
    }
}