import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  art = { codigo: 0, descripcion: "", precio:0  }

  productos = [{ codigo: 1, descripcion: "Laptops HP Gaming Victus", precio:1050 },
    { codigo: 2, descripcion: "Laptops ASUS VIVO Rock", precio:1000 }
  ];

  hayRegistros()
  {
    return this.productos.length > 0
  }

  agregar()
  {
    if (this.art.codigo == 0) {
      alert('Debe ingresar un código de articulo distinto a cero');
      return;
    }
    for (let x = 0; x < this.productos.length; x++)
      if (this.productos[x].codigo == this.art.codigo) {
        alert('ya existe un productos con dicho codigo');
        return;
      }
    this.productos.push({
      codigo: this.art.codigo,
      descripcion: this.art.descripcion,
      precio: this.art.precio
    });
    this.art.codigo = 0;
    this.art.descripcion = "";
    this.art.precio = 0;
 
  }

  borrar(codigo: number)
  {
    for (let x = 0; x < this.productos.length; x++)
      if (this.productos[x].codigo == codigo) {
        this.productos.splice(x, 1);
        return;
      }
  }

  modificar()
  {
    for (let x = 0; x < this.productos.length; x++)
      if (this.productos[x].codigo == this.art.codigo) {
        this.productos[x].descripcion = this.art.descripcion;
        this.productos[x].precio = this.art.precio;
        return;
      }
    alert('No existe el código de producto ingresado');
  }

  seleccionar( art: {codigo: number, descripcion: string, precio: number})
  {

    this.art.codigo = art.codigo;
    this.art.descripcion = art.descripcion;
    this.art.precio = art.precio;

  }


}
