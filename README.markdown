# Student Task Manager

   A simple web-based task management application built with F#, Giraffe, and SQLite. Allows users to create, view, update, and delete tasks via a clean interface styled with Tailwind CSS.

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
   5. Open a browser and navigate to `http://localhost:5000` (or the port shown in the terminal).

   ## Usage
   - **Add a Task**: Enter a task title and due date, then click "Add Task".
   - **View Tasks**: Tasks are displayed in a list with their title, due date, and completion status.
   - **Complete a Task**: Click the checkbox next to a task to mark it as completed.
   - **Delete a Task**: Click the "Delete" button next to a task to remove it.

   ## Deployment
   The static frontend (`index.html`) can be deployed on GitHub Pages. The backend requires a server (e.g., Azure, Heroku, or a local server). See the [Deployment](#deployment) section for details.

   ## Project Structure
   - `index.html`: Static frontend with HTML, Tailwind CSS, and JavaScript for API interactions.
   - `Handlers.fs`: Defines HTTP endpoints for task operations.
   - `Models.fs`: Defines the `Task` and `TaskCreate` data models.
   - `Db.fs`: Handles SQLite database operations.
   - `Program.fs`: Configures the Giraffe web application.
   - `StudentTaskManager.fsproj`: Project file with dependencies.

   ## License
   [MIT License](LICENSE)

   ## Acknowledgments
   - Built with [Giraffe](https://github.com/giraffe-fsharp/Giraffe) and [Microsoft.Data.SQLite](https://www.nuget.org/packages/Microsoft.Data.SQLite).
   - Styled with [Tailwind CSS](https://tailwindcss.com).