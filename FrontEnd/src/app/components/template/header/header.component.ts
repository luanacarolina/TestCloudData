import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService, Entidade } from 'src/app/services/api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  dataSource: Entidade[] = [];
  constructor(public municipioService: APIService ,private route:ActivatedRoute,
    private router:Router) { }

  ngOnInit(): void {
  }
  deleteMunicipios() {

    this.municipioService.municipioDELETE().subscribe(data =>{
     this.municipioService.municipioAll().subscribe(x =>
       this.dataSource = x)
       this.router.navigate(['/']);


   })
 }
}
