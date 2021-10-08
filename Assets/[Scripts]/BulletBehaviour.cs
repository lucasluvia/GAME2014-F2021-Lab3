using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Range(0.0f, 2.0f)] 
    public BulletManager BulletManager;
    public float Speed;
    public Bounds BulletBounds;

    void Start()
    {
        BulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0.0f, Speed, 0.0f);

        CheckBounds();
    }

    public void CheckBounds()
    {
        if (transform.position.y < BulletBounds.max)
        {
            BulletManager.ReturnBullet(this.gameObject);
        }
    }
}
