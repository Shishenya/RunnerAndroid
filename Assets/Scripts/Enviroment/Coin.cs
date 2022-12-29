using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.CallPickUpCoin();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(30f * Time.deltaTime, 0f, 0f);
    }

}
