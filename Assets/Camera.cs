using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}
