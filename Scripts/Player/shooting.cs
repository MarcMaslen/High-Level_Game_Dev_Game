using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shooting : MonoBehaviour
{
    //Gun stats
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private AudioSource audioSource;
    public float fireRate = 0.5f;
    private float nextShot; //this just holds the time till next shot.
    public bool isFullAuto = false;


    void Update(){
        //this is used so when I make a gun fully automatic, the player can hold mouse one down to shoot
        if(Input.GetButton("Fire1")&& Time.time > nextShot && isFullAuto == true){
            fire(); //fire gun
            audioSource.Play(); //play gun shots
        }

        //when the fire1 button is pressed and the time is greater than the next shot time the gun will fire.
        //note this is not automatic, the player has to press the button each time.
        if(Input.GetButtonDown("Fire1")&& Time.time > nextShot && isFullAuto == false){
            fire(); //fire gun
            audioSource.Play(); //play gun shots
        }
    }


    void Start(){
        audioSource = GetComponent<AudioSource>(); //grabs the audio source for the gun shots
    }

    //fires gun when called
    void fire(){
        nextShot = Time.time + fireRate; //sets the next shot time
        //creates the bullet and sets its position and rotation
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed; //sets the velocity of the bullet
    }

}
