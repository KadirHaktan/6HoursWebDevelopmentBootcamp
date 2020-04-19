import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Book } from '../models/book';
//angular da http istekleri yapabilmek için gerekli sınıfı import ediyoruz

@Injectable({
  providedIn: 'root'
})
export class BookService {

  //path:'https://localhost:44391/api/books/getall'

  constructor(private httpClient:HttpClient) { 
    
  }

  getBooks(path:string):Observable<Book[]>{
    return this.httpClient.get<Book[]>(path)  
  }

}
