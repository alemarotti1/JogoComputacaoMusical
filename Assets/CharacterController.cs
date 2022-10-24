using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    // Moviment script 
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction; //saber a direcao que to apertando
    private float dir_vertical;



    [SerializeField] private TempoController controller;
    private Subscriber subscriber;
    [SerializeField] private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        subscriber = new Subscriber(false);
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal"); // 
        dir_vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(direction * moveSpeed, dir_vertical * moveSpeed); // a velocidade dele no eixo y éa propria dele neste eixo   

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
