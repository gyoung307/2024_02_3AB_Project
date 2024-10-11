using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Player TargetPlayer;
    public Enemy TargetEnemy;

    public List<ISkillTarget> target  = new List<ISkillTarget>();



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            var fireball = new Skill<ISkillTarget, DamageEffect>("Fireball", new DamageEffect(20));
            fireball.Use(TargetEnemy);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var healSpell = new Skill<Player, HealEffect>("Heal", new HealEffect(20));
            healSpell.Use(TargetPlayer);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var multiTargetSkill = new Skill<ISkillTarget, DamageEffect>("AoE Attack", new DamageEffect(10));
            foreach(var target in target)
            {
                multiTargetSkill.Use(target);
            }
        }
    }
}
