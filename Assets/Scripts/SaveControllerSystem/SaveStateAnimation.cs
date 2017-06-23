using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateAnimation : MonoBehaviour {

    private void Update()
    {
        this.transform.Rotate(0, this.transform.rotation.y + 3f, 0);
    }
}
