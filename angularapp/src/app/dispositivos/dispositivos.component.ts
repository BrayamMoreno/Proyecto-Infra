import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dispositivos',
  templateUrl: './dispositivos.component.html',
  styleUrls: ['./dispositivos.component.css']
})


export class DispositivosComponent {
  
  Dispositivos: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get("https://localhost:7293/Dispositivos/GetDispositivos")
      .subscribe(
        (resultado: any) => {
          this.Dispositivos = resultado;
        },
        (error) => {
          console.error("Error al obtener datos:", error);
        }
      );
  }

}
