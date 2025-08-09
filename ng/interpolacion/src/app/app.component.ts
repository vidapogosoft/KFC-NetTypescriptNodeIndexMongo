import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

nombres = 'Victor Daniel Portugal';
email= 'vidapogosoft@gmail.com';
idepreferidos = ['VSCODE','Android Studio','VS2022']
lineasdecodigoultimos3años = [18000,11500,23000]
developeractivo = true;

esActivo()
{
   if (this.developeractivo)
   {
    return 'Developer con experiencia'
   }
   else
   {
    return 'Developer Retirado'
   }
}

acumuladocodigo()
{
  let codigoenexperiencia = 0;

  for(let x=0; x< this.lineasdecodigoultimos3años.length; x++)
  {
    codigoenexperiencia += this.lineasdecodigoultimos3años[x];
  }

  return codigoenexperiencia;

}

}
