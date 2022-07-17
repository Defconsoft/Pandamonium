using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPandaAttack : MonoBehaviour
{
    public GameObject pandaPrefab;
    private Vector3 randomOffset;
    public float attackRange = 0.5f;
    public int pandaAmount = 10;

    void OnEnable()
    {
        StartCoroutine(PandaAttack());
    }

    private IEnumerator PandaAttack()
    {
        yield return new WaitForSeconds(0.1f);

        Vector3 currentPos = transform.position;
        for (int i = 0; i < pandaAmount; i++)
        {
            randomOffset = Random.insideUnitCircle * attackRange;
            Instantiate(pandaPrefab, transform.position + randomOffset, Quaternion.identity, transform);
        }

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
