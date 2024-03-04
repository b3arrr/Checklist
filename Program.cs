﻿//This program creates and manages a checklist. 

bool quit = false;  //Boolean for keeping the program running until user chooses to quit. 

List<string> tasks = new List<string>(); //Declaring list to be used to contain and remove tasks. 
List<string> completedTasks = new List<string>();  

while (quit == false)
{
  

    Console.WriteLine("What do you wish to do?");
    Console.WriteLine("Press 1. Add task\nPress 2. View current tasks\nPress 3. Delete Tasks\nPress 4. Complete tasks\nPress 5. Quit program");
    string userInput = Console.ReadLine(); 


    switch(userInput)
    {
        case "1":  
             
            Console.WriteLine("How many tasks do you wish to add?");
            while(true)
             {
                if (int.TryParse(Console.ReadLine(), out int taskAmountAdded))
                {
                    for (int i = 0; i < taskAmountAdded; i++)
                    {
                        tasks.Add(addTask());
                    }
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
             }
        break;


        case "2":
            int taskLoop = 1;
            int taskLoopComplete = 1;
            Console.WriteLine("You pressed 2");
            foreach(string o in tasks)
            {  
                Console.WriteLine($"Task {taskLoop}: " + o);
                taskLoop++;  
            }

            Console.WriteLine("These are the completed tasks.");
            foreach(string o in completedTasks)                  //Displays the completed tasks. 
            {        
                Console.WriteLine($"Task {taskLoopComplete}: " + o);
                taskLoopComplete++;
            }
            break;

        case "3":
            removeTask(tasks);
            break;
        
        case "4":
            completeTask(tasks, completedTasks);
            break;
        case "5":
            Console.WriteLine("Have a nice day, see you another day");
            quit = true;
            break;
            
        default:
            Console.WriteLine("invalid input");
            break;
    }
}




string addTask()
{
    Console.WriteLine("Please add a task you want to write");
    string userTask = Console.ReadLine(); 
    return userTask; 
}

void removeTask(List<string> selectedTask)
{
   
     int taskLoop = 1;
     Console.WriteLine("These are your current tasks");
     foreach(string o in selectedTask)                  //Displays the current created tasks. 
     {        
        Console.WriteLine($"Task {taskLoop}: " + o);
        taskLoop++;
     }
     

     Console.WriteLine("Select which task you wish to remove");
        while(true)
        {
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    selectedTask.RemoveAt(userInput); 
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
        }
}

void completeTask(List<string> selectedTask, List<string> completedTasks) //function for adding a checkmark to completed tasks.
{
     int taskLoopComplete = 1;   
     int taskLoop = 1;
     Console.WriteLine("These are your current tasks.");
     foreach(string o in selectedTask)                  //Displays the current created tasks. 
     {        
        Console.WriteLine($"Task {taskLoop}: " + o);
        taskLoop++;
     }
     Console.WriteLine("These are the completed tasks.");
     foreach(string o in completedTasks)                  //Displays the completed tasks. 
     {        
        Console.WriteLine($"Task {taskLoopComplete}: " + o);
        taskLoopComplete++;
     }

    Console.WriteLine("Which tasks do you wish to mark as completed?");
     while (true)  
                {
                    if (int.TryParse(Console.ReadLine(), out int checkedTask))
                    {
                        string convertTask = selectedTask[checkedTask];
                        completedTasks.Add(convertTask + " (x)");
                        selectedTask.RemoveAt(checkedTask);
                    break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                }
    
}



