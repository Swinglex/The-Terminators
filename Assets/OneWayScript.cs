using System.Collections;
using UnityEngine;

public class OneWayScript : MonoBehaviour
{
    public bool coll;
    public PlatformEffector2D platform;

 
    void Update()
    {
        if (coll && Input.GetKey(KeyCode.S))
        {
            platform.surfaceArc = 0f;
            StartCoroutine(Wait());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        coll = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        coll = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        platform.surfaceArc = 125f;
    }
}
