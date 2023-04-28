using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Animator fade;
    public int SceneToLoad;

    //when the fade animation is done, load the scene
    public void FadeOut(int index){
        SceneToLoad = index;
        fade.SetTrigger("FadeOut");
    }

    //load the scene
    public void loadScene(){
        SceneManager.LoadScene(SceneToLoad);
    }
}



