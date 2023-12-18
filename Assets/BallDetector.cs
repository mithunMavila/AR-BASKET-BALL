using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    [SerializeField] private GameObject particleSystemPrefab;
    [SerializeField] private TMP_Text scoreText;

    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Increment the scores
            score++;

            // Update the UI text to display the score
            scoreText.text = score.ToString();

            // Instantiate the particle system prefab
            GameObject particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

            // Optionally, you can parent it to the CubeDetector or another GameObject
            particleSystemInstance.transform.parent = transform;

            // Destroy the particle system after 3 seconds
            Destroy(particleSystemInstance, 1f);
        }
    }
}
