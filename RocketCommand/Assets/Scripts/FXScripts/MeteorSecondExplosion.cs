using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSecondExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
}
