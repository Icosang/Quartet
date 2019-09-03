using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumBullet1Sprite : MonoBehaviour
{
    [SerializeField]
    float randomangle = 60;
    Vector3 random;

    void Awake() {
        random = new Vector3(0f, 0f, ((Random.Range(0f, randomangle) - (randomangle / 2f))));
    }

    void Update()
    {

        transform.Rotate(random * Time.deltaTime);
    }
}
