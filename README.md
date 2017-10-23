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

The image below presents the simulation environment. Notice that the sensor and pinhole planes extend infinitely in the simulator but in the image they are smaller for the improved clarity.

![Overview image](./src/Readme.png)

### LEDs configurations
The simulator allows to choose between two configurations of LEDs highlight system:
* _Angular_, which has two explicit parameters:  
  * <b>R</b> (radius - distance from the center of a pinhole and centers of photodiodes).  
  * <b>n</b> - number of photodiodes    
 Based upon the <b>n</b> angle between adjacent photodiodes is calculated (360°/n) and is displayed in the GUI of an app.
* _Grid_, which has three explicit parameters:  
  * <b>rows</b> - number of rows
  * <b>cols</b> - number of columns
  * <b>spacing</b> - straight (not diagonal) distance between adjacent photodiodes [mm]

| Angular config |   Grid config  |
|----------------|----------------|
| <p align="center"><img src="./src/angsm.png" width="50%" height="50%"></p> | <p align="center"><img src="./src/gridsm.png" width="50%" height="50%"></p>  |
| <p align="center"><img src="./src/anglren.png"></p>  | <p align="center"><img src="./src/gridren.png"></p>  |

The upper row shows exemplary configurations of illumination systems (angular: n=6, R=5, grid: rows=3, cols=2, spacing=5).
The lower row presents how the high resolution sensor (mounted on the image plane) perceives the ball highlighted by each of the configurations.

## Simulator app
### GUI
### Output files
## Some results
### HighRes sensor
#### Blur effect
The pinhole diameter was varied in the range of R=0.5 mm to 3.5 mm with the step of 0.1 mm.

![blur image](./src/blur2.gif)


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
