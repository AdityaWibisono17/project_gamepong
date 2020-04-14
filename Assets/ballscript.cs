using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    //public int speed = 30; 
    // Start is called before the first frame update
    public Rigidbody2D sesuatu;

    public Animator animtr;
    void Start()
    {
        int x = Random.Range(0,2) * 2 - 1; //nilai x bisa bernilai 0 atau 1
        int y = Random.Range(0,2) * 2 - 1; //nilai x bisa bernilai 0 atau 1
        int speed = Random.Range(20,26); //nilai speed antara 20 sampai 25
        sesuatu.velocity = new Vector2(x,y)* speed;
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        //GetComponent<Rigidbody2D>().velocity = new Vector2(1,-1)* speed;
        animtr.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(sesuatu.velocity.x > 0){ //bola bergerak ke kanan
            sesuatu.GetComponent<Transform>().localScale = new Vector3(1, 1, 1); 
        }else {
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.collider.name=="WallKanan" || other.collider.name=="WallKiri"){
            StartCoroutine(jeda());
        }
    }
    IEnumerator jeda(){
        sesuatu.velocity = Vector2.zero;
        animtr.SetBool("IsMove", false);
        sesuatu.GetComponent<Transform>().position = Vector2.zero;
        
        yield return new WaitForSeconds(1); 
        
        int x = Random.Range(0,2) * 2 - 1; //nilai x bisa bernilai 0 atau 1
        int y = Random.Range(0,2) * 2 - 1; //nilai x bisa bernilai 0 atau 1
        int speed = Random.Range(20,26); //nilai speed antara 20 sampai 25
        sesuatu.velocity = new Vector2(x,y) * speed;
        animtr.SetBool("IsMove", true);
    } 
}
