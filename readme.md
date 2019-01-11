# PayXpert Connect2Pay C# SDK

This library is the official C# client to interact with the PayXpert Connect2Pay system. The whole payment workflow is implemented through easy to use methods.
This repository contains Visual Studio solutions with two projects

* Connect2PayLibrary (for PaymentGateway)
* Connect2PayDemo (console Windows application with examples)

Exploring SDKTest sources you can find suggestions about this SDK usage.

## Compatibility

This library was tested with

* .NET Framework 4.5
* .NET Core 2

## Running demo

Before running a demo you will need to have originator ID and password provided by PayXpert. You can request them in [PayXpert website!](https://www.payxpert.com).

To run the demo, please clone a repository.
You can open in Visual Studio the whole solution "Connect2PayLibrary.sln"
You will need to open a file OriginatorConfig-Test.cs in SDKTest project folder, uncomment everything and set the relevat originator data received from PayXpert.
To run the demos, choose SDKTest as startup project and run it pressing F5.

## Documentation

All the documentation related Payment Gateway commands and SDK usage could be found in our [documentation page!](https://developers.payxpert.com/gateway)

## Use in your own project

Please add "Connect2PayLibrary" project from cloned repository to your Visual Studio solution.




