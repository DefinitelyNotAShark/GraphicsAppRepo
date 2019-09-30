using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleMrSquare : MonoBehaviour
{
    [SerializeField]
    private float amount;
	
	void Update ()
    {
        transform.localScale = new Vector2
            (transform.localScale.x + amount/2 + Time.deltaTime,
             transform.localScale.y + amount + Time.deltaTime);
	}
}
