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
        -1,-1,-1,
        -1,-1,-1,
        -1,-1,-1,
        
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



                    //4�ڂ̃I�u�W�F�N�g���u���ꂽ�Ƃ��ɁA��ڂ̃I�u�W�F�N�g���폜�i���W�ۑ��j


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


            //6,7,8
            //3,4,5
            //0,1,2

            List<int[]> lines = new List<int[]>();
            lines.Add(new int[] { 0,1,2});
            lines.Add(new int[] { 3,4,5});
            lines.Add(new int[] { 6,7,8});
            lines.Add(new int[] { 0,3,6});
            lines.Add(new int[] { 1,4,7});
            lines.Add(new int[] { 2,5,8});
            lines.Add(new int[] { 0,4,8});
            lines.Add(new int[] { 2,4,6});
            //lines.Add(new int[] { 0,5,10,15});
            //lines.Add(new int[] { 3,6,9,12});

            foreach(var v in lines)//v��lines�̒��g
            {
                bool issname = true;

                for(int i = 0; i < v.Length; i++)
                {
                    int idx0 = v[0];
                    int idx1 = v[i];

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
                if (2 <= nowPlayer) nowPlayer = 0;
            }

        }

    }
    public void Retry()
    {

        SceneManager.LoadScene("Stage1");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("Title");

    }
}
