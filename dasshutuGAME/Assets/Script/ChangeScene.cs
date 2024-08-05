using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//–Y‚ê‚È‚¢

public class ChangeScene : MonoBehaviour
{

    [SerializeField,Header("SE")]
    private GameObject SEObj;

    private void Start()
    {


        FadeManager.FadeIn();

    }
    public void Onclick()
    {

        Instantiate(SEObj);
        FadeManager.FadeOut(1);

    }
}