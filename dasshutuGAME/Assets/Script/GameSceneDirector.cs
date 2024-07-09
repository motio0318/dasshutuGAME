using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneDirector : MonoBehaviour
{

    public GameObject PrefabCircle;
    public GameObject PrefabCross;
    public GameObject Reslut;
    public GameObject TextResult;

    int nowPlayer;

    int[] board =
    {
        -1,-1,-1,-1,
        -1,-1,-1,-1,
        -1,-1,-1,-1,
        -1,-1,-1,-1,
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //���ɍs�����ǂ���
        bool next = false;

        //�u���ꏊ
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(null != hit.collider)
            {

                Vector3 pos = hit.collider.gameObject.transform.position;

                //�擾�������W����z��ԍ��ɖ߂�
                int x = (int)pos.x + 1;
                int y = (int)pos.y + 1;

                int idx = x + y * 3;

                //�����u����Ă��Ȃ����
                if(-1 == board[idx])
                {
                    GameObject prefab = PrefabCircle;
                    if (1 == nowPlayer) prefab = PrefabCross;

                    Instantiate(prefab, pos, Quaternion.identity);

                    board[idx] = nowPlayer;
                    next = true;

                }
            }
        }

        //���s�`�F�b�N
        if (next)
        {
            bool win = false;

            //12,13,14,15
            // 8, 9,10,11
            // 4, 5, 6, 7
            // 0, 1, 2, 3
            List<int[]> lines = new List<int[]>();
            lines.Add(new int[] { 0,1,2,3});
            lines.Add(new int[] { 4,5,6,7});
            lines.Add(new int[] { 8,9,10,11});
            lines.Add(new int[] { 12,13,14,15});
            lines.Add(new int[] { 0,4,8,12});
            lines.Add(new int[] { 1,5,9,13});
            lines.Add(new int[] { 2,6,10,14});
            lines.Add(new int[] { 3,7,11,15});
            lines.Add(new int[] { 0,5,10,15});
            lines.Add(new int[] { 3,6,9,12});

            foreach(var v in lines)//v��lines�̒��g
            {
                bool issname = true;

                for(int i = 0; i < v.Length; i++)
                {
                    int idx0 = v[0];
                    int idx1 = v[1];

                    //������ĂȂ��p�^�[��1
                    if (0 > board[idx1] || board[idx0] != board[idx1]) issname = false;

                }
                if(issname)
                {
                    win = true;
                }
            }

            //���s�`�F�b�N
            if(win)
            {
                Reslut.SetActive(true);
                TextResult.GetComponent<Text>().text = (nowPlayer + 1) + "P�̏����I";
            }
            else
            {

                nowPlayer++;
            }

        }

    }
    public void Retry()
    {

        SceneManager.LoadScene("Stage1");
    }
}
