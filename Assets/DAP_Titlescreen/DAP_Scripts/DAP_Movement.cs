using System;
using UnityEngine;

public class DAP_Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11, true);
        Physics2D.IgnoreLayerCollision(10, 11, true);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0f, 0f));
    }

    private void OnDestroy()
    {
        DAP_ScoreMultiplier.StopScript = true;
    }
}
