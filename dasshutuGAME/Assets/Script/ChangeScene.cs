using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//忘れない

public class ChangeScene : MonoBehaviour
{
    
    public void Onclick()
    {

        Invoke("SceneChange", 0.5f);
        Select();

    }
    void Select()
    {

        //シーン名をここに入力
        SceneManager.LoadScene("Stage1");

    }


}
