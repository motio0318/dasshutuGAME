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

            //���C���J��������������o��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //�����ɂ��������I�u�W�F�N�g���擾
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if(hit2D)
            {
                maruObject.SetActive(true);
                if (maruObject == true)
                    Debug.Log(maruObject);
                //�����ɂ��������I�u�W�F�N�g��GameObject���擾����
                clickedGameObject = hit2D.transform.gameObject;
            }


            Debug.Log(clickedGameObject);
        }
    }
}
