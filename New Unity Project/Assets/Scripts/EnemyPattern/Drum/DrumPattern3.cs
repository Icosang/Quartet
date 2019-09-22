using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern3 : MonoBehaviour
{
    void OnDisable() {
        SoundManager.instance.PlaySound(1);
    }
}
