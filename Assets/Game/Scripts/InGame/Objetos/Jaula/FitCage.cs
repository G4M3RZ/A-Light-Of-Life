using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitCage : MonoBehaviour
{
    public SpriteRenderer _sprChain;

    void Update()
    {
        transform.localPosition = new Vector2(0, -_sprChain.size.y);
    }
}
