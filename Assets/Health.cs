using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHP;
    private int hp;

	// Use this for initialization
	void Start () {
        hp = maxHP;
	}
	
	public int removeHP(int amount)
    {
        hp -= amount;
        if (hp < 0)
            hp = 0;
        return hp;
    }

    public int addHP(int amount)
    {
        hp += amount;
        if (hp > maxHP)
            hp = maxHP;
        return hp;
    }

    public int getHP()
    {
        return hp;
    }
}
