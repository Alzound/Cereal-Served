using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowS : MonoBehaviour
{
    public Transform avatarTransform;

    private void Update()
    {
        transform.position = avatarTransform.position;
    }
}
