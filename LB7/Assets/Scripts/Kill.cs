using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera currentCamera;
    public Text score;

    private static int points = 0;
    private GameObject marker;
    void Start()
    {
        currentCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == "Enemy" || 
                    hit.collider.gameObject.name == "EnemySphere")
                {
                    marker = GameObject.Find("Enemy Marker");
                    Destroy(hit.collider.gameObject);
                    Destroy(marker);

                    points++;
                    PlayerScore(points);
                }
            }
        }
    }

    public void PlayerScore(int point)
    {
        Debug.Log("Gained point!");
        score.text = "Score:" + point;
    }
}
