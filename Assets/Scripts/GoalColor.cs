using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this script changes the goal color (the final platfrom) and I'm thinking it can load level 2 when called

public class GoalColor : MonoBehaviour

{
    SpriteRenderer spriteRenderer;
    [SerializeField] Color32 goalColor = new Color32(1, 1, 1, 1);
    public float goalValuePlayer1 = 0f;
    public float goalValuePlayer2 = 0f;
    public bool gameHasEnded = false;
    private static int level = 0; // You start on level 0 "Level 1"

    void Start() {
        StartCoroutine(endGame());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D target)
        {
            if (target.gameObject.tag == "Player")
                
            {
                goalValuePlayer1 = goalValuePlayer1 + 1;
            }

            else if (target.gameObject.tag == "Player2")

            {
                goalValuePlayer2 = goalValuePlayer2 + 1;
        }

    }

    private IEnumerator endGame() {
            yield return new WaitUntil(() => gameHasEnded);
            yield return new WaitForSecondsRealtime(2);
            
            level++;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
            SceneManager.LoadScene(level);
            Debug.Log("Loading Level: " + level);
    }

    private void Update()
    {
        if (goalValuePlayer1 > 1 && goalValuePlayer2 > 1)
        {
            spriteRenderer.color = goalColor;
            gameHasEnded = true;
        }
    }

}