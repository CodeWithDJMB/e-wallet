# 🪙 DJ Pay – E-Wallet Simulation

A web application with a hand-coded frontend that simulates a simple e-wallet system. It includes basic features typically found in digital wallet applications.

**Academic Project**: This project was created for **AP-3 - ASP.NET** coursework.

---

## ✨ Features

- **User Registration**: Create new user accounts
- **User Authentication**: Secure login system
- **Wallet Management**: View balance and transaction history
- **Money Transfer**: Send money between users
- **Transaction History**: Track all wallet activities
- **Account Management**: Update user profile information

---

## 🛠️ Tech Stack

- **Framework**: ASP.NET Web Forms
- **Database**: SQL Server (LocalDB)
- **Frontend**: Hand-coded HTML, CSS, and JavaScript
- **Backend**: C#

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
```

### 2. Database Setup Instructions

To update the connection string for the DJ Pay.mdf database:

**Step 1: Locate the Original Connection String**
In your code, find the following line, for example:
```csharp
string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Applications\Microsoft Visual Studio\Projects\ASP Project (E-wallet)\E-wallet\App_Data\DJ Pay.mdf;IntegratedSecurity=True";
```

**Step 2: Copy the New File Path**
- Open File Explorer and navigate to the current location of your DJ Pay.mdf database file
- Copy the full path

**Step 3: Replace the Connection String**
- Press `Ctrl + Shift + F` in Visual Studio to open Find in Files
- Go to the **Replace in Files** tab
- Paste the original connection string into the **Find what** box
- Paste the updated connection string into the **Replace with** box. Example:
```csharp
string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\ASP Project (E-wallet)\E-wallet\App_Data\DJ Pay.mdf;Integrated Security=True";
```
- Set the **Look in** dropdown to **Current Project** to avoid affecting other files
- Click **Replace All**

### 3. Running the Project

After updating the connection string, click the **Run** button at the top center of Visual Studio to start the application.

---

## 📌 Project History

This project was originally created in **2023** as part of academic coursework. It was later pushed to GitHub in **2025** after being rediscovered in programming projects.

<img src="https://github.com/user-attachments/assets/ea200159-b674-4121-affb-00a1222d16d3" alt="DJ Pay E-Wallet Demo" width="800">

---

## 🤝 Contributing

This is an academic project, but feel free to fork and experiment with the code for your own learning purposes.

---

## 📄 License

This project is for educational purposes as part of academic coursework.
