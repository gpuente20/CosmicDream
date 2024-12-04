using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class obstaclesScript : MonoBehaviour
{
    public float velocidad = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * velocidad);
        transform.Translate(Vector2.down * Time.deltaTime * velocidad);

    }
}
