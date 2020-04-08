using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject _target;
    [SerializeField] private Vector2 Force;
    [SerializeField] private float speed;

    private void Start()
    {
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        //gameObject.transform.SetPositionAndRotation(_target.transform.position * speed * Time.deltaTime, Quaternion.identity);
    }
}
