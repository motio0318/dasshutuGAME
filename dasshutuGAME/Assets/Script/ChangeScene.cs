using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//–Y‚ê‚È‚¢

public class ChangeScene : MonoBehaviour
{


    private void Start()
    {


        FadeManager.FadeIn();

    }
    public void Onclick()
    {


        FadeManager.FadeOut(1);

    }
}