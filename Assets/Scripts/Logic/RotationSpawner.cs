using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpawner : MonoBehaviour
{
    Rigidbody2D rb;
    SpawPoint sp;
    Controller controller;
    public Transform pt;
    public GameObject spaenPoint;
    public GameObject player;
    public GameObject camera;
    
    void Start()
    {
        pt = player.GetComponent<Transform>();
        controller = camera.GetComponent<Controller>();
        rb = GetComponent<Rigidbody2D>();
        sp = spaenPoint.GetComponent<SpawPoint>();
        StartCoroutine(handleSpawn());
    }

    IEnumerator handleSpawn()
    {  
        yield return new WaitForSeconds(controller.getVelocity());
        gameObject.transform.position = pt.position;
        sp.spawn();
        rb.rotation = Random.Range(0f, 360f);
        StartCoroutine(handleSpawn());
    }

}
