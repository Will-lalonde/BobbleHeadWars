using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public Transform target;
    public float navigationUpdate;
    private float navigationTime = 0;
    private NavMeshAgent agent;
    public UnityEvent OnDestroy;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navigationTime += Time.deltaTime;

        if(navigationTime > navigationUpdate)
        {
            agent.destination = target.position;
            navigationTime = 0;
        }

        if(target != null)
        {
            agent.destination = target.position;
        }
    }


    public void Die()
    {
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        Die();
    }


}
