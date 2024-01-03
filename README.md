# Chavo Folder Manager

## Project Description
Chavo Folder Manager is a web application that allows users to browse through folders, manage files, and organize digital content efficiently. 
It enables users to view the contents of a folder, add new files and subfolders, and delete or rename files and folders. 
Additionally, it allows for downloading files.

### Functionalities
- **Folders**
  - Create and delete folders.
  - Rename folders.
  - Can contain other files and folders.
- **Files**
  - Create and delete files.
  - Rename and download files.
  - Supports all file types.
- **User Interface**
  - The home page displays the root folder.
  - Simple navigation through folder structures.
  - Add new files/subfolders easily.

### Example Structure
- Root Folder
  - Nested Folder
    - Example Folder Name
      - Child Folder 1
      - Child Folder 2
      - File

## Installation & Setup

1. **Clone the Repository**\
`git clone https://github.com/chavodim/project-manager.git`
2. **Navigate to the Project Directory**\
`cd project-manager`
3. **Install Dependencies**\
Ensure you have the required versions of ASP.NET Core and Entity Framework Core installed.
5. **Set Up the Database**\
Update the `FolderManagerDbContextConnection` in `appsettings.json` with your database connection string.
6. **Run the Application**\
`dotnet run`
7. **Access the Application**\
Open your browser and navigate to `http://localhost:<port>/`.

## Technologies Used
- No user authentication to keep the application straightforward and user-friendly.
- ASP.NET Core 6.0
- Entity Framework Core 6.0
- Microsoft SQL Server 2019

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any changes.
