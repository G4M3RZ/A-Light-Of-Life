using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [Range(0,10)]
    public float _rayDistance;
    public LayerMask _contacto;
    private RaycastHit2D _hit;

    private Rigidbody2D _rgb;

    private void Start()
    {
        _rgb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        RayCast(_rayDistance);
    }
    private void RayCast(float _distance)
    {
        Physics2D.queriesStartInColliders = false;
        for (int i = 0; i < 2; i++)
        {
            _hit = Physics2D.Raycast(transform.position, transform.position + Vector3.right, _distance, _contacto);
            Debug.DrawLine(transform.position, transform.position + Vector3.right * _distance);
            if (_hit.collider != null)
            {
                if (_hit.collider.CompareTag("Wall"))
                    _rgb.velocity = new Vector2(0, _rgb.velocity.y);
            }

            _distance = -_distance;
        }
    }
}
