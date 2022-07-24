<p align="center"><img src="https://imgur.com/jYaWlyP.png"></p>

# Investment Tracker

### Introduction
This is a software that keeps track of all the investments made. For now it keeps track of BitCoin. It uses live tracking of the BitCoin price which it gets from Coinbase's json. Uses visual to help know how far up or down the investment is in.

## Table of Contents:
- [Prerequisites](#prerequisites)
- [Stable Build](#stable-build)
- [Installation](#installation)
- [User Interface](#user-interface)
- [Features](#features)
  - [Adding Data](#add-data)
  - [Selecting Data](#selecting-data)
  - [Updating Data](#updating-data)
  - [Sorting Data](#sorting-data)
  - [Target ROI](#target-roi)
  - [Custom Market Value](#custom-market-value)
- [Versioning](#versioning)
- [Authors](#authors)
- [License](#license)

## Prerequisites
#### Windows 10
For now this works in Windows 10. In future will try to get it on Linux and MacOS
***
## Stable Build
[Stable-v1.0.4]() is the latest stable build of the project. If development is going to be done on this project then it is advised to branch off of any Stable branches because they will NOT be changed or update except for README.md. Any other branches are subjected to change including the main branch.
***
## Installation
1. First download the latest [InvestmentTracker.zip]() from the latest Stable build.
2. Once downloaded unzip it.
3. After unzipping open up _InvestmentTracker.exe_
***
## User Interface
<p align="center"><img src="https://imgur.com/jRbIr9g.png"></p>

This is the UI of the software. Using visuals to represent if an investment is up or down. Green means the investment up. Red means the investment is down. Orange means that row/data has been selected and can be updated. Below it shows all the total and average values.
***
## Features
#### Adding Data:
To add data first click the _ADD_ button.

<div align="center"><img src="https://imgur.com/PJubGys.png" style="width:50%;height:50%;"></div>

This will open up a new interface which is the _add new data interface_. Here you can set the date, invested amount, price bought, BTC and platform stored in. Once you have done putting in the data then hit _CONFIRM_ button.

<div align="center"><img src="https://imgur.com/oPeYgS4.png" style="width:50%;height:50%;"></div>

You will notice that a new row have been added with the latest data.

<div align="center"><img src="https://imgur.com/Ghyd6XM.png" style="width:50%;height:50%;"></div>

#### Selecting Data:
To select a data or row simply click it anywhere in the row. This will highlight the selected data/row with an orange highlighter.

<div align="center"><img src="https://imgur.com/TEDSxEO.png" style="width:50%;height:50%;"></div>

#### Updating Data:
To update a data or row make sure it is first selected and the orange highlighter is shown. Then click the _UPDATE_ button.

<div align="center"><img src="https://imgur.com/0Ssdn5R.png" style="width:50%;height:50%;"></div>

This will open up the update interface. Here you can update any data you want. Once updating the data is done click the _UPDATE_ button.

<div align="center"><img src="https://imgur.com/Nxho4uo.png" style="width:50%;height:50%;"></div>

You will now notice that the data/row is updated with new values.

<div align="center"><img src="https://imgur.com/SkLooFO.png" style="width:50%;height:50%;"></div>

#### Sorting Data:
You can sort the table by clicking any of the headings of the table. This will sort the data in ascending or descending order. This is feature helps to show how investments are doing.

<div align="center"><img src="https://imgur.com/SkLooFO.png" style="width:50%;height:50%;"></div>

For example. Click the _GAIN (%)_ header. This will first sort the data in ascending order. The order will be done using the gain values.

<div align="center"><img src="https://imgur.com/wqE47MX.png" style="width:50%;height:50%;"></div>

Now click _GAIN (%)_ header again. This time it will sort the data in descending order. The order will be done using the gain values.

<div align="center"><img src="https://imgur.com/7EFVZgQ.png" style="width:50%;height:50%;"></div>

#### Target ROI:
You can set the target ROI value. By default at the start it is 1.5. You can change this value to any other value. Try changing the _ROI(x)_ value to _2_ and then hit the _Enter_ key.

<div align="center"><img src="https://imgur.com/kO4MGz9.png" style="width:50%;height:50%;"></div>

You will notice that the _SELL PRICE (£)_ AND _BTC SELL PRICE (£)_ value changing as the _ROI(x)_ value changes. This makes sure the sell price of the invest and the target btc market value is updated so that the investor will know when to sell the investment.

<div align="center"><img src="https://imgur.com/YfNAA8p.png" style="width:50%;height:50%;"></div>

#### Custom Market Value:
You can set the custom market value to see how your investment will do. This helps to predict what the gain/loss will be. At start the custom value is 0 by default. Change the _CUSTOME VALUE_ to _50000_ and then hit the _Enter_ key.

<div align="center"><img src="https://imgur.com/enYhGxy.png" style="width:50%;height:50%;"></div>

You will notice that _GAIN AMOUNT_, _GAIN TOTAL_ AND _GAIN (%)_ values changing. This is because the calculation is being done based on the custom market value. To go back to the current/live market value make the custom value back to _0_.

<div align="center"><img src="https://imgur.com/6O3SPdp.png" style="width:50%;height:50%;"></div>

To go back to the current/live market value change the _CUSTOME VALUE_ back to _0_.

<div align="center"><img src="https://imgur.com/vTRrYus.png" style="width:50%;height:50%;"></div>

***
## Versioning
The project uses [Semantic Versioning](https://semver.org/). Available versions can be seen in [tags on this repository]().
***
## Authors
- Syed Shaiyan Kamran Waliullah 
  - [Kamran Wali Github](https://github.com/deadlykam)
  - [Kamran Wali Twitter](https://twitter.com/KamranWaliDev)
  - [Kamran Wali Youtube](https://www.youtube.com/channel/UCkm-BgvswLViigPWrMo8pjg)
  - [Kamran Wali Website](https://deadlykam.github.io/)
***
## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details.
***
