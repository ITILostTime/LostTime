using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateSpriteAnimation : MonoBehaviour {

    private void Update()
    {
        this.transform.Rotate(0, 0, this.transform.rotation.z + 3f);
    }
}
