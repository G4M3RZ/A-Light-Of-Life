using UnityEngine;

public class Lamp : MonoBehaviour {

    public GameObject _luz;
    private ControladorLuces _controller;
    private LightSmartRender _lsr;

    [HideInInspector] public int _num;
    [HideInInspector] public bool _lightEnable;

    void Awake()
    {
        _luz = transform.GetChild(0).gameObject;
        _controller = GetComponentInParent<ControladorLuces>();
        _lsr = GetComponent<LightSmartRender>();
    }
	void Update ()
    {
        if (_lightEnable && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Z)))
        {
            _controller._numSelected.Add(_num + 1);
            _luz.SetActive(true);
            _lsr._active = true;
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            _lightEnable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _lightEnable = false;
    }
}