using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;


}


public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
           
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
// This is used so the audio only play when a shoot ais fired 
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

        }
    }

//  Update is called once per frame
//  Called before each Phyics Step
    void FixedUpdate () { 

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement= new Vector3(moveHorizontal, 0.0f, moveVertical); //0.0f tell untiy that it a float value
        GetComponent<Rigidbody>().velocity =movement*speed;  ///give direction and how fast you're going

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

    }
}
