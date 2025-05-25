# Student Task Manager

A simple web-based task management application built with F#, Giraffe, and SQLite. Allows users to create, view, update, and delete tasks via a clean interface styled with Tailwind CSS.

## Screenshots
![Task Manager UI](images/screenshot1.png)
![Adding a Task](images/screenshot2.png)

## Features
- Add new tasks with a title and due date.
- View all tasks in a list.
- Mark tasks as completed.
- Delete tasks.
- Responsive UI with Tailwind CSS.

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A modern web browser

## Setup and Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Jebraouilyass/StudentTaskManager.git
   cd StudentTaskManager
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Open a browser and navigate to `http://localhost:5000`.

## Usage
- **Add a Task**: Enter a task title and due date, then click "Add Task".
- **View Tasks**: Tasks are displayed in a list with their title, due date, and completion status.
- **Complete a Task**: Click the checkbox next to a task to mark it as completed.
- **Delete a Task**: Click the "Delete" button next to a task to remove it.

## Deployment
- **Frontend**: The static `docs/index.html` is deployed on GitHub Pages at `https://Jebraouilyass.github.io/StudentTaskManager` from the `docs/` folder on the `main` branch.
- **Backend**: Deployed on Render at `https://student-task-manager.onrender.com`. The GitHub Pages frontend uses this URL for API calls. The backend also serves `index.html` from the root for testing at `https://student-task-manager.onrender.com`.
- **Live Site**: Access the full application at `https://Jebraouilyass.github.io/StudentTaskManager` with the backend hosted on Render.

## Hosting on Render
1. Create a Render account and connect your GitHub repository.
2. Set up a Web Service with:
   - Environment: Docker
   - Branch: main
   - Instance Type: Free tier
3. Deploy and note the Render URL (e.g., `https://student-task-manager.onrender.com`).
4. Update `docs/index.html` to use the Render URL for API calls.
5. Ensure `Program.fs` allows CORS for `https://Jebraouilyass.github.io` and serves `index.html`.

## Project Structure
- `index.html`: Frontend served by the backend (root, used by Render or local).
- `docs/index.html`: Static frontend for GitHub Pages.
- `docs/images/`: Images for README (e.g., screenshots).
- `Handlers.fs`: Defines HTTP endpoints for task operations.
- `Models.fs`: Defines the `Task` and `TaskCreate` data models.
- `Db.fs`: Handles SQLite database operations.
- `Program.fs`: Configures the Giraffe web application.
- `StudentTaskManager.fsproj`: Project file with dependencies.
- `Dockerfile`: For deploying the backend to Render.
- `.gitignore`: Excludes build artifacts and SQLite database.
- `README.md`: Project documentation.

## License
[MIT License](LICENSE)

## Acknowledgments
- Built with [Giraffe](https://github.com/giraffe-fsharp/Giraffe) and [Microsoft.Data.SQLite](https://www.nuget.org/packages/Microsoft.Data.SQLite).
- Styled with [Tailwind CSS](https://tailwindcss.com).