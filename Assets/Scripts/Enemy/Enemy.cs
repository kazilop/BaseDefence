using UnityEngine;

[CreateAssetMenu(fileName = "Enemies")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public float speed;
    public float maxHealth;
    public float attack;
    public GameObject model;
    
    private GameObject target;


    public void Move() { }
    
    public void Atack() { }
    
    private void FindTarget() { }

}
