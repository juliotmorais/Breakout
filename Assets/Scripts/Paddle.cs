using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]float screenWidthInUnits=16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mosPosX= (Input.mousePosition.x/Screen.width*screenWidthInUnits);
        Vector2 paddlePosX = new Vector2(mosPosX,0.5f);
        transform.position = paddlePosX;
    }
}
