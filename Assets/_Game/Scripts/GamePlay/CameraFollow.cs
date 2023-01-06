using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform tf;
    [SerializeField] Transform target;

    public Vector3 offset;
    public float speed;

    private void Awake()
    {
        offset = target.position - tf.position;
    }
    private void Update()
    {
        tf.position = Vector3.Lerp(tf.position,target.position - offset,Time.deltaTime * speed);
    }
}
