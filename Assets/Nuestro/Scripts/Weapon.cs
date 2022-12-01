using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform spawnPoint;
    public float distance = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, distance))
        {
            if (hit.transform.tag != "Enemy")
                Destroy(hit.transform.gameObject);
        }
        else
            Debug.Log("Not hit");
    }

}

