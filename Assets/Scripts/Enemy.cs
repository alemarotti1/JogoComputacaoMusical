using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TempoController controller;
    private bool attackable = false;

    public float Hitpoints;
    public float MaxHitpoints = 5;

    public HealthbarBeheaviour Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

    }

    // Update is called once per frame
    void Update(){
     //   defendPattern();
    }
/*
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
*/
 /*   private void OnCollisionEnter2D(Collision2D other) {
        collision.collider.GetComponent();
    }

    */
    //on collision with bullet
    

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if(Hitpoints <= 0){
            Destroy(gameObject);
        }
    }
}
