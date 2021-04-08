using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDie : MonoBehaviour
{

    public float destroyTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis", destroyTime);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

}
