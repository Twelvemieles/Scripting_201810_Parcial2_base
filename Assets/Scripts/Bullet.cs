using UnityEngine;

public abstract class Bullet : MonoBehaviour,IBullets
{
    private int daño;

    public int Daño
    {
        get
        {
            return daño;
        }

        set
        {
            daño = value;
        }
    }
    public abstract void Efectobala();

    protected void OnCollisionEnter(Collision other)
    {
        int otherLayer = other.gameObject.layer;

        if (otherLayer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}