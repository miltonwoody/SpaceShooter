using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
//    void onTriggerEntry(Collider other)
//    {
//    
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
       
     void OnTriggerEnter(Collider other){
        if (other.tag == "Boundary")
        {
            return;
        }
 //       else if (other.tag == "Bolt")
//        {
            Instantiate(explosion, transform.position, transform.rotation);
//        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
          Debug.Log(other.name);
          
          Destroy(other.gameObject);
          Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }

    //Mark object to be destroyed 
    //    }


}
