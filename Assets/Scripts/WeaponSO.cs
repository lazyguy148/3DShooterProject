using UnityEngine;
[CreateAssetMenu(fileName = "SO", menuName = "Scriptable Objec/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject HitVFXPrefab;
    public bool isAutomatic = false;

}
