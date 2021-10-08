using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> BulletPool;
    public int BulletNumber;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        BulletPool = new Queue<GameObject>();

        BuildBulletPool();
    }

    public void BuildBulletPool()
    {
        for (int i = 0; i < BulletNumber; i++)
        {
            var temp_bullet = Instantiate(BulletPrefab);
            temp_bullet.SetActive(false);
            temp_bullet.transform.parent = transform;
            BulletPool.Enqueue(temp_bullet);

        }
    }

    public GameObject GetBullet(Vector2 position)
    {
        var temp_bullet = BulletPool.Dequeue();
        temp_bullet.transform.position = position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        BulletPool.Enqueue(bullet);
    }
}
