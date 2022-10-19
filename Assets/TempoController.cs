using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoController : MonoBehaviour
{
    [SerializeField] private float tempo = 108f;
    public int beat = 1;
    [SerializeField] private int beatPerBar = 8;
    private AudioSource audioSource;
    [SerializeField]public AudioClip audioClip;
    //create a list of subscribers
    private List<Subscriber> subscribers = new List<Subscriber>(); 
    public float beatTime = 0f, beatMaxTime;

    // Start is called before the first frame update
    void Start()
    {
        beatMaxTime = 60f / tempo;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        beatTime += Time.deltaTime;
        if (beatTime >= beatMaxTime)
        {
            
            beatTime = 0f;
            if(beat==beatPerBar){
                beat = 1;
                audioSource.Stop();
            } 
            else beat++;
            foreach(Subscriber subscriber in subscribers){
                subscriber.status = true;
            }
            subscribers.Clear();
        }

        if (beat == 1 && audioSource.isPlaying == false)
        { audioSource.Play(); }
        
    }

    public void subscribe(Subscriber subscriber){
        subscribers.Add(subscriber);
    }
}
