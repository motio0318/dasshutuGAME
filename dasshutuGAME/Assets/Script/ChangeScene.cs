using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//–Y‚ê‚È‚¢

public class ChangeScene : MonoBehaviour
{
    
    public void Onclick()
    {

        Invoke("SceneChange", 1.0f);
        Select();

    }
    void Select()
    {

        //ƒV[ƒ“–¼‚ğ‚±‚±‚É“ü—Í
        SceneManager.LoadScene("Stage1");

    }


}
