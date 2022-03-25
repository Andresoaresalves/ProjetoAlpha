import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Funcionario } from '../models/Funcionario1';

@Injectable({
  providedIn: 'root'
})
export class FuncionariosService {

  private _baseURL = `${environment.mainUrlAPI}funcionario`;
  public get baseURL() {
    return this._baseURL;
  }
  public set baseURL(value) {
    this._baseURL = value;
  }

  constructor(private http: HttpClient) { }

  getAll(): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(this.baseURL);
  }

  getById(id: number): Observable<Funcionario> {
    return this.http.get<Funcionario>(`${this.baseURL}/${id}`);
  }

  getByChefeId(id: number): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(`${this.baseURL}/ByChefe/${id}`);
  }

  post(funcionario: Funcionario) {
    return this.http.post(this.baseURL, funcionario);
  }

  put(funcionario: Funcionario) {
    return this.http.put(`${this.baseURL}/${Funcionario.id}`, funcionario);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }


}
