# SquadLeader

This is a game is an implementation of the Squad Leader board game, 4th edition.  It is a work in progress.

## Areas of Development

### Game Engine

Basic state machine for the game engine.

```plantuml
@startuml

title Squad Leader Game State Diagram

[*] --> RallyPhase: Game Start
RallyPhase --> PrepFirePhase: Repair equipment and rally broken units
PrepFirePhase --> MovementPhase: Execute attacks for selected units
MovementPhase --> DefensiveFirePhase: Move unbroken units
DefensiveFirePhase --> AdvancingFirePhase: Defense attacks for selected units
state AttackingResult <<fork>>
AdvancingFirePhase --> AttackingResult: Attack attacks with non-prep fire units.  1/2 power for moving units
AttackingResult --> RoutPhase: Broken units exist
AttackingResult --> AdvancePhase: Broken units do not exist
RoutPhase --> AdvancePhase: Broken units move
state AdvancingUnits <<fork>>
AdvancePhase --> AdvancingUnits: non-broken attackers move one hex
AdvancingUnits --> CloseCombatPhase: Attacker units occupy defender hexes
AdvancingUnits --> RallyPhase: Attacker units do not occupy defender hexes
CloseCombatPhase --> [*]: Turn Number is Last Turn
CloseCombatPhase --> RallyPhase: Opponent Turn or Increment Turn Number
@enduml
```

### Game Map

### Game Counters
