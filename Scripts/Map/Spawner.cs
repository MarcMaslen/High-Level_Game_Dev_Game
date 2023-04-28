using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public float delayTime = 10f;
    public int zombiesSpawned = 0;
    public float startTime = 10f;
   

    IEnumerator Start()
    {
        //Spawns zombie and waits a set amount of time before spawning another.
        var obj = Instantiate(zombie, transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(Start());
        zombiesSpawned++;
        
        //If 10 zombies have spawned and delayed time is grater then 5, decrease spawn time by 0.2f
        if(zombiesSpawned == 10 && delayTime > 5f){
            delayTime -= .2f;
            zombiesSpawned = 0;
        }
    }
}
