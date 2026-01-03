📄 CSV Processor (C# Console Application)
📌 Overview

This project is a console-based CSV processing application built using C# and .NET.
It reads CSV files, validates data, processes records based on business rules, and outputs clean results. The project demonstrates file handling, data validation, and clean backend architecture, commonly required in enterprise systems.

🎯 Features

Read CSV files using StreamReader

Validate each row and column

Handle missing or invalid data safely

Process records based on business rules

Generate cleaned output files

Log invalid records and errors

🧠 Design & Architecture

The application follows a layered and modular design:

Models – Represents CSV record structure

Interfaces – IFileReader, IValidator, IProcessor

Services – File reading, validation, and processing logic

Program (Entry Point) – Orchestrates the processing flow

This design ensures:

Clean separation of responsibilities

Easy extensibility for new file formats (XML, JSON)

Testable and maintainable code

🧱 SOLID Principles Applied

SRP – Each component handles one responsibility

OCP – New file processors can be added without changing existing code

LSP – Interchangeable processor implementations

ISP – Focused, minimal interfaces

DIP – High-level logic depends on abstractions

🛠️ Tech Stack

Language: C#

Framework: .NET

Concepts: File I/O, OOP, SOLID, LINQ

Application Type: Console Application

▶️ How It Works

User provides the CSV file path

File is read line-by-line

Each record is validated

Valid records are processed

Invalid records are logged

Output file is generated
