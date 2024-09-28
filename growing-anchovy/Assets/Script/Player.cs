using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    private int gold;

    private int level;
    private string grade;

    private int exp;
    private int maxExp;

    private int[] equipments;
    private int[] stats;

    public Player() {
        equipments = new int[4];
        stats = new int[4];
    }

    public Player(int _gold, int _level, string _grade, int _exp, int _maxExp, int[] _equipments, int[] _stats) {
        this.gold = _gold;
        this.level = _level;
        this.grade = _grade;
        this.exp = _exp;
        this.maxExp = _maxExp;
        this.equipments = _equipments;
        this.stats = _stats;
    }

    public void UpdateGrade() {
        int minLevel = equipments.Min();
        if(minLevel == 0) {
            grade = "초보자";
        } else if(minLevel == 1) {
            grade = "중급자";
        } else if(minLevel == 2) {
            grade = "상급자";
        } else if(minLevel == 3) {
            grade = "엘리트";
        }
    }

    public void SetGold(int gold) {
        this.gold = gold;
    }

    public void SetLevel(int level) {
        this.level = level;
    }

    public void SetGrade(string grade) {
        this.grade = grade;
    }

    public void SetExp(int exp) {
        this.exp = exp;
    }

    public void SetMaxExp(int maxExp) {
        this.maxExp = maxExp;
    }

    public void SetEquipmentItem(int index, int itemId) {
        if (index >= 0 && index < 4) {
            equipments[index] = itemId;
            UpdateGrade();
        }
    }

    public void SetStats(int[] stats) {
        this.stats = stats;
    }

    public void SetStat(int index, int stat) {
        if (index >= 0 && index < 4) {
            stats[index] = stat;
        }
    }

    public int GetGold() {
        return gold;
    }

    public int GetLevel() {
        return level;
    }

    public string GetGrade() {
        return grade;
    }

    public int GetExp() {
        return exp;
    }

    public int GetMaxExp() {
        return maxExp;
    }

    public int[] GetEquipments() {
        return equipments;
    }

    public int GetEquipmentItem(int index) {
        if (index >= 0 && index < 4) {
            return equipments[index];
        }
        return -1; // 잘못된 인덱스일 경우 -1 반환
    }

    public int[] GetStats() {
        return stats;
    }

    public int GetStat(int index) {
        if (index >= 0 && index < 4) {
            return stats[index];
        }
        return -1; // 잘못된 인덱스일 경우 -1 반환
    }
}



