import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-reloj',
  imports: [],
  templateUrl: './reloj.component.html',
  styleUrl: './reloj.component.css'
})
export class RelojComponent {

  segundo = 0;

  @Input() inicio: number = 0;
  @Output() multiplo10 = new EventEmitter<number>();

  ngOnInit()
  {

    this.segundo = this.inicio;

    this.segundo = (this.segundo + 1) * 2;
    
    this.multiplo10.emit(this.inicio+1);

  }

}
