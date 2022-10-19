using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    [SerializeField] private TempoController controller;
    private Subscriber subscriber;
    [SerializeField] private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        subscriber = new Subscriber(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (subscriber.status) shoot();
        //if player is pressing the shoot button
        if (Input.GetButtonDown("Fire1"))
        {
            controller.subscribe(subscriber);
        }
        
    }

    private void shoot()
    {
        subscriber.status = false;
        GameObject obj = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //add force to the riight 
        obj.GetComponent<Rigidbody2D>().AddForce(transform.right * 800f);
    }


}
