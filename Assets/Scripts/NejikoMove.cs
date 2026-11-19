using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NejikoMove : MonoBehaviour
{
    //目的：ねじ子の移動を制御するスクリプト
    //ねじ子の移動
    //1mをmoveSpeed秒で移動する

    [SerializeField] private float moveSpeed = 1.0f;
    //ねじ子の移動は毎フレーム必ず行われます
    [SerializeField] private float _junpPower = 2.0f;
    [SerializeField] private float _junpHeight = 2.5f;
    [SerializeField] private float _fallSpeed = 10;
    [SerializeField] private PlayerInput _playerInput = null;
    //左右移動量の値
    [SerializeField] private int _axisMovePower = 1;
    //ジャンプしているか
    [SerializeField] private bool _isFlayFlag = false;
    [SerializeField] private bool _isJunpFlag = false;
    private float _Timer =0;
    private bool _isMoveKyeInput = false;
    private float _initialHeight = 0;

    public void State()
    {
        _initialHeight = transform.position.y;
    }
    private void Update()
    {
        #region 11/5
        #region 1mをmoveSpeed秒で移動するための移動量を計算する
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
        #endregion
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
        #endregion
        #region 11/12
        if(_playerInput.InputMove.x == 0)
        {
            _isMoveKyeInput = false;
        }
        if(_playerInput.InputMove.x > 0 && !_isMoveKyeInput && transform.position.x < 1.5f)//inputMove.xが正の値　=　右キーの入力
        {
            transform.Translate(_axisMovePower,0,0);
            _isMoveKyeInput = true;
            Debug.Log($"右に移動:{_isMoveKyeInput}");
        }
        else if(_playerInput.InputMove.x < 0 && !_isMoveKyeInput && transform.position.x > -1.5f)//inputMove.xが不の値　=　左キーの入力
        {
            transform.Translate(-1*_axisMovePower,0,0);
            _isMoveKyeInput = true;
            Debug.Log($"左に移動:{_isMoveKyeInput}");
        }
        #endregion
        //ジャンプ
        if (_playerInput.IsJumpTrogger && !_isFlayFlag || _isJunpFlag)
        {
            //transform.Translate(0,_junpPower,0);
            if(transform.position.y <= _junpHeight)
            {
                transform.position += Vector3.up / _junpPower * _Timer;
                _isJunpFlag = true;
                _Timer += Time.deltaTime;
                return;
            }
            _isJunpFlag = false;
            Debug.Log($"ジャンプ:{_junpPower}");
            _isFlayFlag = true;
            _Timer = 0;
        }
        else if(_isFlayFlag)
        {
            if(transform.position.y <= _initialHeight)
            {
                this.transform.position = new Vector3(transform.position.x, _initialHeight, transform.position.z);
                _isFlayFlag = false;
                return;
            }
            //transform.Translate(0,-Time.deltaTime * _gravity,0);
            transform.position -= Vector3.up / _fallSpeed * _Timer;
            _Timer += Time.deltaTime;
        }


    }
}