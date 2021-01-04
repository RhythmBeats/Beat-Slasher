    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3((float)1.21, (float)2.06, 0), Quaternion.identity);
    }
}
