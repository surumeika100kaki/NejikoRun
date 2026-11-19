using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _space;
    [SerializeField] private Transform _nejikoTransform;

    void Update()
    {
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            _nejikoTransform.position.z + _space
        );
    }
}
