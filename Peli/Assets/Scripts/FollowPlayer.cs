using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float maxZoom = 1.5f;
    public float minZoom = 0.4f;
    public float zoomSpeed = 1f;
    private  float currentZoom = 1f;
    // Update is called once per frame
    void Update()
    {

        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        transform.position = player.position + offset*currentZoom;
    }
}
