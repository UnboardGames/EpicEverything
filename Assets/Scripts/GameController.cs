﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameState {

}

public class GameController : MonoBehaviour {

    public GameState gameState;

    private PlayerController p1Controller;
    private PlayerController p2Controller;

    public void Attack(PieceController attacker, PieceController defender) {
        CardState attackerCardState = attacker.cardState;
        CardState defenderCardState = defender.cardState;
        bool retaliate = (defender.cardState != null && defender.InRange(attacker));
        defender.ReceiveCreatureDamage(attackerCardState.attack, attacker);
        if (defenderCardState != null && retaliate) {
            // deal retaliation damage
            attacker.ReceiveCreatureDamage(defenderCardState.attack, defender);
        }
        GetComponent<CameraShakeAnimation>().Animate(attackerCardState.attack);
    }

    public void DrawCard() {
        p1Controller.DrawCard();
        p2Controller.DrawCard();
    }

    public void NewTurn() {
        p1Controller.NewTurn();
        p2Controller.NewTurn();
    }
    

    void Start() {
        p1Controller = GameObject.Find("Player1").GetComponent<PlayerController>();
        p2Controller = GameObject.Find("Player2").GetComponent<PlayerController>();
    }

    private bool AdjacentPiece(PieceController a, PieceController b) {
        return true;
    }
}
