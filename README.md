# NeoFSM Validator

**NeoFSM Validator** is an interactive Finite State Machine (FSM) simulator built for the Informatics Automata Practicum. It is designed to automatically determine whether a binary string is a member of the specific language $L = \{ x \in (0 + 1)^+ \mid \text{the last character of } x \text{ is 1 and } x \text{ does not contain the substring 00} \}$.

---

## Key Features

- **Real-Time Validation**: Instantly evaluates binary inputs (`0` and `1`) on the fly, providing immediate acceptance or rejection feedback.
- **Transition Trace Visualization**: Maps and displays the exact path of states traversed by the machine (e.g., `S → A → B`), offering clear transparency into the algorithmic logic.
- **Strict Compliance**: Accurately implements trap states (Dead States) to handle substring violations and invalid characters natively.
- **Modern UI/UX**: Features a custom-built interface with an integrated Light/Dark mode switch that seamlessly synchronizes with Windows OS system preferences.

## Tech Stack

- **Language**: C# (.NET)
- **Framework**: Windows Presentation Foundation (WPF)
- **Logic**: Object-Oriented State Machine utilizing modern C# `switch` expressions.

## Installation

1. Go to the [Releases](https://github.com/devreonid/NeoFSM/releases/tag/v1.0.0) page.
2. Download `NeoFSM_v1.0.0_win-x64.exe` (Self-contained).
3. Run the executable directly. No additional .NET runtime installation is required!

## Contributors (Automata Team 14)

This project was engineered  by **Automata Team 14 Informatics ITS**:
- **Raziq Danish Safaraz**
- **Danish Faiq Ibad Yuadi**
- **Rafa Huga Nirando**

## Academic Affiliation

**Department of Informatics** **Institut Teknologi Sepuluh Nopember (ITS)** *Surabaya, Indonesia*

## License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---
*Developed for Informatics Automata Practicum 2026.*
