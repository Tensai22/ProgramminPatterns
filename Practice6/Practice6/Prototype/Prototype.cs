using System;
using System.Collections.Generic;

public interface ICloneableEntity<T>
{
    T Clone();
}

public class GameWeapon : ICloneableEntity<GameWeapon>
{
    public string WeaponName { get; set; }
    public int AttackPower { get; set; }

    public GameWeapon(string weaponName, int attackPower)
    {
        WeaponName = weaponName;
        AttackPower = attackPower;
    }

    public GameWeapon Clone()
    {
        return new GameWeapon(WeaponName, AttackPower);
    }

    public override string ToString()
    {
        return $"{WeaponName} (Attack Power: {AttackPower})";
    }
}

public class GameArmor : ICloneableEntity<GameArmor>
{
    public string ArmorName { get; set; }
    public int DefenseValue { get; set; }

    public GameArmor(string armorName, int defenseValue)
    {
        ArmorName = armorName;
        DefenseValue = defenseValue;
    }

    public GameArmor Clone()
    {
        return new GameArmor(ArmorName, DefenseValue);
    }

    public override string ToString()
    {
        return $"{ArmorName} (Defense Value: {DefenseValue})";
    }
}

public class GameSkill : ICloneableEntity<GameSkill>
{
    public string SkillName { get; set; }
    public string SkillType { get; set; }

    public GameSkill(string skillName, string skillType)
    {
        SkillName = skillName;
        SkillType = skillType;
    }

    public GameSkill Clone()
    {
        return new GameSkill(SkillName, SkillType);
    }

    public override string ToString()
    {
        return $"{SkillName} ({SkillType})";
    }
}

public class GameCharacter : ICloneableEntity<GameCharacter>
{
    public string CharacterName { get; set; }
    public int HealthPoints { get; set; }
    public int Power { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public GameWeapon EquippedWeapon { get; set; }
    public GameArmor EquippedArmor { get; set; }
    public List<GameSkill> SkillsList { get; set; }

    public GameCharacter(string characterName, int healthPoints, int power, int agility, int intelligence, GameWeapon weapon, GameArmor armor, List<GameSkill> skills)
    {
        CharacterName = characterName;
        HealthPoints = healthPoints;
        Power = power;
        Agility = agility;
        Intelligence = intelligence;
        EquippedWeapon = weapon;
        EquippedArmor = armor;
        SkillsList = skills;
    }

    public GameCharacter Clone()
    {
        var clonedWeapon = EquippedWeapon.Clone();
        var clonedArmor = EquippedArmor.Clone();
        var clonedSkills = new List<GameSkill>();
        foreach (var skill in SkillsList)
        {
            clonedSkills.Add(skill.Clone());
        }

        return new GameCharacter(CharacterName, HealthPoints, Power, Agility, Intelligence, clonedWeapon, clonedArmor, clonedSkills);
    }

    public override string ToString()
    {
        return $"{CharacterName} (Health: {HealthPoints}, Power: {Power}, Agility: {Agility}, Intelligence: {Intelligence})\n" +
               $"Weapon: {EquippedWeapon}\nArmor: {EquippedArmor}\nSkills: {string.Join(", ", SkillsList)}";
    }
}

