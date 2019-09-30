using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateMrSquare : MonoBehaviour
{
    [SerializeField]
    private float bobStrength;

    [SerializeField]
    private float bobSpeed;

    private float originalPositionX;
    private float originalPositionY;

    void Start ()
    {
        originalPositionX = transform.position.x;
        originalPositionY = transform.position.y;
    }
	
	void Update ()
    {
        transform.position = new Vector2(originalPositionX + ((float)Mathf.Sin(Time.time * bobSpeed) * bobStrength),
            originalPositionY + ((float)Mathf.Sin(Time.time * bobSpeed) * bobStrength));
    }
}
