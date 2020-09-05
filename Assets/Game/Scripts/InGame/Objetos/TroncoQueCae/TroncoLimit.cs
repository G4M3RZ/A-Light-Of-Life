using UnityEngine;

public class TroncoLimit : MonoBehaviour
{
    [Range(0, 50)]
    public float _limit;
    private Rigidbody2D _rgb;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(transform.localPosition.y <= -_limit)
            _rgb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}