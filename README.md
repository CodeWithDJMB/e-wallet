DJ Pay – E-Wallet Simulation
 
This project is a manually developed simulation of a simple e-wallet system, built purely for educational and demonstration purposes. It includes basic features typically found in digital wallet applications.

🗂️ Note: 

This project was originally created in 2023. It was only pushed today after I recently found it in one of my folders and it was quite hard to find!

📂 Database Setup Instructions:

To update the connection string for the DJ Pay.mdf database:

	• Locate the Original Connection String
		In your code, find the following line, for example:
		string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Applications\Microsoft Visual Studio\Projects\ASP Project (E-wallet)\E-wallet\App_Data\DJ Pay.mdf;IntegratedSecurity=True";
  
	• Copy the New File Path
		Open File Explorer and navigate to the current location of your DJ Pay.mdf database file.
		Copy the full path.
  
	• Replace the Connection String
		o Press Ctrl + Shift + F in Visual Studio to open Find in Files.
		o Go to the Replace in Files tab.
		o Paste the original connection string into the Find what box.
		o Paste the updated connection string into the Replace with box. Example:
			string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\ASP Project (E-wallet)\E-wallet\App_Data\DJ Pay.mdf;Integrated Security=True";
		o Set the Look in dropdown to Current Project to avoid affecting other files.
		o Click Replace All.

▶️ Running the Project:

After updating the connection string, click the Run button at the top center of Visual Studio to start the application.


