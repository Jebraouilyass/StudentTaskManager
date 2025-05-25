module Models

open System

type Task = {
    Id: int
    Description: string
    DueDate: DateTime
    IsCompleted: bool
}

type TaskCreate = {
    Description: string
    DueDate: DateTime
}