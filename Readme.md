# Basics Unity FPS Mechanics with State Machine and Input System Package

This is a simple FPS Template with a State Machine and Input System Package.  
This template can be used as a base for a FPS game.  
The template is made with Unity 2019.3.0f6.  

The state machine allow to easily add features to the player and the gun in the specific states.

## Features
Player State Machine :
- Idle
- Walk
- Jump
- Fall

Gun State Machine :
- Idle
- Shoot
- Reload

The gun have a simple sway animation when the player is rotating.

## How to use
- Clone the repository
- Open the project with Unity 2019.3.0f6
- Open the scene "SampleScene"
- Play the scene

## How to add a new state
- Create a new script that inherits from the State class
- Implement the parent methods (EnterState, UpdateState, ExitState...)

## Class Diagram
![Class Diagram](https://i.imgur.com/jI9UzKZ.png)


