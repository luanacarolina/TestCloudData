import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { TabelaMunicipiosComponent } from './components/tabela/tabela-municipios/tabela-municipios.component';
import { HeaderComponent } from './components/template/header/header.component';

const routes: Routes = [
{
  path:"municipios",
  component:TabelaMunicipiosComponent
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
