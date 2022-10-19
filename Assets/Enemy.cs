using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TempoController controller;
    private bool attackable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        defendPattern();
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

    
    //on collision with bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(attackable){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
