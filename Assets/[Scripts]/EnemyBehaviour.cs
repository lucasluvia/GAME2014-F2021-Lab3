using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")]
    public Bounds MovementBounds;
    public Bounds StartingRange;

    [Header("Bullets")] 
    public BulletManager BulletManager;
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public int FrameDelay;

    private float StartingPoint;
    private float RandomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpeed = Random.Range(MovementBounds.min, MovementBounds.max);
        StartingPoint = Random.Range(StartingRange.min, StartingRange.max);
        BulletManager = GameObject.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, RandomSpeed) + StartingPoint, transform.position.y);
    }

    void FixedUpdate()
    {
        if (Time.frameCount % FrameDelay == 0)
        {
            //var temp_bullet = Instantiate(bulletPrefab);
            //temp_bullet.transform.position = bulletSpawn.position;

            BulletManager.GetBullet(BulletSpawn.position);
        }
    }
}
