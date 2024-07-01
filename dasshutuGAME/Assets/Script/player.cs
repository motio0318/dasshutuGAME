using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField] GameObject clickedGameObject;
    [SerializeField] GameObject maruObject;


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0))
        {

            clickedGameObject = null;

            //メインカメラから光線を出す
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //光線にあたったオブジェクトを取得
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if(hit2D)
            {
                maruObject.SetActive(true);
                if (maruObject == true)
                    Debug.Log(maruObject);
                //光線にあたったオブジェクトのGameObjectを取得する
                clickedGameObject = hit2D.transform.gameObject;
            }


            Debug.Log(clickedGameObject);
        }
    }
}
