using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    // Moviment script 
    public Rigidbody2D rb;
    private int moveSpeed = 5;
    private float direction; //saber a direcao que to apertando
    private float dir_vertical;

    private int hp = 3;
    [SerializeField] private GameObject[] hearts = new GameObject[3];




    [SerializeField] private TempoController controller;
    private Subscriber subscriber;
   // [SerializeField] private GameObject bulletPrefab;


    // project tile 
    public ProjecttileBeheaviour ProjectPrefab;
    public Transform LaunchOffset;


    // Start is called before the first frame update
    void Start()
    {
        subscriber = new Subscriber(false);
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        dir_vertical = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector2(direction * moveSpeed, dir_vertical * moveSpeed); // a velocidade dele no eixo y éa propria dele neste eixo

        //if (subscriber.status) shoot();
        //if player is pressing the shoot button
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectPrefab, transform.position, transform.rotation);
        }
        
    }

    //when taking damage
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
            takeDamage();
    }

    //when taking damage
    public void takeDamage()
    {
        hp--;
        if(hp==0)/*load scene 1*/ UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        hearts[hp].SetActive(false);

        
    }


}
