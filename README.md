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
![Architecture Diagram](./Docs/Architecture)

Note: if the image above wasn't showing you can access it on this Canva link: https://www.canva.com/design/DAHCRabL4Dg/MOSRPLu2z11SmoEz94AMkg/view?utm_content=DAHCRabL4Dg&utm_campaign=designshare&utm_medium=link2&utm_source=uniquelinks&utlId=hb23f850d19

## Design Decisions & Assumptions

- Use a reusable Finite State Machine (FSM) to manage behavioral logic for player and AI
- Apply the Observer Pattern with UnityEvents to decouple gameplay systems from UI, particles, audio
- Rely on interface-driven design to reduce duplication (DRY principle) and enable flexible
- Utilize ScriptableObjects to separate static data from runtime logic
- Follow a component-based architecture
- Use dependency injection via interfaces to reduce tight coupling

## Challenges

- Designing an architecture that can connect all the systems
- Designing a way to make data communicaate with systems while keeping modularity
- Finding a bug from misclicking navigation event
- Testing an AI system and state machine
- Reverting a committed change and causes the entire scene failed

## Work Log

Day 1:
- Unity & Github setup (30 minutes)

Day 2:
- Designing an architecture via Canva (4 hours)
- Setup Scriptable Object for entity data (30 minutes)
- Setup State Manager (2 hours)
- Implement State Manager and Player States for player (2 hours)
- Fixing a committed reverting bug (1 hour)
- Setup component based script (30 minutes)

Day 3:
- Update scenes and change naming convention (10 mins)
- Setup Slime State Manager (2 hours)
- Revisiting architecture (1 hour)
- Implement State Manager and Slime States for slime (4 hour)
- Testing & Integrating component based script (1 hour)

Day 4:
- Add a details to enemy state (1 hour)
- Setup time system and component (10 mins)
- Testing and Integrating time system (1 hour)
- Change time config for more scalabilty (10 mins)
- Setup & Implement the Inventory System (1.5 hours)
- Fixing bug from misclicked (1 hour)

Day 5:
- Implement Equipment System (2 hour)
- Implement Crafting System (2 hour)

Day 6:
- Finalize project (3 hour)
- Test and build game (30 mins)
- Documentation & demo video (1 hours)

  












