using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Rigidbody bulletGO;
    [SerializeField]
    private int moveCount;

    [SerializeField]
    private Transform[] movementPoints;

    private int currentPointIndex;

    private void Start()
    {
        //HACK: This is to ensure central point can move leftwards and rightwards.
        currentPointIndex = 3;

        if (movementPoints == null || movementPoints.Length == 0)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPointIndex > 0)
        {
            currentPointIndex--;
            transform.position = movementPoints[currentPointIndex].position;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPointIndex < movementPoints.Length - 1)
        {
            currentPointIndex++;
            transform.position = movementPoints[currentPointIndex].position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        Rigidbody bulletInstance = Instantiate(bulletGO, transform.position + (Vector3.up * 2.5F), transform.rotation);
        
    }

    public override void die()
    { }
}