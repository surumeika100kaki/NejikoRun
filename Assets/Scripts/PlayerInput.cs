using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //InputActionから入力を受け取る
    private InputAction jumpAction;
    private InputAction moveAction;
    //左右キー入力をVector2として外部に提供
    public Vector2 InputMove = Vector2.zero;
    public bool IsJumpTrogger = false;



    // 各Actionは入力設定とコードを結びつけるバインド
    // バインドとは、キーやボタンとプログラム側のアクションを紐づけること
    private void Start()
    {
        //変数junpActionに登録されたボタンが押されたら反応する機能の追加
        jumpAction = InputSystem.actions.FindAction("jump");
        moveAction = InputSystem.actions.FindAction("move");
    }

    //バインドしたのAction実行
    private void Update() {
        //1.moveActionの値をVector2に変換
        InputMove = moveAction.ReadValue<Vector2>();
        if(jumpAction.triggered){
            IsJumpTrogger = true;
        }
        else
        {
            IsJumpTrogger = false;
        }
        //2.moveActionの値を参考にして左右に移動
        //3.ジャンプアクションの値を参考にしてジャンプ(Y軸の移動)の実装

    }
    //ほかのデータを参照していない疎結合なクラスがよいとされている。
    //このクラスは疎結合なクラスです
    //またInputなど使いまわすものは疎結合で、その下位のワンオフ品は疎結合でなくてもよいができるだけ結合は最小限に
}
