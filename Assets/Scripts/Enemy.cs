using System.Collections;
using UnityEngine;

public abstract class Enemy : Character
{
    private float shootSpeed;
    private float pos;
    protected int vida;
    [SerializeField]
    private Rigidbody[] bulletGO;

    [SerializeField]
    
    private bool startedShoot;
    private RaycastHit rayInfo;
    protected int puntajeDar;
    protected Mananger contador;
    private int PuntosDados;



    // Use this for initialization
    private void Start()
    {
        pos = transform.position.y;
        if (bulletGO == null)
        {
            contador = GameObject.Find("Main Camera").GetComponent<Mananger>();
            enabled = false;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        pos -= 0.05f;
        transform.position = new Vector3(transform.position.x, pos, transform.position.z);

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

    public override void Shoot()
    {
        int i = Random.Range(0, bulletGO.Length);
        Rigidbody bulletInstance = Instantiate(bulletGO[i], transform.position + (Vector3.down * 2.5F), transform.rotation);
        bulletInstance.AddForce((transform.up * -1F) * shootSpeed, ForceMode.Impulse);
    }
    public override void die()
    {

        contador.SumarPuntaje(PuntosDados);
    }
}