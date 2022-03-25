import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Funcionario } from '../models/Funcionario1';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit {
  
  public modalRef?: BsModalRef;
  public titulo = 'Listagem de Funcionários';
  public funcionarioSelected!: Funcionario;
  

  public funcionarios= [
    {Id:1, Nome: 'Marta', Sobrenome: 'Silva', Documento: '113247897'},
    {Id:2, Nome: 'Paula', Sobrenome: 'Souza', Documento: '124567415'},
    {Id:3, Nome: 'Laura', Sobrenome: 'Santos', Documento: '135218795'},
    {Id:4, Nome: 'Luisa', Sobrenome: 'Kent', Documento: '115155482'},
    {Id:5, Nome: 'Lucas', Sobrenome: 'Alves', Documento: '135654357'},
    {Id:6, Nome: 'Pedro', Sobrenome: 'Rocha', Documento: '548468455'},
    {Id:7, Nome: 'Paulo', Sobrenome: 'Silveira', Documento: '213546518'},
  ];

 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  funcionarioSelect(funcionario: Funcionario) {
    this.funcionarioSelected = funcionario;
    
  }

  Voltar() {
    this.funcionarioSelected;
  }

  constructor(private modalService: BsModalService) { }
 
  ngOnInit(): void {
  }

}
