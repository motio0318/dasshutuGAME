using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�Y��Ȃ�

public class Hoeto : MonoBehaviour
{


    private void Start()
    {


        FadeManager.FadeIn();

    }
    public void Onclick()
    {


        FadeManager.FadeOut(2);

    }
}