using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float shootSpeed;

    protected int vida;
    [SerializeField]
    private Rigidbody[] bulletGO;

    [SerializeField]
    
    private bool startedShoot;
    private RaycastHit rayInfo;
    protected int puntajeDar;




    // Use this for initialization
    private void Start()
    {
        if (bulletGO == null)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 1000F), Color.black);
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out rayInfo, 1000F) && !startedShoot)
        {
            if (rayInfo.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            {
                print("Shooting");
                startedShoot = true;
                Shoot();
                StartCoroutine(ToggleShootCR());
            }
        }
    }

    private IEnumerator ToggleShootCR()
    {
        yield return new WaitForSeconds(4F);
        startedShoot = false;
    }

    private void Shoot()
    {
        int i = Random.Range(0, bulletGO.Length);
        Rigidbody bulletInstance = Instantiate(bulletGO[i], transform.position + (Vector3.down * 2.5F), transform.rotation);
        bulletInstance.AddForce((transform.up * -1F) * shootSpeed, ForceMode.Impulse);
    }
}