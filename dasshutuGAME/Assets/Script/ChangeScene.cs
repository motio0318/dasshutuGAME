using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�Y��Ȃ�

public class ChangeScene : MonoBehaviour
{
    
    public void Onclick()
    {

        Invoke("SceneChange", 1.0f);
        Select();

    }
    void Select()
    {

        //�V�[�����������ɓ���
        SceneManager.LoadScene("Stage1");

    }


}
