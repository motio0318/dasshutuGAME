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

        //次に行くかどうか
        bool next = false;

        //置く場所
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(null != hit.collider)
            {

                Vector3 pos = hit.collider.gameObject.transform.position;

                //取得した座標から配列番号に戻す
                int x = (int)pos.x + 1;
                int y = (int)pos.y + 1;

                int idx = x + y * 3;

                //何も置かれていなければ
                if(-1 == board[idx])
                {
                    GameObject prefab = PrefabCircle;
                    if (1 == nowPlayer) prefab = PrefabCross;

                    Instantiate(prefab, pos, Quaternion.identity);

                    board[idx] = nowPlayer;
                    next = true;



                    //4つ目のオブジェクトが置かれたときに、一つ目のオブジェクトを削除（座標保存）


                }
            }
        }

        //勝敗チェック
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

            foreach(var v in lines)//vはlinesの中身
            {
                bool issname = true;

                for(int i = 0; i < v.Length; i++)
                {
                    int idx0 = v[0];
                    int idx1 = v[i];

                    //そろってないパターン1
                    if (0 > board[idx1] || board[idx0] != board[idx1]) issname = false;

                }
                if(issname)
                {
                    win = true;
                }
            }

            //勝敗チェック
            if(win)
            {
                Reslut.SetActive(true);
                TextResult.GetComponent<Text>().text = (nowPlayer + 1) + "Pの勝ち！";
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
