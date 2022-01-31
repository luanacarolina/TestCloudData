import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService, Entidade } from 'src/app/services/api.service';
import { FormDialogComponent } from '../dialog/form-dialog/form-dialog.component';



@Component({
  selector: 'app-tabela-municipios',
  templateUrl: './tabela-municipios.component.html',
  styleUrls: ['./tabela-municipios.component.scss']
})
export class TabelaMunicipiosComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: Entidade[] = [];
  entidade:Entidade;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */

  displayedColumns = ['id', 'nome','action'];

  constructor(public dialog: MatDialog, public municipioService: APIService ,private route:ActivatedRoute,
    private router:Router) {}

  ngOnInit() {
this.loadMunicipios();


  }

  ngAfterViewInit() {
    // this.dataSource.sort = this.sort;
    // this.dataSource.paginator = this.paginator;
    // this.table.dataSource = this.dataSource;
  }
  openDialog(id: number) {
    this.dialog.open(FormDialogComponent, {
      data: this.dataSource.filter( x => x.id = id).pop()
    });
  }
  loadMunicipios() {

     this.municipioService.municipioPOST().subscribe(data =>{
      this.municipioService.municipioAll().subscribe(x =>
        this.dataSource = x)
    })
  }
  delete(id:number){
    this.dataSource.filter(x =>x.id =id).pop()
    this.municipioService.municipioDELETE2(id).subscribe(()=>{

      this.router.navigate(['/municipios']);
    })

  }
}
