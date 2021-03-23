using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;
    public float time = 1f;

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    LoadLevel();
        //}
    }
    public void LoadLevel()
    {
        //SceneManager.LoadScene("Underground");
        StartCoroutine(Load(1));
    }

    IEnumerator Load(int index){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }
}
