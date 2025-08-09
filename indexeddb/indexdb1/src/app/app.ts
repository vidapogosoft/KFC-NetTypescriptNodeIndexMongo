import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { Indexdb } from './indexdb';

interface TodoItem{
  id?: number;
  text: string;
  completed: boolean
}


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
title="Mi lista de pendientes";
todos: TodoItem[] = [];
newTodoText: string = "";

constructor( private indexservice: Indexdb ){}

ngOnInit(): void {
  this.loadTodo();  
}

loadTodo(): void{
 this.indexservice.getTodo().subscribe({
  next:(data) => {
    this.todos = data;
    console.log('Tareas cargadas: ', this.todos);
  },
  error:(error) =>
  {
    console.error('Error', error);
  }
 });
}

addTodo(): void{

  if(this.newTodoText.trim()){
    const newtodo: TodoItem = {
      text: this.newTodoText.trim(),
      completed: false
    };

    this.indexservice.addTodo(newtodo).subscribe({
      next: (addedtodo) => {
        this.todos.push(addedtodo);
        this.newTodoText = "";;
        console.log('tarea registrada', addedtodo);
      },
       error:(error) =>
        {
          console.error('Error', error);
        }
    });
  }
}

  toggleCompleted(todo: TodoItem): void 
  {     
    const updatedTodo = { ...todo, completed: !todo.completed };     
      this.indexservice.updateTodo(updatedTodo).subscribe({       
        next: () => {         
          const index = this.todos.findIndex(t => t.id === todo.id);        
            if (index > -1) {           
            this.todos[index] = updatedTodo;         }        
            console.log('Tarea actualizada:', updatedTodo);       
          },      
            error: (err) => {         
            console.error('Error al actualizar tarea:', err);       

            }    
          });  
  }   
               
               
deleteTodo(id: number | undefined): void {     
  if (id === undefined) return;     
  this.indexservice.deleteTodo(id).subscribe({ 
    next: () => { 
    this.todos = this.todos.filter(todo => todo.id !== id); 
    console.log('Tarea eliminada con ID:', id); 
  }, 
  error: (err) => { 
    console.error('Error al eliminar tarea:', err); 
  } 
}); 
}

}
