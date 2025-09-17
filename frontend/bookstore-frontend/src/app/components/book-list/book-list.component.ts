import { Component, OnInit } from '@angular/core';
import { BookService, Book } from '../../services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  editingBook: Book | null = null;
  searchQuery: string = '';

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe(data => (this.books = data));
  }

  searchBooks(): void {
    if (!this.searchQuery.trim()) {
      this.loadBooks();
      return;
    }
    this.bookService.searchBooks(this.searchQuery).subscribe(data => (this.books = data));
  }

  deleteBook(id: number): void {
    if (confirm('Are you sure you want to delete this book?')) {
      this.bookService.deleteBook(id).subscribe(() => this.loadBooks());
    }
  }

  startEdit(book: Book): void {
    this.editingBook = { ...book };
  }

  saveEdit(): void {
    if (!this.editingBook) return;
    this.bookService.updateBook(this.editingBook.id, this.editingBook).subscribe(() => {
      this.loadBooks();
      this.editingBook = null;
    });
  }

  cancelEdit(): void {
    this.editingBook = null;
  }
}
