import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-selectornumerico',
  imports: [],
  templateUrl: './selectornumerico.component.html',
  styleUrl: './selectornumerico.component.css'
})
export class SelectornumericoComponent {

   @Input() minimo: number = 1;
   @Input() maximo: number = 1;

   actual: number = 1;


  ngOnInit()
  {
    this.actual = this.minimo;
  }

  incrementar()
  {
    if(this.actual < this.maximo)
    {
        this.actual++;
    }
  }

  decrementar()
  {
    if(this.actual > this.minimo)
    {
        this.actual--;
    }
  }

  fijar(valor: number)
  {
    if(valor >= this.minimo && valor <= this.maximo)
    {
        this.actual = valor;
    }
  }

}
