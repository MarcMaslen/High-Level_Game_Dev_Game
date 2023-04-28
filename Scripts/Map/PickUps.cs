using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{

    //Used in Lab 1 and is used to rotate my HP pack
    void Update(){
      transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }

    
    
}
