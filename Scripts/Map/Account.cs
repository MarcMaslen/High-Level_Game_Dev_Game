using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Account : MonoBehaviour
{
    //After the first animation is done, load the Account selection scene
    public void game(){
        Debug.Log("Account Select");
        SceneManager.LoadScene("AccountSelect");
    }
}
