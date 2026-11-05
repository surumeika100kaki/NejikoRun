using UnityEngine;

public class NejikoMove : MonoBehaviour
{
    //目的：ねじ子の移動を制御するスクリプト
    //ねじ子の移動
    //1mをmoveSpeed秒で移動する

    [SerializeField] private float moveSpeed = 1.0f;
    //ねじ子の移動は毎フレーム必ず行われます
    private void Update()
    {
        //1mをmoveSpeed秒で移動するための移動量を計算する
        float movePower = Time.deltaTime * moveSpeed;
        //1秒間に60fps　-> 10fps
        //1fps -> 1m
        //1秒間に60fps -> 1m*60fps = 60m
        //1秒間に10fps -> 1m*10fps = 10m
        //Time.deltaTimeは前フレームからの経過時間を返す
        //1秒間に60fps -> 1/60秒
        //1秒間に10fps -> 1/10秒
        //moveSpeed = 10;
        //1秒間に60fps -> 1/60秒 / 10 = 1/600
        //1秒間に10fps -> 1/10秒 / 10 = 1/100
        //time.deltaTimeを使うとスペックに関係なく移動量を一定に出来る

        //ねじ子の位置を移動させる
        transform.Translate(0, 0, movePower);

        //ねじ子のアニメーションの遷移
        if(movePower > 0)
        {
            GetComponent<Animator>().SetBool("run",true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run",false);
        }

        moveSpeed += 0.01f;
    }
}
