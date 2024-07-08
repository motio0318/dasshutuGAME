using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField] GameObject clickedGameObject;
    [SerializeField] GameObject maruObject;


    // Update is called once per frame

   public void Onclick()
    {
        maruObject.gameObject.SetActive(true);
    }
}
