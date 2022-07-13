using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float Input_h = Input.GetAxisRaw("Horizontal");
        float Input_v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(Input_h, 0, Input_v);

        rigid.AddForce(vec, ForceMode.Impulse);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().End();
    }
}
