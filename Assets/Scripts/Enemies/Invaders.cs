using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    [Header("Invaders")]
    public Enemy[] prefabs;
    public float missileSpawnRate = 1f;
     [Header("Grid")]
    public int rows = 5;
    public int columns = 11;

    private Vector3 _direction = Vector3.right;
    public AnimationCurve speed = new AnimationCurve();

    private float PercentKilled;

    private int TotalEnemies, EnemiesKilled;

   private void Awake()
    {
        // Form the grid of invaders
        for (int i = 0; i < rows; i++)
        {
            float width = 2f * (columns - 1);
            float height = 2f * (rows - 1);

            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, (2f * i) + centerOffset.y, 0f);

            for (int j = 0; j < columns; j++)
            {
                // Create an invader and parent it to this transform
                Enemy invader = Instantiate(prefabs[i], transform);

                // Calculate and set the position of the invader in the row
                Vector3 position = rowPosition;
                position.x += 2f * j;
                invader.transform.localPosition = position;
            }
        }
    }
    // Update is called once per frame
    private void Start(){
        TotalEnemies = rows*columns;
        InvokeRepeating(nameof(MissileAttack), missileSpawnRate, missileSpawnRate);
    }
    private void Update()
    {
        EnemiesKilled = gameManager.enemiesDefeated;
        PercentKilled = (float)EnemiesKilled/(float)TotalEnemies;
        float speed = this.speed.Evaluate(PercentKilled);
        transform.position += _direction*speed*Time.deltaTime;
        
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

         foreach (Transform invader in transform)
        {
            // Skip any invaders that have been killed
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            // Check the left edge or right edge based on the current direction
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1f))
            {
                AdvanceRow();
                break;
            }
            else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1f))
            {
                AdvanceRow();
                break;
            }
        }
        
    }
    private void AdvanceRow()
    {
        // Flip the direction the invaders are moving
        _direction = new Vector3(-_direction.x, 0f, 0f);

        // Move the entire grid of invaders down a row
        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position;
    }

    private void MissileAttack()
    {
        int amountAlive = TotalEnemies - EnemiesKilled;

        // No missiles should spawn when no invaders are alive
        if (amountAlive == 0) {
            return;
        }

        foreach (Transform invader in transform)
        {
            // Any invaders that are killed cannot shoot missiles
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            // Random chance to spawn a missile based upon how many invaders are
            // alive (the more invaders alive the lower the chance)
            if (Random.value < (1f / (float)amountAlive))
            {
                StartCoroutine(activateGun(invader));
            }
        }
    }

    IEnumerator activateGun(Transform invader)
    {
        if(invader!=null)invader.gameObject.GetComponent<Enemy>().shootMode = Enemy.ShootMode.ShootAll;
        yield return new WaitForSeconds(2f);
        if(invader!=null)invader.gameObject.GetComponent<Enemy>().shootMode = Enemy.ShootMode.None;
    }
}
