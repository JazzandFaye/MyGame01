using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel  {
    public int Id { get; set; }//武器编号
    public string Name { get; set; }//武器名字
    public int Atk { get; set; }//武器攻击力加成
    public int AtkRadius { get; set; }//攻击距离半径
    public int AtkSpeed { get; set; }//攻击速度加成
    public List<SkillModel> Skill { get; set; }//附加技能

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="atk"></param>
    /// <param name="atkradius"></param>
    /// <param name="atkspeed"></param>
    /// <param name="skill"></param>
    public WeaponModel(int id, string name,int atk,int atkradius,int atkspeed,List<SkillModel> skill) {
        this.Id = id;
        this.Name = name;
        this.Atk = atk;
        this.AtkRadius = atkradius;
        this.AtkSpeed = atkspeed;
        this.Skill = skill;
    }
}
