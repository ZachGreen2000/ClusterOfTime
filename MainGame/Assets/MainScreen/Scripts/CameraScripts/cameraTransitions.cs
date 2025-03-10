using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera Camera;
    public Camera Camera2;

    void Start()
    {
        StartCoroutine(Transition());

        Camera.gameObject.SetActive(true);
        Camera2.gameObject.SetActive(false);
    }


    public float transitionDuration = 10f;
    public Transform target;
    IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);

            transform.position = Vector3.Lerp(startingPos, target.position, t);
            yield return 0;

        }
        Camera.gameObject.SetActive(false);
        Camera2.gameObject.SetActive(true);
    }
}
