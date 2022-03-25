import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Departamento } from '../models/Departamento1';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.css']
})
export class DepartamentosComponent implements OnInit {

  public titulo = 'Listagem de Departamentos';
  public departamentoSelected!: Departamento;
  public modalRef?: BsModalRef;
  
  public departamentos = [
    {Id: 1, Nome: 'Administrativo', Sigla: 'ADM'},
    {Id: 2, Nome: 'Financeiro', Sigla: 'FIN'},
  ];

  
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  
  departamentoSelect(departamento: Departamento) {
    this.departamentoSelected = departamento;
    
  }

  Voltar() {
    this.departamentoSelected 
  }
  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
  }

}
