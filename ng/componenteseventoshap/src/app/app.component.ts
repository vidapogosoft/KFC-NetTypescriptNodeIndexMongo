import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RelojComponent } from './reloj/reloj.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RelojComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  mensaje = '';


  actualizar(dato:number)
  {
      this.mensaje = dato.toString();
  }

}
