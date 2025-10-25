using UnityEngine;

public class CameraFollowSsytem : MonoBehaviour
{
    [SerializeField] private Vector2 followOffset;
    [SerializeField] float speed;
    [SerializeField] private Transform target;

    [SerializeField] private bool isLocal = false;
    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = (target.position + (Vector3)followOffset);
        Vector3 offset = new Vector3(followPosition.x, followPosition.y, isLocal ? 0 : -10);
        if (isLocal)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, offset, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, offset, speed * Time.deltaTime);
        }
    }
}
