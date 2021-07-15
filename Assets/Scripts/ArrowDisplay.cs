using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDisplay : MonoBehaviour
{
    public GameObject F, B, L, R;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        F.SetActive(moveZ > 0);
        B.SetActive(moveZ < 0);
        L.SetActive(moveX < 0);
        R.SetActive(moveX > 0);
    }
}
