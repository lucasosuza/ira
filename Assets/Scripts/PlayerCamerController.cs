using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamerController : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    private Vector3 offseet;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();

        offseet = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offseet;
    }
}
