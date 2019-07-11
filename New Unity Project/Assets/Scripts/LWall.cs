using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)

    {
        //임시로 플레이어불렛만 적용, 나중에 고칠것
        if (c.gameObject.tag == "Player")
        {
            c.gameObject.transform.position += new Vector3(1, 0, 0);

        }

    }
}
