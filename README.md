![App Logo](Docs/app-logo.svg)

# CryptoTracker

<p>In this repository you will find the code for the CryptoTracker application. Please read the following information carefully before you start working on the project. <p>

## Project Description

<p>CryptoTracker is a feature-rich mobile application developed using the .NET MAUI framework, which aims to track and analyze cryptocurrency prices. With a sleek design and platform independence, CryptoTracker offers a seamless experience for both iOS and Android users.</p>

## Table of Contents

- [Installation](#installation)
- [Documentation](#documentation)
- [Git](#git)
    - [Commits](#commits)
    - [Pull requests](#pull-requests)

## Installation

1. Clone the repository or download the zip file.

```
git clone git@github.com:basvancleef/CryptoTracker.git
```

2. Open the project in your preferred IDE (Visual Studio, Visual Studio Code, JetBrains Rider etc.).
3. Build the solution to restore NuGet packages.
4. Run the application.

## Documentation
...

## Git

Before you start working on the project, make sure you have the latest version of the `main` branch. <br>

To get the latest version of the `main` branch, use the following command:

```
git pull origin main
```

When you are working on a new feature, create a new branch. <br>
To create a new branch, use the following command:

```
git checkout -b feat/your-jira-issue-number

// Example: feat/JIR-123
```

When you are done working on your feature, push your branch to the repository. <br>

To push your branch to the repository, use the following command:

```
git push origin feat/your-jira-issue-number
```

When you are done working on your feature, create a pull request. <br>
When you create a pull request, make sure to assign a reviewer. <br>
When you are done working on your feature and its merged, make sure to delete your branch. <br>

### Commits

Give a clear and concise description of your changes. Use the prefixes below but describe your commit better than the
example. <br>

We're following Conventional Commits (see: https://www.conventionalcommits.org/en/v1.0.0/). <br>

When you are working on a branch, make sure to commit your changes. <br>
When you commit your changes, make sure to use the following format:

```
feat: Added new feature

fix: Fixed bug

chore: Updated packages

refactor: Refactored code

test: Added new test

style: Updated style

docs: Updated documentation

build: Updated build
```

### Pull requests

Well done! You've finished your feature and you want to merge it with the `main` branch. <br>

1. When you are done working on your feature, create a pull request. <br>
2. When you create a pull request, make sure to assign a reviewer. <br>
3. When you create a pull request, make sure to give a clear and concise description of your changes. <br>
4. When you create a pull request, make sure to add the Jira issue number in the title. <br>

Example: `feat(JIR-123): Implement user management for admins`

---

<p><i>This project is part of the module "Fullstack Development with .NET" at Avans University of Applied Science.</i></p>

![Avans Logo](Docs/avans-logo.svg)
