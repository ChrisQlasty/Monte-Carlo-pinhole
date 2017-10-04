# Monte-Carlo-pinhole

The multi thread simulator of the predefined LEDs arrangement - ball - pinhole setup, written in C#. A large number of photons are emitted from each of the light sources, some reflect from the ball, go through the pinhole and meet the image plane. Simulator was utilized to estimate some dimensions for the sensor design.

## Readme overview

* Simulation environment
  * LEDs configurations
* Simulator app
  * GUI
  * Output files
* Some results
  * HighRes sensor
    * blur effect
    * ball motion tracking
  * QP sensor
    * ball motion tracking
* Dependencies
* Usage

## Simulation environment

Text.

![Overview image](./src/Readme.png)

### LEDs configurations

| Angular config  | Grid config |
| ------------- | ------------- |
| <p align="center"><img src="./src/angsm.png" width="50%" height="50%"></p> | <p align="center"><img src="./src/gridsm.png" width="50%" height="50%"></p>  |
| <p align="center"><img src="./src/anglren.png"></p>  | <p align="center"><img src="./src/gridren.png"></p>  |

## Simulator app
### GUI
### Output files
## Some results
### HighRes sensor
#### blur effect
#### ball motion tracking
### QP sensor
#### ball motion tracking
   
### Dependencies

The Spreadsheetlight library will be utilized for saving the simulation results.
```
https://www.nuget.org/packages/SpreadsheetLight/
```

## Usage

Use the Visual Studio.
