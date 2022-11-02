using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP2v2 : MonoBehaviour
{
    [SerializeField] private TempoController controller;
    private bool attackable = false;
    private int currentShot = 0;
    
    private float[] attackTimesEven = { 2.92f, 3.93f, 4.47f, 5.43f, 14.51f, 14.68f, 14.87f, 15.99f, 16.185f, 16.34f};
    private float[] attackTimesOdd = { 3.28f, 3.47f, 3.66f, 4.1f, 4.26f, 4.8f, 5.0f, 5.17f, 5.97f, 15.28f, 15.42f, 15.78f};
    [SerializeField] private bool even;

    
    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        defendPattern();
        attackPattern();
    }

    private void defendPattern(){
        if (controller.beat == 4){
            attackable = true;
        }
        else attackable = false;

        if(attackable){
            //change color to green
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else{
            //change color to red
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void attackPattern(){
        if(even){
            if(compareBeat(controller.audioSource.time, attackTimesEven[currentShot])){
                shoot();
                currentShot++;
                if (currentShot >= attackTimesEven.Length){
                    currentShot = 0;
                }
            }
        }
        else{
            if(compareBeat(controller.audioSource.time, attackTimesOdd[currentShot])){
                shoot();
                currentShot++;
                if (currentShot >= attackTimesOdd.Length){
                    currentShot = 0;
                }
            }
        }
    }

    private bool compareBeat(float currentTime, float targetTime){
        float result = Mathf.Abs(currentTime - targetTime);
        if(result < 0.03f) return true;
        else return false;
    }

    private void shoot(){
        Debug.Log("shoot");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 direction = new Vector2(-1, 0);
        // float[] values = {15,  0, 15};
        // int index = Random.Range(0, values.Length);
        // direction = Quaternion.Euler(0, 0, values[index]) * direction; 
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x*10, direction.y*10);
    }
    //on collision with bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(attackable){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
