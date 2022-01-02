using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField]
    private GameObject step, stepSpike, stepBreakable;
    [SerializeField]
    private GameObject[] stepMover;
    [SerializeField]
    private float createTimer = 2f;
    

    private float minX = -2f , maxX = 2f;
    private float currentStepCreateTimer;
    private int stepCount = 0;

    void Start()
    {
        currentStepCreateTimer = createTimer;
    }

    void Update()
    {
        createSteps();
    }

    void createSteps()
    {
        currentStepCreateTimer += Time.deltaTime;

        if (currentStepCreateTimer >= createTimer)
        {
            stepCount++;
            Vector2 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newStep = null;

            if (stepCount < 2)
            {
                newStep = Instantiate(step, temp, Quaternion.identity);
            } 
            else if (stepCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newStep = Instantiate(step, temp, Quaternion.identity);
                } 
                else
                {
                    newStep = Instantiate(stepMover[Random.Range(0, stepMover.Length)], temp, Quaternion.identity);
                }
            }
            else if (stepCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newStep = Instantiate(step, temp, Quaternion.identity);
                }
                else
                {
                    newStep = Instantiate(stepSpike, temp, Quaternion.identity);
                }
            }
            else if (stepCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newStep = Instantiate(step, temp, Quaternion.identity);
                }
                else
                {
                    newStep = Instantiate(stepBreakable, temp, Quaternion.identity);
                }

                stepCount = 0;
            }

            newStep.transform.parent = transform;
            currentStepCreateTimer = 0;

        }
    }
}
