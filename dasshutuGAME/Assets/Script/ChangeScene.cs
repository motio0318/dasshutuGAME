using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�Y��Ȃ�

public class ChangeScene : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject EndButton;
    

    void Select()
    {

        StartButton.SetActive(false);
        EndButton.SetActive(false);

    }


}
