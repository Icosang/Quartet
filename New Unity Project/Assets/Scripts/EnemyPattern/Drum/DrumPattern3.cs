using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern3 : MonoBehaviour
{
    void OnDisable() {
        SoundManager.sounds["DEFEATED"].Play();
    }
}
