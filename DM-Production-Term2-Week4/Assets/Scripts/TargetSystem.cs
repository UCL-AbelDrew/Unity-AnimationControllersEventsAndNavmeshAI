using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    [SerializeField]
    private float m_health;

    [SerializeField]
    private GameObject m_prefabMe;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyMe();
        }
    }

    
    void DestroyMe()
    {
        SpawnNewMe();
        Destroy(this.gameObject);
    }

    void SpawnNewMe()
    {
        // Instantiate the projectile at the position and rotation of this transform
        GameObject clone;
        clone = Instantiate(m_prefabMe, RandomSpawnPos(), transform.rotation);

      
    }

    private Vector3 RandomSpawnPos()
    {
        Vector3 value = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
        return value;
    }

    public void ApplyDamage(float damage = 0)
    {
        m_health -= damage;
        if (m_health <=0)
        {
            DestroyMe();
        }
    }
}
