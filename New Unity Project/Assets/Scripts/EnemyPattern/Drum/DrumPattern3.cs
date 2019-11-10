using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPattern3 : MonoBehaviour
{
    void OnDisable() {
        D.Get<SoundManager>().sounds["DrumBreak"].Play();
    }
}
