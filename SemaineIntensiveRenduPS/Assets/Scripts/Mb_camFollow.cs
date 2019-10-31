using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_camFollow : MonoBehaviour
{
    public Transform playerPos;
    public float zOffset;
    Vector3 desiredPosition;
    Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        desiredPosition = new Vector3(transform.position.x, transform.position.y, playerPos.transform.position.z + zOffset);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        if (playerPos.position.z + zOffset> desiredPosition.z+ zOffset)
            desiredPosition = new Vector3(transform.position.x, transform.position.y, playerPos.transform.position.z+ zOffset);
    }
}
