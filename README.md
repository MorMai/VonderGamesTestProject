# Le Mage: Vonder Games Project Submission
A game project for Vonder Games Internship submission made by Natchanon Srisiri.

## Overview

This project implements four core systems as an expected deliverables including:

- Time System
- Combat & AI System
- Inventory System
- Crafting System

My goal was to design modular, scalable, and extendable systems within 28 Feburary, focusing on clean architecture and maintainability.

## Architecture Overview

Although most of the game architecture uses MVP or MVVP approches but for modularity purposes I decided to implement my own architecture inspired by Data Driven Design and MVC architecture including:

- Data Layer (ScriptableObjects & Static Data)
- Model Layer (Core Game Logic Systems)
- Control Layer (Managers & Controllers)
- View Layer (UI & Presentation)

The systems communicate through UnityEvents to reduce tight coupling.


