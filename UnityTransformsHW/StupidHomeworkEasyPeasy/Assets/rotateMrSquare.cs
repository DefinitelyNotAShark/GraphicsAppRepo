using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateMrSquare : MonoBehaviour
{
    [SerializeField]
    private float amount;

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 0, amount * Time.deltaTime);
	}
}
