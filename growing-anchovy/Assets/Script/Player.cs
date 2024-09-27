using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int gold;

    private int level;
    private string grade;

    private int exp;
    private int maxExp;

    private int[] equipments;

    public Player() {
        equipments = new int[4];
    }

    public Player(int _gold, int _level, string _grade, int _exp, int _maxExp, int[] _equipments) {
        this.gold = _gold;
        this.level = _level;
        this.grade = _grade;
        this.exp = _exp;
        this.maxExp = _maxExp;
        this.equipments = _equipments;
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
}



