# 🏢 ROEQ Room Booker

A desktop application for managing showroom and meeting‐room reservations. Built by a six‑person team, this WPF CRUD tool streamlines booking, editing, and cancelling reservations—ensuring rooms are never double‑booked and workflows stay efficient.

---

## 📋 Table of Contents
- [About](#about)  
- [Features](#features)  
- [Technologies](#technologies)  
- [Architecture & Workflow](#architecture--workflow)  
- [Installation & Setup](#installation--setup)  

---

## 🧠 About

In a collaborative effort of six developers, we built the ROEQ Room Booker to help a company organise reservations for its showrooms and meeting rooms. This simple CRUD application centralises bookings, avoids conflicts, and provides an intuitive UI that fits within existing operational processes. The app is in active use and deployed on internal machines.

---

## 🚀 Features

- **Room Reservation CRUD**  
  Create, read, update, and delete bookings for showrooms and meeting rooms.  
- **Conflict Prevention**  
  Prevents overlapping bookings by validating date/time ranges.  
- **Room Management**  
  Add, edit, or remove rooms from the system, complete with capacity and resource metadata.  
- **Responsive WPF UI**  
  Dynamically resizes layouts and matches company branding colors.  
- **Local Database Storage**  
  Uses a local SQL Server Express database for quick, offline‑capable access.  
- **Stakeholder Collaboration**  
  Requirements gathered and refined through regular demos and feedback loops.

---

## 🛠️ Technologies

- **.NET 8**  
- **C#**  
- **WPF (Windows Presentation Foundation)**  
- **SQL Server Management Studio (SSMS)** & **SQL Server Express**  
- **Visual Studio 2022**  

---

## 🏗️ Architecture & Workflow

1. **Client‑Side (WPF)**  
   - MVVM design pattern for clear separation of UI, logic, and data  
   - XAML‑based layouts with company‑branded styles  
2. **Data Layer**  
   - Local `.mdf` database in SQL Server Express  
   - ADO.NET for executing parameterised queries and ensuring data integrity  
3. **Collaboration**  
   - Git flow with feature branches, pull requests, and code reviews  
   - Weekly stakeholder presentations to validate features and UI/UX  

---

## ⚙️ Installation & Setup

1. **Prerequisites**  
   - Windows 10/11  
   - .NET Framework 8  
   - SQL Server Express (LocalDB)  
   - SQL Server Management Studio  

2. **Clone & Open**  
   ```bash
   git clone https://github.com/MarcusK00/ROEQRoomBooker.git
   cd ROEQRoomBooker
