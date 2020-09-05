using UnityEngine;

public class ActivarCheckpoint : MonoBehaviour
{
    private GameObject _luz;
    private Animator _checkpoint;
    private LightSmartRender _lsr;
    public bool _activar;

    private void Awake()
    {
        _luz = transform.GetChild(0).gameObject;
    }
    void Start()
    {
        _activar = false;
        _luz.SetActive(false);
        _checkpoint = GetComponent<Animator>();
        _lsr = GetComponent<LightSmartRender>();
    }
    private void Update()
    {
        _checkpoint.SetBool("_activar", _activar);

        if (_activar)
        {
            _luz.SetActive(true);
            _lsr._active = true;
            Destroy(this);
        }
    }
}