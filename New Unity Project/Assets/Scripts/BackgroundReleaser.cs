using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReleaser : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    { 
        UbhBullet bullet = other.gameObject.transform.parent?.GetComponent<UbhBullet>();
        if (bullet != null){
            UbhObjectPool.instance.ReleaseBullet(bullet);
        }
    }
}
