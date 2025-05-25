module Db

open System
open Microsoft.Data.Sqlite
open Models

let connectionString = "Data Source=tasks.db"

let initDb () =
    use conn = new SqliteConnection(connectionString)
    conn.Open()
    let command = conn.CreateCommand()
    command.CommandText <- """
        CREATE TABLE IF NOT EXISTS Tasks (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Description TEXT NOT NULL,
            DueDate TEXT NOT NULL,
            IsCompleted INTEGER NOT NULL
        )
    """
    command.ExecuteNonQuery() |> ignore

let getAllTasks () : Task list =
    use conn = new SqliteConnection(connectionString)
    conn.Open()
    let command = conn.CreateCommand()
    command.CommandText <- "SELECT Id, Description, DueDate, IsCompleted FROM Tasks"
    use reader = command.ExecuteReader()
    [ while reader.Read() do
        {
            Id = reader.GetInt32(0)
            Description = reader.GetString(1)
            DueDate = DateTime.Parse(reader.GetString(2))
            IsCompleted = reader.GetBoolean(3)
        } ]

let addTask (task: TaskCreate) =
    use conn = new SqliteConnection(connectionString)
    conn.Open()
    let command = conn.CreateCommand()
    command.CommandText <- """
        INSERT INTO Tasks (Description, DueDate, IsCompleted)
        VALUES ($description, $dueDate, $isCompleted)
    """
    command.Parameters.AddWithValue("$description", task.Description) |> ignore
    command.Parameters.AddWithValue("$dueDate", task.DueDate.ToString("o")) |> ignore
    command.Parameters.AddWithValue("$isCompleted", false) |> ignore
    command.ExecuteNonQuery() |> ignore

let updateTask (id: int) (isCompleted: bool) =
    use conn = new SqliteConnection(connectionString)
    conn.Open()
    let command = conn.CreateCommand()
    command.CommandText <- """
        UPDATE Tasks SET IsCompleted = $isCompleted WHERE Id = $id
    """
    command.Parameters.AddWithValue("$id", id) |> ignore
    command.Parameters.AddWithValue("$isCompleted", isCompleted) |> ignore
    command.ExecuteNonQuery() |> ignore

let deleteTask (id: int) =
    use conn = new SqliteConnection(connectionString)
    conn.Open()
    let command = conn.CreateCommand()
    command.CommandText <- "DELETE FROM Tasks WHERE Id = $id"
    command.Parameters.AddWithValue("$id", id) |> ignore
    command.ExecuteNonQuery() |> ignore