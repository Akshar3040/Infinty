using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecomponenet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float objectDistance = -20f;
    [SerializeField] private float despawndistance = -110f;

    private bool canspawnGround = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        if (transform.position.z <= objectDistance && transform.tag == "Ground" && canspawnGround)
        {
            ObjectSpawner.inst.spawnGround();
            canspawnGround = false;
        }

        if (transform.position.z <= despawndistance)
        {
            canspawnGround = true;
            gameObject.SetActive(false);
        }
    }

}
