module Handlers

open Giraffe
open Microsoft.AspNetCore.Http
open Models
open Db
open System

let indexHandler : HttpHandler =
    fun next ctx ->
        let html = System.IO.File.ReadAllText("index.html")
        ctx.WriteHtmlStringAsync html

let getTasksHandler : HttpHandler =
    fun next ctx ->
        let tasks = getAllTasks()
        json tasks next ctx

let addTaskHandler : HttpHandler =
    fun next ctx ->
        task {
            let! taskCreate = ctx.BindJsonAsync<TaskCreate>()
            addTask taskCreate
            return! Successful.OK () next ctx
        }

let updateTaskHandler (id: int) : HttpHandler =
    fun next ctx ->
        task {
            let! isCompleted = ctx.BindJsonAsync<bool>()
            updateTask id isCompleted
            return! Successful.OK () next ctx
        }

let deleteTaskHandler (id: int) : HttpHandler =
    fun next ctx ->
        deleteTask id
        Successful.OK () next ctx

let webApp : HttpHandler =
    choose [
        GET >=> choose [
            route "/" >=> indexHandler
            route "/api/tasks" >=> getTasksHandler
        ]
        POST >=> choose [
            route "/api/tasks" >=> addTaskHandler
        ]
        PUT >=> choose [
            routef "/api/tasks/%i" updateTaskHandler
        ]
        DELETE >=> choose [
            routef "/api/tasks/%i" deleteTaskHandler
        ]
        setStatusCode 404 >=> text "Not Found"
    ]