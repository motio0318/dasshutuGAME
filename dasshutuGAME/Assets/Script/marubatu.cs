using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marubatu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
                }
            }
        }
}
