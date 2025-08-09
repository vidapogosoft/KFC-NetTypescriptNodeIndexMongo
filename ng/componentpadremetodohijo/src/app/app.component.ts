import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SelectornumericoComponent } from "./selectornumerico/selectornumerico.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SelectornumericoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
 
}
