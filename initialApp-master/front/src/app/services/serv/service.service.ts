import { Injectable } from '@angular/core';

import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Body } from '@angular/http/src/body';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http: Http, private httpClient: HttpClient) { }

  getServices(){
    return this.httpClient.get('http://localhost:51680/api/Services/GetServices')   
  }
}