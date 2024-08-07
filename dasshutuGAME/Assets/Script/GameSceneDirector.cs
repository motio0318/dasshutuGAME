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
    public GameObject SE;
    public Text PlayerTurnText;
    private int nowPlayer = 0;  // 現在のプレイヤー
    private int[] board = new int[9];  // ボードの状態を表す配列
    private List<GameObject> placedCircles = new List<GameObject>(); // ○のオブジェクトを格納するリスト
    private List<GameObject> placedCrosses = new List<GameObject>(); // ×のオブジェクトを格納するリスト
    private bool gameWon = false; // 勝利状態を表すフラグ
    void Start()
    {
        // ボードの初期化
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = -1;
        }
        UpdatePlayerTurnText(); // ゲーム開始時にプレイヤーターンを表示
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            HandleInput();
        }
    }
    private void HandleInput()
    {
        if (gameWon) return; // 勝利時に入力を無視する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            Vector3 pos = hit.collider.gameObject.transform.position;
            // 座標から配列番号に変換
            int idx = (int)(pos.x + 1) + (int)(pos.y + 1) * 3;
            if (board[idx] == -1)
            {
                PlaceObject(pos, idx);
            }
        }
    }
    private void PlaceObject(Vector3 pos, int idx)
    {
        GameObject prefab;
        List<GameObject> placedObjects;
        if (nowPlayer == 0)
        {
            prefab = PrefabCircle;
            placedObjects = placedCircles;
        }
        else
        {
            prefab = PrefabCross;
            placedObjects = placedCrosses;
        }
        GameObject newObject = Instantiate(prefab, pos, Quaternion.identity);
        placedObjects.Add(newObject);
        // 配置されたオブジェクトが4つを超えた場合、最初のオブジェクトを削除
        if (placedObjects.Count > 3)
        {
            GameObject objectToRemove = placedObjects[0];
            placedObjects.RemoveAt(0);
            Destroy(objectToRemove);
            // 配列も更新する
            int removeX = (int)objectToRemove.transform.position.x + 1;
            int removeY = (int)objectToRemove.transform.position.y + 1;
            int removeIdx = removeX + removeY * 3;
            board[removeIdx] = -1;
        }
        board[idx] = nowPlayer;
        if (CheckWin())
        {
            SE.SetActive(false);
            Reslut.SetActive(true);
            TextResult.GetComponent<Text>().text = (nowPlayer + 1) + "Pの勝ち！";
            PlayerTurnText.gameObject.SetActive(false); // 勝利時にプレイヤーターンのテキストを非表示にする
            gameWon = true; // 勝利フラグを設定
        }
        else
        {
            nowPlayer = (nowPlayer + 1) % 2;
            UpdatePlayerTurnText(); // ターンが切り替わるたびにテキストを更新
        }
    }
    private void UpdatePlayerTurnText()
    {
        if (nowPlayer == 0)
        {
            PlayerTurnText.text = "○のターンです";
        }
        else
        {
            PlayerTurnText.text = "×のターンです";
        }
    }
    private bool CheckWin()
    {
        List<int[]> lines = new List<int[]>
       {
           new int[] { 0, 1, 2 },
           new int[] { 3, 4, 5 },
           new int[] { 6, 7, 8 },
           new int[] { 0, 3, 6 },
           new int[] { 1, 4, 7 },
           new int[] { 2, 5, 8 },
           new int[] { 0, 4, 8 },
           new int[] { 2, 4, 6 }
       };
        foreach (var line in lines)
        {
            if (board[line[0]] != -1 && board[line[0]] == board[line[1]] && board[line[1]] == board[line[2]])
            {
                return true;
            }
        }
        return false;
    }
    public void Retry()
    {
        gameWon = false; // 勝利フラグをリセット
        SceneManager.LoadScene("Stage1");
    }
    public void TitleScene()
    {
        gameWon = false; // 勝利フラグをリセット
        SceneManager.LoadScene("Title");
    }
}