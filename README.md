# han-asd-adp-project

This project is an exam excercise for the HAN ASD course that part of the HBO-ICT degree. The project contains Abstract Data Type (ADT) & Algoritm implementations.

## Structure

The whole solution is written in C#, and contains 4 projects in total:

* **ADPProject.Library**: This projects contains the ADT/algoritm implementations.
* **ADPProject.UnitTests**: This projects tests wheter the ADT's/algoritms actually function as they should.
* **ADPProject.PerformanceTests**: This projects tests the peformance of all ADT methods and algoritm by executing the opertation x amount of time and measuring the time taken.
* **ADPProject.DataTests**: This projects tests wheter the ADT/Algoritm implementation actually can read the datasets provided by the HAN.

## Running the code

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/thommythompson/han-asd-adp-project)

To run the code without having to setup a local dev environment you could use the GitHub codespace feature using the badge above. Follow the instruction below once the codespace has been opened.

### The C# Dev Kit

To make use of the test explorer within VS Code the C# Dev Kit extension is used, this extension sadly requires you to login using a microsoft account.

![1700228758200](./docs/image/README/1700228758200.png)

### Running the tests

In the side bar there is a icon for "Testing", if you click on this icon you will see that there currenlty are no tests available.

![1700227277317](./docs/image/README/1700227277317.png)

This is because the solution is not build yet, to build the solution enter the commands below in the terminal.

```bash
dotnet build ./src/ADPProject/
```

It might take a while but eventually the tests will show up in the test explorer and you will be able to run them.

![1700228056206](./docs/image/README/1700228056206.png)

### Local devcontainer

It is also possible to run the environment locally using a dev container, this avoids having to install dotnet SDK's and required extensions within your local environment, follow the steps below to do so.

> **Prerequisite**: Make sure to have docker desktop installed and running.

Install the "Dev Containers" extension within VS Code.

![1700229032423](./docs/image/README/1700229032423.png)

Open the command pallet and use the "> Dev Containers: Reopen in Container" command to connect to a devcontainer.

![1700229040089](./docs/image/README/1700229040089.png)

Wait a while, it will build and start the dev container and reopen a new VS Code windows that is connected to the devcontainer.

## Links

[Grading](./docs/ADPProjectRubrics.xlsx)

[About Datasets](./docs/Datasets.md)

[Sources used for research](./docs/Sources.md)
