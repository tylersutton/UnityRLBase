using UnityEngine;

/// <summary>
/// A generic class to represent players, enemies, items, etc.
/// </summary>
public class Entity : MonoBehaviour
{
    [SerializeField] private bool blocksMovement;

    public bool BlocksMovement { get => blocksMovement; set => blocksMovement = value; }

    public virtual void AddToGameManager()
    {
        if (GetComponent<Player>())
        {
            GameManager.instance.InsertEntity(this, 0);
        }
        else
        {
            GameManager.instance.AddEntity(this);
        }
    }

    public void Move(Vector2 direction)
    {
        if (MapManager.instance.IsValidPosition(transform.position + (Vector3)direction))
        {
            transform.position += (Vector3)direction;
        }
    }

    public virtual EntityState SaveState() => new EntityState();
}