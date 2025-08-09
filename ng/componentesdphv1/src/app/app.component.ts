import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DadoComponent } from "../dado/dado.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, DadoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  valor1: number = this.randomnumber();
  valor2: number = this.randomnumber();
  valor3: number = this.randomnumber();
  resultado: string = '';

  randomnumber()
  {
    return Math.floor(Math.random() * 6) + 1;
  }

  aletaorio(){

      this.valor1 = this.randomnumber();
      this.valor2 = this.randomnumber();
      this.valor3 = this.randomnumber();

      if( (this.valor1 + this.valor2 + this.valor3) >= 11 )
      {
        this.resultado = 'GANO';
      }
      else
      {
          this.resultado = 'PERDIO';

      }
      

  }

}
