using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
}
