using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollowHead : MonoBehaviour
{
    public GameObject head;

    void Update()
    {
        this.transform.position = new Vector3(head.transform.position.x, this.transform.position.y, head.transform.position.z);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, head.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
    }
}
