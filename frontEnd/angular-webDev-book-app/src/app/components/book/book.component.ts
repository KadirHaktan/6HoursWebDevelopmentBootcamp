import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  constructor(private service:BookService) {
    
  }

  

  books:Book[]

  ngOnInit(): void {
    this.getBooks()
  }

  getBooks(){
     return this.service.getBooks('https://localhost:44391/api/books/getall').subscribe(data=>{
       this.books=data;
     })

    
  }

}
