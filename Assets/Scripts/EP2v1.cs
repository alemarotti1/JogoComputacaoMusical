using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EP2v1 : MonoBehaviour
{
    [SerializeField] private TempoController controller;
    private bool attackable = false;
    private int currentShot = 0;
    private int angle = 0;
    
    [SerializeField] private Slider hpBar;
    private float maxHp = 5;
    private float currentHp = 5;


    
    [SerializeField] private GameObject bulletPrefab;

    private float[] attackTimes = { 0.3f, 0.45f, 0.85f, 0.95f, 1.05f, 1.26f, 1.42f, 1.58f, 1.79f, 1.98f, 6.32f, 6.5f, 6.64f, 6.85f, 7.2f, 7.42f, 7.63f, 7.82f,
        8f, 8.1f, 8.2f, 8.3f, 8.4f, 8.5f, 8.6f, 8.7f, 8.8f, 8.9f, 9f, 9.1f, 9.2f, 9.3f, 9.4f, 9.5f, 9.6f, 9.7f, 9.8f, 9.9f, 10f, 10.1f, 10.2f, 10.3f, 10.4f, 10.5f, 10.6f, 10.7f, 10.8f, 10.9f, 11f, 11.1f, 11.2f, 11.3f, 11.4f, 11.5f, 11.6f, 11.7f, 11.8f, 11.9f,  
        12.3f, 12.5f, 12.68f, 12.85f, 13f, 13.2f, 13.4f, 13.6f, 13.75f, 
        13.97f
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        defendPattern();
        attackPattern();

        hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -1.5f, 0));
        hpBar.value = currentHp/maxHp;
    }

    private void defendPattern(){
        if (controller.beat % 2 == 0){
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
        //check if current msuic time is close to attack time
        // foreach(float time in attackTimes){
        //    if(compareBeat(controller.audioSource.time, time)){
        //        //shoot bullet
        //        shoot();
        //    }
        // }
        if(compareBeat(controller.audioSource.time, attackTimes[currentShot])){
            shoot();
            currentShot++;
            if (currentShot >= attackTimes.Length){
                currentShot = 0;
            }
        }
    }

    private bool compareBeat(float currentTime, float targetTime){
        float result = Mathf.Abs(currentTime - targetTime);
        if(result < 0.03f) return true;
        else return false;
    }

    //on collision with bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(attackable && collision.gameObject.CompareTag("CharacterAttack")){
            currentHp--;
            if(currentHp <= 0){
                Destroy(gameObject);
            }
        }
    }


    private void shoot(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 direction = new Vector2(-1, 0);
        float[] values = {-15,  0, 15};
        int index = angle++;
        direction = Quaternion.Euler(0, 0, values[index]) * direction; 
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x*10, direction.y*10);
        if (angle >= values.Length) angle = 0;
        
    }
}
