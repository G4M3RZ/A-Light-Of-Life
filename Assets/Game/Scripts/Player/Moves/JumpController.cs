using UnityEngine;

public class JumpController : MonoBehaviour {

    [Range(0, 30)]
    public float _jumpForce;

    public bool _grounded;
    public bool _canJump;

    public Rigidbody2D rgbd;

    [Range(0, 5)]
    public float _raycastDistance = 4f;

    private Vector3 _izq, _der;

    void Start()
    {
        _grounded = false;
        rgbd = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        SimuladorGravedad();
    }
    void SimuladorGravedad()
    {
        _izq = new Vector3(transform.position.x - 0.6f, transform.position.y, 0f);
        _der = new Vector3(transform.position.x + 0.6f, transform.position.y, 0f);

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(_izq, Vector2.down * 1, _raycastDistance);
        RaycastHit2D hit2 = Physics2D.Raycast(_der, Vector2.down * 1, _raycastDistance);

        #region HitRaycast
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Suelo" || hit.collider.tag == "WallJump" || hit.collider.tag == "Resvaladiso")
            {
                _grounded = true;
            }
        }
        else if (hit2.collider != null)
        {
            if (hit2.collider.tag == "Suelo" || hit2.collider.tag == "WallJump" || hit2.collider.tag == "Resvaladiso")
            {
                _grounded = true;
            }
        }
        else
        {
            _grounded = false;
        }
        #endregion

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && _grounded && _canJump)
        {
            rgbd.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _grounded = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_izq, _izq + Vector3.down * 1 * _raycastDistance);
        Gizmos.DrawLine(_der, _der + Vector3.down * 1 * _raycastDistance);
    }
}
