import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService, Entidade } from 'src/app/services/api.service';

@Component({
  selector: 'app-form-dialog',
  templateUrl: './form-dialog.component.html',
  styleUrls: ['./form-dialog.component.scss']
})
export class FormDialogComponent implements OnInit {
  constructor(public municipioService: APIService , private route:ActivatedRoute,
    private router:Router , private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public entidade: any) { }

  ngOnInit(): void { }
  update(){
    console.log(this.entidade);
    this.municipioService.municipioPUT(this.entidade.id,this.entidade).subscribe(()=>{
      this.router.navigate(['/municipios']);
    })

  }
 
}
function MD_DIALOG_DATA(MD_DIALOG_DATA: any) {
  throw new Error('Function not implemented.');
}

