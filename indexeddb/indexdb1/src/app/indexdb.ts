import { Injectable } from '@angular/core';
import { Observable, from, Subject } from 'rxjs';



interface TodoItem{
  id?: number;
  text: string;
  completed: boolean
}

@Injectable({
  providedIn: 'root'
})
export class Indexdb {

private dbName = "TodoDB";
private storeName = "todos";
private db: IDBDatabase | null = null;
private dbready = new Subject<boolean>();

  constructor(
  ) { 
    this.openDatabase();
  }

  private openDatabase(): void {
    const request = indexedDB.open(this.dbName, 1); //version de la base de datos

    request.onerror = (event) => {
      console.error("Error de indexeddb: ", (event.target as IDBRequest).error);
    };

    request.onsuccess = (event) => {
      this.db = (event.target as IDBOpenDBRequest).result;
      console.log("indexed db open correcto");
      this.dbready.next(true);
    };

    //Este evento indica si la base de datos se crea por primera vez
    //o si se actualiza la version (Ejemplo de 1 a 2))
    request.onupgradeneeded = (event) => {
        const db = (event.target as IDBOpenDBRequest).result;

        if(!db.objectStoreNames.contains(this.storeName))
        {
          //crear un almacen de objetos
          db.createObjectStore(this.storeName, {keyPath: "id", autoIncrement: true});
          console.log("Object store creado");
        }


    };

  }

  //Esperar a q la base de datos este lista
  private getDB(): Promise<IDBDatabase>
  {
    if(this.db)
    {
      return Promise.resolve(this.db);
    }

    return new Promise((resolve, reject) =>
    {

      this.dbready.subscribe(isReady => {
          if(isReady && this.db)
          {
            resolve(this.db); 
          }
          else{
            reject("Indexed db no esta lista");
          }
      });

    });
  }

  //== Operaciones Crud

  addTodo (todo: TodoItem): Observable<TodoItem>{
    return from (this.getDB().then(db => 
      {
        return new Promise<TodoItem>((resolve, reject) => {
          const transaction = db.transaction([this.storeName], "readwrite");
          const store = transaction.objectStore(this.storeName);
          const request = store.add(todo);

          request.onsuccess = () => {
            resolve({...todo, id:request.result as number});
          };

          request.onerror = (event) => {
          console.error("Error al registrar tarea: ", (event.target as IDBRequest).error);
          reject((event.target as IDBRequest).error);
          };


        }); 

      }));
  }

  getTodo(): Observable<TodoItem[]>{
    return from (this.getDB().then(db => 
      {
        return new Promise<TodoItem[]>((resolve, reject) => {
          const transaction = db.transaction([this.storeName], "readonly");
          const store = transaction.objectStore(this.storeName);
          const request = store.getAll(); //devuelve todos los objetos

          request.onsuccess = () => {
            resolve(request.result as TodoItem[]);
          };

          request.onerror = (event) => {
          console.error("Error al consultar tareas: ", (event.target as IDBRequest).error);
          reject((event.target as IDBRequest).error);
          };


        }); 

      }));
  }

    updateTodo (todo: TodoItem): Observable<void>{
    return from (this.getDB().then(db => 
      {
        return new Promise<void>((resolve, reject) => {
          const transaction = db.transaction([this.storeName], "readwrite");
          const store = transaction.objectStore(this.storeName);
          const request = store.put(todo); //put actualiza

          request.onsuccess = () => {
            resolve();
          };

          request.onerror = (event) => {
          console.error("Error al actualizar tarea: ", (event.target as IDBRequest).error);
          reject((event.target as IDBRequest).error);
          };


        }); 

      }));
  }

    deleteTodo (id: number): Observable<void>{
    return from (this.getDB().then(db => 
      {
        return new Promise<void>((resolve, reject) => {
          const transaction = db.transaction([this.storeName], "readwrite");
          const store = transaction.objectStore(this.storeName);
          const request = store.delete(id); //eliminar

          request.onsuccess = () => {
            resolve();
          };

          request.onerror = (event) => {
          console.error("Error al actualizar tarea: ", (event.target as IDBRequest).error);
          reject((event.target as IDBRequest).error);
          };


        }); 

      }));
  }


}
